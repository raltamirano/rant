using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rant.WinFormsComponents.RequestInput.InputControls
{
    public class TextInputControl : InputControl
    {
        private System.Windows.Forms.TextBox txtInput;

        public TextInputControl()
        {
            InitializeComponent();
        }

        public override void PrepareForInput() 
        {
            if (DefaultValue == null)
                return;
            
            this.txtInput.Text = DefaultValue.ToString();
            this.txtInput.Focus();
            this.txtInput.SelectAll();
        }
        
        public override object Value
        {
            get { return this.txtInput.Text; }
        }

        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput.ForeColor = System.Drawing.Color.Black;
            this.txtInput.Location = new System.Drawing.Point(0, 0);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(150, 20);
            this.txtInput.TabIndex = 0;
            // 
            // TextInputControl
            // 
            this.Controls.Add(this.txtInput);
            this.Name = "TextInputControl";
            this.Size = new System.Drawing.Size(150, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
