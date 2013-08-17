using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Core.ScriptRunners.Decorators;
using Rant.Common;
using System.Windows.Forms;
using Rant.WinFormsComponents.RequestInput;
using Rant.WinFormsComponents.RequestInput.InputControls;

namespace Rant.WinFormsComponents.ScriptRunners.Decorators
{
    /// <summary>
    /// Winforms, GUI-based ask-confirmation decorator for script runners.
    /// </summary>
    public class WinFormsRequestInputParameterDecorator : RequestInputParameterDecorator
    {
        private readonly IScriptRunner scriptRunner;

        public WinFormsRequestInputParameterDecorator(IScriptRunner scriptRunner)
            : base(scriptRunner)
        {
            this.scriptRunner = scriptRunner;
        }

        public override object RequestInput(string prompt, Object defaultValue)
        {        
            InputControl inputControl = createInputControl();

            inputControl.Name = "inputControl";
            inputControl.DefaultValue = defaultValue;         

            String title = "Please provide the requested information";
            RequestInputForm inputForm = new RequestInputForm(title, prompt, inputControl);

            return (inputForm.ShowDialog() == DialogResult.OK) ? inputForm.Value : defaultValue;
        }

        private InputControl createInputControl()
        {
            //TODO: data-type info for the value needed will be provided later, so a more 
            //      appropiate input control could be used instead of plain text.
            TextInputControl control = new TextInputControl();

            control.Dock = DockStyle.Fill;
            control.Size = new System.Drawing.Size(150, 21);

            return control;
        }
    }
}
