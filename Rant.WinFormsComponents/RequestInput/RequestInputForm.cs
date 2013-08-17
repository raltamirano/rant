using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rant.WinFormsComponents.RequestInput
{
    public partial class RequestInputForm : Form
    {
        private readonly String title;
        private readonly String prompt;
        private readonly InputControl inputControl;
    
        public RequestInputForm(String title, String prompt, InputControl inputControl)
        {
            InitializeComponent();

            this.title = title;
            this.prompt = prompt;
            this.inputControl = inputControl;

            this.Text = title;
            this.txtPrompt.Text = prompt;

            this.pnlInputControl.Controls.Add(inputControl);
            inputControl.Focus();
            inputControl.PrepareForInput();
        }

        public object Value
        {
            get { return this.inputControl.Value; }
        }        
    }
}
