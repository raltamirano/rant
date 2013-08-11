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
        public override bool ScriptStarting(IScript script)
        {
            return true;
        }

        public override bool StepRun(Step step)
        {
            step.Execute();

            return true;
        }
    }
}
