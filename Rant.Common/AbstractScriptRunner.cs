using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rant.Common
{
    /// <summary>
    /// Abstract script runner.
    /// </summary>
    public abstract class AbstractScriptRunner : IScriptRunner
    {
        private IScriptExecutionContext context;

        public AbstractScriptRunner(IScriptExecutionContext context)
        {
            this.context = context;
        }

        public virtual IScriptExecutionContext Context
        {
            get { return context; }
            set { context = value; }
        }

        public abstract bool ScriptStarting(IScript script);

        public virtual void ScriptFinished(IScript script, bool withErrors)
        {
        }

        public virtual void ScriptError(IScript script, Exception exception)
        {
        }

        public virtual void BeforeStepRun(Step step)
        {
        }

        public abstract bool StepRun(Step step);

        public virtual void AfterStepRun(Step step, bool withError)
        {
        }

        public virtual void StepError(Step step, Exception exception)
        {
        }

        public virtual bool AskConfirmation(string item)
        {
            return true;
        }

        public abstract object RequestInput(string prompt);

        public virtual object RequestInput(string prompt, object defaultValue)
        {
            try
            {
                object value = RequestInput(prompt);
                return (value == null) ? defaultValue : value;
            }
            catch 
            {
                return defaultValue;
            }
        }
    }
}
