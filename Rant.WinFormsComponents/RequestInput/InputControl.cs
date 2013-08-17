using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rant.WinFormsComponents.RequestInput
{
    public partial class InputControl : UserControl
    {
        public InputControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Default value to be used when initially populating this input control.
        /// </summary>
        public Object DefaultValue { get; set; }

        /// <summary>
        /// Give implementators of this control the chance to prepare to grab input. Example: setting a 
        /// default value in the control that actually picks up the data.
        /// </summary>
        public virtual void PrepareForInput()
        { 
            // Do nothing by default.
        }

        /// <summary>
        /// Returns the value collected by this input control.
        /// </summary>
        public virtual Object Value 
        { 
            get { return null; } 
        }
    }
}
