namespace PrintJobSender
{
	partial class FrmJobSender
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJobSender));
            this.txtJobDirectory = new System.Windows.Forms.TextBox();
            this.lblJobDirectory = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.txtPrinter = new System.Windows.Forms.TextBox();
            this.btnPrinter = new System.Windows.Forms.Button();
            this.btnJobDirectory = new System.Windows.Forms.Button();
            this.tpHelper = new System.Windows.Forms.ToolTip(this.components);
            this.ndwInterval = new System.Windows.Forms.NumericUpDown();
            this.pbSendJob = new System.Windows.Forms.ProgressBar();
            this.fbdFilePath = new System.Windows.Forms.FolderBrowserDialog();
            this.gbRadioBtnSend = new System.Windows.Forms.GroupBox();
            this.rbtAnyFiles = new System.Windows.Forms.RadioButton();
            this.rbtOnlyFile = new System.Windows.Forms.RadioButton();
            this.gbConfigSend = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtEMF = new System.Windows.Forms.RadioButton();
            this.rbtRAW = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkJobInfo = new System.Windows.Forms.CheckBox();
            this.txtDocumentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJobOwner = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ndwInterval)).BeginInit();
            this.gbRadioBtnSend.SuspendLayout();
            this.gbConfigSend.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtJobDirectory
            // 
            this.txtJobDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJobDirectory.Location = new System.Drawing.Point(33, 340);
            this.txtJobDirectory.Name = "txtJobDirectory";
            this.txtJobDirectory.Size = new System.Drawing.Size(389, 20);
            this.txtJobDirectory.TabIndex = 0;
            // 
            // lblJobDirectory
            // 
            this.lblJobDirectory.AutoSize = true;
            this.lblJobDirectory.Location = new System.Drawing.Point(13, 24);
            this.lblJobDirectory.Name = "lblJobDirectory";
            this.lblJobDirectory.Size = new System.Drawing.Size(86, 13);
            this.lblJobDirectory.TabIndex = 1;
            this.lblJobDirectory.Text = "SPL Path";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(340, 452);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(142, 41);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblPrinter
            // 
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Location = new System.Drawing.Point(13, 80);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(58, 13);
            this.lblPrinter.TabIndex = 4;
            this.lblPrinter.Text = "Printer";
            // 
            // txtPrinter
            // 
            this.txtPrinter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrinter.Location = new System.Drawing.Point(33, 396);
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.Size = new System.Drawing.Size(389, 20);
            this.txtPrinter.TabIndex = 3;
            // 
            // btnPrinter
            // 
            this.btnPrinter.FlatAppearance.BorderSize = 0;
            this.btnPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrinter.Image = global::PrintJobSender.Properties.Resources.printer;
            this.btnPrinter.Location = new System.Drawing.Point(429, 393);
            this.btnPrinter.Name = "btnPrinter";
            this.btnPrinter.Size = new System.Drawing.Size(27, 23);
            this.btnPrinter.TabIndex = 6;
            this.tpHelper.SetToolTip(this.btnPrinter, "Select printer where the print file will be sent.\r\n\r\n(!)Obs: " +
        "It is not possible to change the print properties,\r\n             " +
        "they are already configured in the SPL file.");
            this.btnPrinter.UseVisualStyleBackColor = true;
            this.btnPrinter.Click += new System.EventHandler(this.btnPrinter_Click);
            // 
            // btnJobDirectory
            // 
            this.btnJobDirectory.FlatAppearance.BorderSize = 0;
            this.btnJobDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobDirectory.Location = new System.Drawing.Point(430, 336);
            this.btnJobDirectory.Name = "btnJobDirectory";
            this.btnJobDirectory.Size = new System.Drawing.Size(27, 23);
            this.btnJobDirectory.TabIndex = 5;
            this.tpHelper.SetToolTip(this.btnJobDirectory, "Select SPL file source for printing");
            this.btnJobDirectory.UseVisualStyleBackColor = true;
            this.btnJobDirectory.Click += new System.EventHandler(this.btnJobDirectory_Click);
            // 
            // tpHelper
            // 
            this.tpHelper.AutoPopDelay = 10000;
            this.tpHelper.InitialDelay = 500;
            this.tpHelper.IsBalloon = true;
            this.tpHelper.ReshowDelay = 100;
            // 
            // ndwInterval
            // 
            this.ndwInterval.Location = new System.Drawing.Point(305, 16);
            this.ndwInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ndwInterval.Name = "ndwInterval";
            this.ndwInterval.Size = new System.Drawing.Size(50, 20);
            this.ndwInterval.TabIndex = 2;
            this.tpHelper.SetToolTip(this.ndwInterval, "File sending interval (milliseconds)");
            this.ndwInterval.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // pbSendJob
            // 
            this.pbSendJob.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbSendJob.Location = new System.Drawing.Point(12, 461);
            this.pbSendJob.Maximum = 1;
            this.pbSendJob.Minimum = 1;
            this.pbSendJob.Name = "pbSendJob";
            this.pbSendJob.Size = new System.Drawing.Size(470, 23);
            this.pbSendJob.Step = 1;
            this.pbSendJob.TabIndex = 9;
            this.tpHelper.SetToolTip(this.pbSendJob, "Sending files to print");
            this.pbSendJob.Value = 1;
            this.pbSendJob.Visible = false;
            // 
            // gbRadioBtnSend
            // 
            this.gbRadioBtnSend.Controls.Add(this.ndwInterval);
            this.gbRadioBtnSend.Controls.Add(this.rbtAnyFiles);
            this.gbRadioBtnSend.Controls.Add(this.rbtOnlyFile);
            this.gbRadioBtnSend.Location = new System.Drawing.Point(12, 12);
            this.gbRadioBtnSend.Name = "gbRadioBtnSend";
            this.gbRadioBtnSend.Size = new System.Drawing.Size(470, 48);
            this.gbRadioBtnSend.TabIndex = 7;
            this.gbRadioBtnSend.TabStop = false;
            this.gbRadioBtnSend.Text = "Send type";
            // 
            // rbtAnyFiles
            // 
            this.rbtAnyFiles.AutoSize = true;
            this.rbtAnyFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtAnyFiles.Location = new System.Drawing.Point(203, 19);
            this.rbtAnyFiles.Name = "rbtAnyFiles";
            this.rbtAnyFiles.Size = new System.Drawing.Size(96, 17);
            this.rbtAnyFiles.TabIndex = 1;
            this.rbtAnyFiles.Text = "Multiple files";
            this.rbtAnyFiles.UseVisualStyleBackColor = true;
            this.rbtAnyFiles.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtOnlyFile
            // 
            this.rbtOnlyFile.AutoSize = true;
            this.rbtOnlyFile.Checked = true;
            this.rbtOnlyFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtOnlyFile.Location = new System.Drawing.Point(21, 19);
            this.rbtOnlyFile.Name = "rbtOnlyFile";
            this.rbtOnlyFile.Size = new System.Drawing.Size(124, 17);
            this.rbtOnlyFile.TabIndex = 0;
            this.rbtOnlyFile.TabStop = true;
            this.rbtOnlyFile.Text = "Only one file";
            this.rbtOnlyFile.UseVisualStyleBackColor = true;
            this.rbtOnlyFile.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // gbConfigSend
            // 
            this.gbConfigSend.Controls.Add(this.lblJobDirectory);
            this.gbConfigSend.Controls.Add(this.lblPrinter);
            this.gbConfigSend.Location = new System.Drawing.Point(12, 300);
            this.gbConfigSend.Name = "gbConfigSend";
            this.gbConfigSend.Size = new System.Drawing.Size(470, 135);
            this.gbConfigSend.TabIndex = 8;
            this.gbConfigSend.TabStop = false;
            this.gbConfigSend.Text = "Send Files";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtEMF);
            this.groupBox1.Controls.Add(this.rbtRAW);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMachineName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkJobInfo);
            this.groupBox1.Controls.Add(this.txtDocumentName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtJobOwner);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 228);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Job Info";
            // 
            // rbtEMF
            // 
            this.rbtEMF.AutoSize = true;
            this.rbtEMF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtEMF.Location = new System.Drawing.Point(107, 200);
            this.rbtEMF.Name = "rbtEMF";
            this.rbtEMF.Size = new System.Drawing.Size(46, 17);
            this.rbtEMF.TabIndex = 9;
            this.rbtEMF.Text = "EMF";
            this.rbtEMF.UseVisualStyleBackColor = true;
            // 
            // rbtRAW
            // 
            this.rbtRAW.AutoSize = true;
            this.rbtRAW.Checked = true;
            this.rbtRAW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtRAW.Location = new System.Drawing.Point(16, 200);
            this.rbtRAW.Name = "rbtRAW";
            this.rbtRAW.Size = new System.Drawing.Size(50, 17);
            this.rbtRAW.TabIndex = 8;
            this.rbtRAW.TabStop = true;
            this.rbtRAW.Text = "RAW";
            this.rbtRAW.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Print Processor";
            // 
            // txtMachineName
            // 
            this.txtMachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMachineName.Location = new System.Drawing.Point(21, 151);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(389, 20);
            this.txtMachineName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Machine name";
            // 
            // chkJobInfo
            // 
            this.chkJobInfo.AutoSize = true;
            this.chkJobInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkJobInfo.Location = new System.Drawing.Point(16, 20);
            this.chkJobInfo.Name = "chkJobInfo";
            this.chkJobInfo.Size = new System.Drawing.Size(147, 17);
            this.chkJobInfo.TabIndex = 4;
            this.chkJobInfo.Text = "Use Extra Infos";
            this.chkJobInfo.UseVisualStyleBackColor = true;
            this.chkJobInfo.CheckedChanged += new System.EventHandler(this.chkJobInfo_CheckedChanged);
            // 
            // txtDocumentName
            // 
            this.txtDocumentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumentName.Enabled = false;
            this.txtDocumentName.Location = new System.Drawing.Point(21, 105);
            this.txtDocumentName.Name = "txtDocumentName";
            this.txtDocumentName.Size = new System.Drawing.Size(389, 20);
            this.txtDocumentName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Document Name";
            // 
            // txtJobOwner
            // 
            this.txtJobOwner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJobOwner.Enabled = false;
            this.txtJobOwner.Location = new System.Drawing.Point(21, 63);
            this.txtJobOwner.Name = "txtJobOwner";
            this.txtJobOwner.Size = new System.Drawing.Size(389, 20);
            this.txtJobOwner.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Owner User";
            // 
            // FrmJobSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 505);
            this.Controls.Add(this.btnJobDirectory);
            this.Controls.Add(this.txtPrinter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbSendJob);
            this.Controls.Add(this.gbRadioBtnSend);
            this.Controls.Add(this.btnPrinter);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtJobDirectory);
            this.Controls.Add(this.gbConfigSend);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(510, 900);
            this.MinimumSize = new System.Drawing.Size(510, 38);
            this.Name = "FrmJobSender";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintJob Sender";
            ((System.ComponentModel.ISupportInitialize)(this.ndwInterval)).EndInit();
            this.gbRadioBtnSend.ResumeLayout(false);
            this.gbRadioBtnSend.PerformLayout();
            this.gbConfigSend.ResumeLayout(false);
            this.gbConfigSend.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtJobDirectory;
		private System.Windows.Forms.Label lblJobDirectory;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Label lblPrinter;
		private System.Windows.Forms.TextBox txtPrinter;
		private System.Windows.Forms.Button btnJobDirectory;
		private System.Windows.Forms.Button btnPrinter;
		private System.Windows.Forms.ToolTip tpHelper;
		private System.Windows.Forms.FolderBrowserDialog fbdFilePath;
		private System.Windows.Forms.GroupBox gbRadioBtnSend;
		private System.Windows.Forms.RadioButton rbtAnyFiles;
		private System.Windows.Forms.RadioButton rbtOnlyFile;
		private System.Windows.Forms.GroupBox gbConfigSend;
		private System.Windows.Forms.NumericUpDown ndwInterval;
		private System.Windows.Forms.ProgressBar pbSendJob;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkJobInfo;
        private System.Windows.Forms.TextBox txtDocumentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtJobOwner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtEMF;
        private System.Windows.Forms.RadioButton rbtRAW;
        private System.Windows.Forms.Label label4;
	}
}

