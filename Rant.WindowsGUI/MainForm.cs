using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rant.Core;
using Rant.Core.Tasks;
using Rant.Common;
using Rant.Core.ScriptReaders;
using Rant.Core.ScriptRunners;
using System.IO;
using Rant.Core.ScriptRunners.Decorators;
using Rant.WinFormsComponents.ScriptRunners.Decorators;

namespace Rant.WinGUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void cmdRun_Click(object sender, EventArgs e)
        {
            if (chkClearLogOnEveryScriptRun.Checked)
                lvwLog.Items.Clear();

            IScript script = null;

            //script = getSampleScript();
            script = ScriptReaderFactory.Instance.CreateFileReader(@".\Samples\sample6.rant").Read();

            runScript(script);
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void runScript(IScript script)
        {
            try
            {
                attachToScriptEvents(script);
                
                IScriptRunner scriptRunner = ScriptRunnerFactory.Instance.GetDefaultScriptRunner();

                if (chkLogExecutionToFile.Checked)
                    scriptRunner = new FileLoggerDecorator(scriptRunner, 
                        new FileInfo(Path.GetDirectoryName(Application.ExecutablePath)), true);

                if (chkConfirmationOnEveryStep.Checked)
                    scriptRunner = new WinFormsAskConfirmationDecorator(scriptRunner, "Do you confirm execution of: '{0}'?");

                // Adds the Winforms, GUI-based input variable requester.
                scriptRunner = new WinFormsRequestInputParameterDecorator(scriptRunner);

                script.Execute(scriptRunner);
            }
            finally
            {
                if (script != null)
                    deattachFromScriptEvents(script);
            }
        }

        private IScript getSampleScript()
        {
            IScript script =
                ScriptBuilder.Create()
                    .Initialize("Test1", "Test script #1")

                        .AddStep("Simple message", TaskFactory.Instance.Echo("Hi there!"), true)
                        .AddStep("Dump all environment variables", TaskFactory.Instance.DumpEnvironment(), false)
                        .AddStep("Ouch! An error!", TaskFactory.Instance.Fail("Dangerous error occurred. Run for cover!"), true)

                        //.RegisterScriptStartingHandler(script_ScriptStarting)
                        //.RegisterScriptFinishedHandler(script_ScriptFinished)
                        //.RegisterScriptErrorHandler(script_ScriptError)
                        //.RegisterStepStartingHandler(script_StepStarting)
                        //.RegisterStepSkippedHandler(script_StepSkipped)
                        //.RegisterStepFinishedHandler(script_StepFinished)
                        //.RegisterStepErrorHandler(script_StepError)

                    .Build();

            return script;
        }

        private void attachToScriptEvents(IScript script)
        {
            script.ScriptStarting += script_ScriptStarting;
            script.ScriptFinished += script_ScriptFinished;
            script.ScriptError += script_ScriptError;
            script.StepStarting += script_StepStarting;
            script.StepSkipped += script_StepSkipped;
            script.StepFinished += script_StepFinished;
            script.StepError += script_StepError;
        }

        private void deattachFromScriptEvents(IScript script)
        {
            script.ScriptStarting -= script_ScriptStarting;
            script.ScriptFinished -= script_ScriptFinished;
            script.ScriptError -= script_ScriptError;
            script.StepStarting -= script_StepStarting;
            script.StepSkipped -= script_StepSkipped;
            script.StepFinished -= script_StepFinished;
            script.StepError -= script_StepError;
        }

        private void addLogItem(String text)
        {
            addLogItem(text, Color.Green);
        }
        
        private void addLogItem(String text, Color textColor)
        {
            ListViewItem item = lvwLog.Items.Add("");
            item.Text = (item.Index+1).ToString("0000");
            item.ForeColor = textColor;
            item.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")).ForeColor = textColor;
            item.SubItems.Add(text).ForeColor = textColor;

            if (chkScrollToNewLogItems.Checked)
                item.EnsureVisible();
        }

        void script_ScriptStarting(IScript script)
        {
            addLogItem("Starting script '" + script.Name + "' ...");
        }

        void script_ScriptFinished(IScript script, bool withErrors)
        {
            if (withErrors)
                addLogItem("Script '" + script.Name + "' finished with errors. Check previous log items.", Color.Red);
            else
                addLogItem("Script '" + script.Name + "' finished with no errors.");
        }
        
        void script_ScriptError(IScript script, Exception exception)
        {
            addLogItem("Error executing script '" + script.Name + "': " + exception.Message, Color.Red);
        }
        
        void script_StepStarting(Step step)
        {
            addLogItem("Executing step '" + step.Name + "' [" + step.Task.Name + "] ...");
        }

        void script_StepSkipped(Step step)
        {
            addLogItem("Skipped execution of step '" + step.Name + "'.", Color.Red);
        }
        
        void script_StepFinished(Step step)
        {
            addLogItem("Finished execution of step '" + step.Name + "'.");
        }
        
        void script_StepError(Step step, Exception exception)
        {
            addLogItem("Error executing step '" + step.Name + "': " + exception.Message, Color.Red);
        }
    }
}
