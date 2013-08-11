using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Core.ScriptRunners.Decorators;
using Rant.Common;
using System.Windows.Forms;

namespace Rant.WinFormsComponents.ScriptRunners.Decorators
{
    /// <summary>
    /// Winforms, GUI-based ask-confirmation decorator for script runners.
    /// </summary>
    public class WinFormsAskConfirmationDecorator : AskConfirmationDecorator
    {
        public WinFormsAskConfirmationDecorator(IScriptRunner scriptRunner, String confirmMessage)
            : base(scriptRunner, confirmMessage)
        { 
        
        }

        public override bool AskConfirmation(string item)
        {
            return MessageBox.Show(String.Format(ConfirmMessage, item), "Confirmation required",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }
    }
}
