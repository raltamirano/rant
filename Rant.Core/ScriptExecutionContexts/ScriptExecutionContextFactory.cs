using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;

namespace Rant.Core.ScriptExecutionContexts
{
    public class ScriptExecutionContextFactory
    {
        private static readonly ScriptExecutionContextFactory instance = new ScriptExecutionContextFactory();

        private ScriptExecutionContextFactory()
        {

        }

        public static ScriptExecutionContextFactory Instance
        {
            get { return instance; }
        }

        public IScriptExecutionContext GetDefaultScriptExecutionContext()
        {
            return new DefaultScriptExecutionContext();
        }
    }
}
