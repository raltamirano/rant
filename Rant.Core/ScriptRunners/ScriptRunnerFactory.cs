using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;
using Rant.Core.ScriptRunners;

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
            return new DefaultScriptRunner();
        }
    }
}
