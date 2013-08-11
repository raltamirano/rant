namespace Rant.WinGUI
{
    partial class MainForm
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
            this.cmdRun = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.lvwLog = new System.Windows.Forms.ListView();
            this.logColumnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logColumnDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logColumnText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkLogExecutionToFile = new System.Windows.Forms.CheckBox();
            this.chkConfirmationOnEveryStep = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmdRun
            // 
            this.cmdRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRun.Location = new System.Drawing.Point(510, 242);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(75, 35);
            this.cmdRun.TabIndex = 0;
            this.cmdRun.Text = "&Run script";
            this.cmdRun.UseVisualStyleBackColor = true;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.Location = new System.Drawing.Point(591, 242);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 35);
            this.cmdExit.TabIndex = 1;
            this.cmdExit.Text = "E&xit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // lvwLog
            // 
            this.lvwLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.logColumnID,
            this.logColumnDateTime,
            this.logColumnText});
            this.lvwLog.FullRowSelect = true;
            this.lvwLog.Location = new System.Drawing.Point(12, 12);
            this.lvwLog.Name = "lvwLog";
            this.lvwLog.Size = new System.Drawing.Size(654, 224);
            this.lvwLog.TabIndex = 2;
            this.lvwLog.UseCompatibleStateImageBehavior = false;
            this.lvwLog.View = System.Windows.Forms.View.Details;
            // 
            // logColumnID
            // 
            this.logColumnID.Text = "#";
            // 
            // logColumnDateTime
            // 
            this.logColumnDateTime.Text = "DATE TIME";
            this.logColumnDateTime.Width = 146;
            // 
            // logColumnText
            // 
            this.logColumnText.Text = "TEXT";
            this.logColumnText.Width = 1500;
            // 
            // chkLogExecutionToFile
            // 
            this.chkLogExecutionToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkLogExecutionToFile.AutoSize = true;
            this.chkLogExecutionToFile.Checked = true;
            this.chkLogExecutionToFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLogExecutionToFile.Location = new System.Drawing.Point(13, 242);
            this.chkLogExecutionToFile.Name = "chkLogExecutionToFile";
            this.chkLogExecutionToFile.Size = new System.Drawing.Size(72, 17);
            this.chkLogExecutionToFile.TabIndex = 3;
            this.chkLogExecutionToFile.Text = "Log to file";
            this.chkLogExecutionToFile.UseVisualStyleBackColor = true;
            // 
            // chkConfirmationOnEveryStep
            // 
            this.chkConfirmationOnEveryStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkConfirmationOnEveryStep.AutoSize = true;
            this.chkConfirmationOnEveryStep.Location = new System.Drawing.Point(13, 260);
            this.chkConfirmationOnEveryStep.Name = "chkConfirmationOnEveryStep";
            this.chkConfirmationOnEveryStep.Size = new System.Drawing.Size(151, 17);
            this.chkConfirmationOnEveryStep.TabIndex = 4;
            this.chkConfirmationOnEveryStep.Text = "Confirmation on every step";
            this.chkConfirmationOnEveryStep.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 282);
            this.Controls.Add(this.chkConfirmationOnEveryStep);
            this.Controls.Add(this.chkLogExecutionToFile);
            this.Controls.Add(this.lvwLog);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdRun);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RANT!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdRun;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.ListView lvwLog;
        private System.Windows.Forms.ColumnHeader logColumnID;
        private System.Windows.Forms.ColumnHeader logColumnDateTime;
        private System.Windows.Forms.ColumnHeader logColumnText;
        private System.Windows.Forms.CheckBox chkLogExecutionToFile;
        private System.Windows.Forms.CheckBox chkConfirmationOnEveryStep;
    }
}

