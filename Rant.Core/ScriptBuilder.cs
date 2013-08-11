using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;

namespace Rant.Core
{
    /// <summary>
    /// Script builder. This builder uses a "fluent-interface" for easy usage.
    /// </summary>
    public class ScriptBuilder
    {
        private IScript script;

        private ScriptBuilder()
        {            
        }

        public static ScriptBuilder Create()
        {
            return new ScriptBuilder();
        }

        public ScriptBuilder Initialize(String name, String description)
        {
            //TODO: Should we use an 'IScriptFactory' here?
            script = new Script(name, description);
            return this;
        }

        public ScriptBuilder AddStep(String name, ITask task, bool required)
        {
            return AddStep(name, null, task, required);
        }

        public ScriptBuilder AddStep(String name, String description, ITask task, bool required)
        {
            script.AddStep(name, description, task, required);
            return this;
        }

        public ScriptBuilder RegisterScriptStartingHandler(Delegates.ScriptEvent handler)
        {
            script.ScriptStarting += handler;
            return this;
        }

        public ScriptBuilder RegisterScriptFinishedHandler(Delegates.ScriptFinishedEvent handler)
        {
            script.ScriptFinished += handler;
            return this;
        }

        public ScriptBuilder RegisterScriptErrorHandler(Delegates.ScriptError handler)
        {
            script.ScriptError += handler;
            return this;
        }

        public ScriptBuilder RegisterStepStartingHandler(Delegates.ScriptStepEvent handler)
        {
            script.StepStarting += handler;
            return this;
        }

        public ScriptBuilder RegisterStepSkippedHandler(Delegates.ScriptStepEvent handler)
        {
            script.StepSkipped += handler;
            return this;
        }

        public ScriptBuilder RegisterStepFinishedHandler(Delegates.ScriptStepEvent handler)
        {
            script.StepFinished += handler;
            return this;
        }

        public ScriptBuilder RegisterStepErrorHandler(Delegates.ScriptStepError handler)
        {
            script.StepError += handler;
            return this;
        }
        
        public IScript Build()
        {
            return script;
        }
    }
}
