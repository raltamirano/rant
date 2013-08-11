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
        public abstract bool ScriptStarting(IScript script);

        public void ScriptFinished(IScript script, bool withErrors)
        {
        }

        public void ScriptError(IScript script, Exception exception)
        {
        }
        
        public void BeforeStepRun(Step step)
        {
        }

        public abstract bool StepRun(Step step);

        public void AfterStepRun(Step step, bool withError)
        {
        }

        public void StepError(Step step, Exception exception)
        {
        }

        public bool AskConfirmation(string item)
        {
            return true;
        }
    }
}
