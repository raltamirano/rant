using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;

namespace Rant.Core.ScriptRunners
{
    /// <summary>
    /// Trivial script runner implementation: It simply executes every step handled to run.
    /// </summary>
    public class DefaultScriptRunner : AbstractScriptRunner
    {
        public DefaultScriptRunner(IScriptExecutionContext context) :
            base(context)
        {

        }

        public override bool ScriptStarting(IScript script)
        {
            return true;
        }

        public override bool StepRun(Step step)
        {
            step.Execute(Context);
            
            return true;
        }

        public override object RequestInput(string prompt)
        {
            return null;
        }

    }
}
