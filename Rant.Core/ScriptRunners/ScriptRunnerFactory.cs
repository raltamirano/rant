using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;
using Rant.Core.ScriptRunners;
using Rant.Core.ScriptExecutionContexts;
using Rant.Core.ScriptRunners.Decorators;

namespace Rant.Core.ScriptRunners
{
    public class ScriptRunnerFactory
    {
        private static readonly ScriptRunnerFactory instance = new ScriptRunnerFactory();

        private ScriptRunnerFactory()
        {

        }

        public static ScriptRunnerFactory Instance 
        {
            get { return instance; }
        }

        public IScriptRunner GetDefaultScriptRunner()
        {
            IScriptRunner scriptRunner = new DefaultScriptRunner(ScriptExecutionContextFactory.Instance.GetDefaultScriptExecutionContext());

            // Apply the context-to-parameter decorator: it replaces variable placeholders in 
            // every step' paramters with values from the script runner's context.
            scriptRunner = new ContextToParameterDecorator(scriptRunner);

            return scriptRunner;
        }
    }
}
