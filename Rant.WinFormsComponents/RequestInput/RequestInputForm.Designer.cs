namespace Rant.WinFormsComponents.RequestInput
{
    partial class RequestInputForm
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
            this.pnlPrompt = new System.Windows.Forms.Panel();
            this.txtPrompt = new System.Windows.Forms.TextBox();
            this.pnlCommands = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlInputControl = new System.Windows.Forms.Panel();
            this.pnlPrompt.SuspendLayout();
            this.pnlCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrompt
            // 
            this.pnlPrompt.Controls.Add(this.txtPrompt);
            this.pnlPrompt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPrompt.Location = new System.Drawing.Point(0, 0);
            this.pnlPrompt.Name = "pnlPrompt";
            this.pnlPrompt.Size = new System.Drawing.Size(481, 31);
            this.pnlPrompt.TabIndex = 0;
            // 
            // txtPrompt
            // 
            this.txtPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrompt.Location = new System.Drawing.Point(0, 0);
            this.txtPrompt.Name = "txtPrompt";
            this.txtPrompt.ReadOnly = true;
            this.txtPrompt.Size = new System.Drawing.Size(481, 20);
            this.txtPrompt.TabIndex = 0;
            this.txtPrompt.TabStop = false;
            // 
            // pnlCommands
            // 
            this.pnlCommands.Controls.Add(this.btnOK);
            this.pnlCommands.Controls.Add(this.btnCancel);
            this.pnlCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommands.Location = new System.Drawing.Point(0, 60);
            this.pnlCommands.Name = "pnlCommands";
            this.pnlCommands.Size = new System.Drawing.Size(481, 37);
            this.pnlCommands.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(305, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 35);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(406, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 35);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlInputControl
            // 
            this.pnlInputControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInputControl.Location = new System.Drawing.Point(0, 31);
            this.pnlInputControl.Name = "pnlInputControl";
            this.pnlInputControl.Size = new System.Drawing.Size(481, 29);
            this.pnlInputControl.TabIndex = 2;
            // 
            // RequestInputForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 97);
            this.Controls.Add(this.pnlInputControl);
            this.Controls.Add(this.pnlCommands);
            this.Controls.Add(this.pnlPrompt);
            this.Name = "RequestInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RequestInputForm";
            this.pnlPrompt.ResumeLayout(false);
            this.pnlPrompt.PerformLayout();
            this.pnlCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrompt;
        private System.Windows.Forms.TextBox txtPrompt;
        private System.Windows.Forms.Panel pnlCommands;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlInputControl;

    }
}