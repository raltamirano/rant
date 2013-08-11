using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rant.Common
{
    public class Delegates 
    {
        public delegate void ScriptEvent(IScript script);
        public delegate void ScriptFinishedEvent(IScript script, bool withErrors);
        public delegate void ScriptError(IScript script, Exception exception);
        public delegate void ScriptStepEvent(Step step);
        public delegate void ScriptStepError(Step step, Exception exception);
    }
}
