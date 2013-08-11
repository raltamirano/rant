using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;

namespace Rant.Core.ScriptRunners.Decorators
{
    /// <summary>
    /// Abstract script runner decorator that ask for confirmation before executing the script and/or every step.
    /// </summary>
    public abstract class AskConfirmationDecorator : IScriptRunnerDecorator
    {
        private readonly IScriptRunner scriptRunner;
        private readonly String confirmMessage;

        public AskConfirmationDecorator(IScriptRunner scriptRunner, String confirmMessage)
        {
            this.scriptRunner = scriptRunner;
            this.confirmMessage = confirmMessage;
        }

        public String ConfirmMessage
        {
            get { return confirmMessage; }
        }

        public bool ScriptStarting(IScript script)
        {
            if (AskConfirmation(String.Format("Start script '{0}'", script.Name)))
                return scriptRunner.ScriptStarting(script);
            else
                return false;
        }

        public void ScriptFinished(IScript script, bool withErrors)
        {
            scriptRunner.ScriptFinished(script, withErrors);
        }

        public void ScriptError(IScript script, Exception exception)
        {
            scriptRunner.ScriptError(script, exception);
        }

        public void BeforeStepRun(Step step)
        {
            scriptRunner.BeforeStepRun(step);
        }

        public bool StepRun(Step step)
        {
            if (AskConfirmation(step.Name))
                return scriptRunner.StepRun(step);
            else
                return false;
        }

        public void AfterStepRun(Step step, bool withError)
        {
            scriptRunner.AfterStepRun(step, withError);
        }

        public void StepError(Step step, Exception exception)
        {
            scriptRunner.StepError(step, exception);
        }

        public abstract bool AskConfirmation(string item);
    }
}
