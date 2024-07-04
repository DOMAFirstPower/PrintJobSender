using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PrintJobSender
{
    public partial class FrmJobSender : Form
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJobSender));

        public FrmJobSender()
        {
            InitializeComponent();

            if (this.rbtOnlyFile.Checked)
            {
                this.lblJobDirectory.Text = "SPL File";
                this.btnJobDirectory.Image = Image.FromFile("Imagens\\file.png");
                this.ndwInterval.Enabled = false;
            }
            else
            {
                this.lblJobDirectory.Text = "SPLs Path";
                this.btnJobDirectory.Image = Image.FromFile("Imagens\\dir.png");
                this.ndwInterval.Enabled = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            DataType dataType = this.rbtRAW.Checked ? DataType.RAW : DataType.EMF;
            if (this.rbtOnlyFile.Checked)
            {
                if (!String.IsNullOrEmpty(this.txtJobDirectory.Text) && !String.IsNullOrEmpty(this.txtPrinter.Text))
                {
                    if (File.Exists(this.txtJobDirectory.Text))
                    {
                        String userName = String.IsNullOrEmpty(this.txtJobOwner.Text) ? String.Empty : this.txtJobOwner.Text;
                        String machineName = String.IsNullOrEmpty(this.txtMachineName.Text) ? String.Empty : this.txtMachineName.Text;
                        string docName = string.IsNullOrEmpty(txtDocumentName.Text) ? null : txtDocumentName.Text;

                        this.SendPrintJob(this.txtPrinter.Text, new List<string>() { (this.txtJobDirectory.Text) }, dataType, userName, docName, machineName);
                    }
                    else
                        MessageBox.Show("SPL File not found");
                }
                else
                    MessageBox.Show("SPL path and Printer Name required");
            }
            if (this.rbtAnyFiles.Checked)
            {
                if (!String.IsNullOrEmpty(this.txtJobDirectory.Text) && !String.IsNullOrEmpty(this.txtPrinter.Text))
                {
                    if (Directory.Exists(this.txtJobDirectory.Text))
                    {
                        List<String> lstFiles = GetListFiles(this.txtJobDirectory.Text);
                        string docName = string.IsNullOrEmpty(txtDocumentName.Text) ? null : txtDocumentName.Text;

                        this.btnSend.Visible = false;
                        this.pbSendJob.Visible = true;
                        this.pbSendJob.Maximum = lstFiles.Count;

                        String userName = String.Empty;
                        userName = String.IsNullOrEmpty(this.txtJobOwner.Text) ? String.Empty : this.txtJobOwner.Text;

                        this.SendPrintJob(this.txtPrinter.Text, lstFiles, dataType, userName, docName, interval: (int)ndwInterval.Value);

                        this.pbSendJob.PerformStep();
                    }
                    else
                        MessageBox.Show("Path not found");
                }
                else
                    MessageBox.Show("SPL path and Printer Name required");
            }

            this.btnSend.Visible = true;
            this.pbSendJob.Visible = false;

        }

        private void SendPrintJob(String pPrinterName, List<String> pFile, DataType pDataType, String UserName = null, String pDocName = null, String pMachineName = null, int interval = 0)
        {
            // Print the file to the printer.
            RawPrinterHelper.SendFilesToPrinter(pPrinterName, pFile, UserName, pDocName, pDataType, interval, pMachineName);
        }

        private void btnJobDirectory_Click(object sender, EventArgs e)
        {
            if (this.rbtOnlyFile.Checked)
            {
                // Allow the user to select a file.
                OpenFileDialog ofd = new OpenFileDialog();
                if (DialogResult.OK == ofd.ShowDialog(this))
                {
                    this.txtJobDirectory.Text = ofd.FileName;
                }
            }
            else
            {
                this.fbdFilePath.SelectedPath = this.txtJobDirectory.Text;
                this.fbdFilePath.ShowDialog();
                this.txtJobDirectory.Text = this.fbdFilePath.SelectedPath;
            }
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            //Allow the user to select a printer.
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                this.txtPrinter.Text = pd.PrinterSettings.PrinterName;
            }
        }

        private void rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtOnlyFile.Checked)
            {
                this.lblJobDirectory.Text = "SPL File";
                this.btnJobDirectory.Image = Image.FromFile("Imagens\\file.png");
                this.txtJobDirectory.Text = String.Empty;
                this.ndwInterval.Enabled = false;
            }
            else
            {
                this.lblJobDirectory.Text = "SPLs Path";
                this.btnJobDirectory.Image = Image.FromFile("Imagens\\dir.png");
                this.txtJobDirectory.Text = String.Empty;
                this.ndwInterval.Enabled = true;
            }
        }

        private List<String> GetListFiles(String pDir)
        {
            List<String> lstFiles = new List<string>();

            List<string> dirs = new List<string>(Directory.EnumerateDirectories(pDir));

            if (dirs.Count == 0)
                return Directory.GetFiles(pDir, "*.SPL").ToList();

            foreach (var dir in dirs)
            {
                lstFiles.AddRange(GetListFiles(dir));
            }

            return lstFiles;
        }

        private void chkJobInfo_CheckedChanged(object sender, EventArgs e)
        {
            this.txtJobOwner.Enabled = this.txtDocumentName.Enabled = this.chkJobInfo.Checked;

            if (!this.chkJobInfo.Checked)
            {
                this.txtDocumentName.Text = String.Empty;
                this.txtJobOwner.Text = String.Empty;
            }
        }
    }

    public class RawPrinterHelper
    {
        // Declaração de estruturas e API:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }


        [DllImport("winspool.drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        protected static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string pPrinterName, out IntPtr phPrinter, ref PRINTER_DEFAULTS ptrDefault);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        [DllImport("winspool.drv", EntryPoint = "SetJobA", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetJob(IntPtr hPrinter, int jobId, int level, IntPtr pJob, int command);

        [DllImport("winspool.drv", EntryPoint = "GetJobA", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetJob(IntPtr hPrinter, int jobId, int level, IntPtr pJob, int cbBuf, out int pcbNeeded);

        #region External Definitions
        [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public UInt16 wYear;
            public UInt16 wMonth;
            public UInt16 wDayOfWeek;
            public UInt16 wDay;
            public UInt16 wHour;
            public UInt16 wMinute;
            public UInt16 wSecond;
            public UInt16 wMilliseconds;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        protected class JOB_INFO_1
        {
            public uint JobId;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPrinterName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pMachineName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pUserName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocument;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDatatype;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pStatus;
            public uint Status;
            public uint Priority;
            public uint Position;
            public uint TotalPages;
            public uint PagesPrinted;
            public SYSTEMTIME Submitted;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        protected struct PRINTER_INFO_2
        {
            public string pServerName;
            public string pPrinterName;
            public string pShareName;
            public string pPortName;
            public string pDriverName;
            public string pComment;
            public string pLocation;
            public IntPtr pDevMode;
            public string pSepFile;
            public string pPrintProcessor;
            public string pDatatype;
            public string pParameters;
            public IntPtr pSecurityDescriptor;
            public uint Attributes;
            public uint Priority;
            public uint DefaultPriority;
            public uint StartTime;
            public uint UntilTime;
            public uint Status;
            public uint cJobs;
            public uint AveragePPM;
        }
        protected struct PRINTER_DEFAULTS
        {
            public IntPtr pDatatype;
            public IntPtr pDevMode;
            public int DesiredAccess;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        protected struct DOCINFOW
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDataType;
        }

        [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode), System.Security.SuppressUnmanagedCodeSecurity()]
        public class JOB_INFO_2
        {
            public UInt32 JobId;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pPrinterName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pMachineName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pUserName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDocument;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pNotifyName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDatatype;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pPrintProcessor;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pParameters;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDriverName;

            public IntPtr LPDeviceMode;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pStatus;
            public UInt32 pSecurityDescriptor;
            [MarshalAs(UnmanagedType.U4)]
            public JobStatus Status;
            public UInt32 Priority;
            public UInt32 Position;
            public UInt32 StartTime;
            public UInt32 UntilTime;
            public UInt32 TotalPages;
            public UInt32 JobSize;
            [MarshalAs(UnmanagedType.Struct)]
            public SYSTEMTIME Submitted;
            public UInt32 Time;
            public UInt32 PagesPrinted;
        };

        public enum JobStatus
        {
            JOB_STATUS_BLOCKED_DEVQ,    // The driver cannot print the job.
            JOB_STATUS_COMPLETE,        // Windows XP and later: Job is sent to the printer, but the job may not be printed yet.
            JOB_STATUS_DELETED,         // Job has been deleted.
            JOB_STATUS_DELETING,        // Job is being deleted.
            JOB_STATUS_ERROR,            // An error is associated with the job.
            JOB_STATUS_OFFLINE,            // Printer is offline.
            JOB_STATUS_PAPEROUT,        // Printer is out of paper.
            JOB_STATUS_PAUSED,            // Job is paused.
            JOB_STATUS_PRINTED,            // Job has printed.
            JOB_STATUS_PRINTING,        // Job is printing.
            JOB_STATUS_RESTART,            // Job has been restarted.
            JOB_STATUS_RETAINED,
            /*Windows Vista and later: Job has been retained in the print queue and cannot be deleted. This can be caused by the following:
            1) The job was manually retained by a call to SetJob and the spooler is waiting for the job to be released.
            2) The job has not finished printing and must finish printing before it can be automatically deleted.
            See SetJob for more information about print job commands. */
            JOB_STATUS_SPOOLING,        // Job is spooling.
            JOB_STATUS_USER_INTERVENTION    // Printer has an error that requires the user to do something.
        }
        #endregion

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendFilesToPrinter(string szPrinterName, List<string> lstFiles, String userName, string pDocName, DataType pDataType, int interval, String pMachineName = null)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            IntPtr hPD = new IntPtr(983041);
            IntPtr pUnmanagedBytes = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume falha por padrão.
            int jobId = 0;

            di.pDataType = pDataType == DataType.RAW ? "RAW" : "NT EMF 1.008";

            PRINTER_DEFAULTS printerDefaults = default(PRINTER_DEFAULTS);
            printerDefaults.DesiredAccess = System.Printing.PrintSystemDesiredAccess.AdministratePrinter.GetHashCode();

            // Abre a impressora.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, ref printerDefaults))
            {
                foreach (string file in lstFiles)
                {
                    int dwCount = 0;
                    string docName = string.IsNullOrEmpty(pDocName) ? System.IO.Path.GetFileNameWithoutExtension(file) : pDocName;
                    di.pDocName = docName;
                    pUnmanagedBytes = GetBytes(file, ref dwCount);
                    // Inicia o documento.
                    if ((jobId = StartDocPrinter(hPrinter, 1, di)) != 0)
                    {
                        if (!String.IsNullOrEmpty(userName))
                            UpdateJobInfo(hPrinter, jobId, userName, docName, pMachineName);

                        // Inicia a página.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Escreve seus Bytes.
                            bSuccess = WritePrinter(hPrinter, pUnmanagedBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    Marshal.FreeCoTaskMem(pUnmanagedBytes);

                    System.Threading.Thread.Sleep(interval);
                }

                ClosePrinter(hPrinter);
            }
            // Em caso de falha, o GetLastError pode nos dar mais informações sobre o erro.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        private static IntPtr GetBytes(string file, ref int length)
        {
            try
            {
                // Abre o arquivo.
                FileStream fs = new FileStream(file, FileMode.Open);
                // Cria um BinaryReader sobre o arquivo.
                BinaryReader br = new BinaryReader(fs, Encoding.UTF8);
                // Cria um array de bytes grandes o suficiente para armazenar o conteúdo do arquivo.
                Byte[] bytes = new Byte[fs.Length];
                // Ponteiro não gerenciado.
                IntPtr pUnmanagedBytes = new IntPtr(0);

                length = Convert.ToInt32(fs.Length);
                // Lê o conteúdo do arquivo e insere no array.
                bytes = br.ReadBytes(length);
                // Alocar um pouco de memória não gerenciada para aqueles bytes.
                pUnmanagedBytes = Marshal.AllocCoTaskMem(length);
                // Copia os bytes do array gerenciado para o array não gerenciado
                Marshal.Copy(bytes, 0, pUnmanagedBytes, length);
                //Libera arquivo e Binaryreader
                fs.Dispose();
                br.Dispose();

                return pUnmanagedBytes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new IntPtr(0);
            }
        }

        private static void UpdateJobInfo(IntPtr hPrinter, int jobId, string userName, string jobName, string machineName = null)
        {
            IntPtr hJobInfo = IntPtr.Zero;
            IntPtr hNewJobInfo = IntPtr.Zero;

            try
            {
                int jobBufferSize;
                JOB_INFO_1 jobInfo = new JOB_INFO_1();
                GetJob(hPrinter, jobId, 1, IntPtr.Zero, 0, out jobBufferSize);
                if (jobBufferSize == 0)
                    throw new Exception("The print job could not be loaded.", new Win32Exception(Marshal.GetLastWin32Error()));

                hJobInfo = Marshal.AllocHGlobal(jobBufferSize);
                if (!GetJob(hPrinter, jobId, 1, hJobInfo, jobBufferSize, out jobBufferSize))
                    throw new Exception("The print job could not be loaded with the specified buffer.", new Win32Exception(Marshal.GetLastWin32Error()));

                // Change New Job Properties
                Marshal.PtrToStructure(hJobInfo, jobInfo);
                jobInfo.pUserName = userName;
                jobInfo.pMachineName = (machineName ?? jobInfo.pMachineName);
                jobInfo.pDocument = jobName;


                hNewJobInfo = Marshal.AllocHGlobal(Marshal.SizeOf(jobInfo));
                Marshal.StructureToPtr(jobInfo, hNewJobInfo, false);

                if (!SetJob(hPrinter, jobId, 1, hNewJobInfo, 0))
                    throw new Exception("Unable to update print job properties.", new Win32Exception(Marshal.GetLastWin32Error()));
            }
            finally
            {
                if (hJobInfo != IntPtr.Zero)
                    Marshal.FreeHGlobal(hJobInfo);

                if (hNewJobInfo != IntPtr.Zero)
                    Marshal.FreeHGlobal(hNewJobInfo);
            }
        }
    }

    public enum DataType
    {
        RAW,
        EMF
    }
}
