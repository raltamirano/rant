using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;
using System.Collections;

namespace Rant.Core.ScriptExecutionContexts
{
    /// <summary>
    /// Default script execution context. This script execution context is automatically initializated with a copy of the
    /// container process' environment variables.
    /// </summary>
    public class DefaultScriptExecutionContext : AbstractScriptExecutionContext
    {
        public DefaultScriptExecutionContext() 
            : base()
        {
            IDictionary environment = Environment.GetEnvironmentVariables();
            foreach (Object key in environment.Keys)
                base.SetVariable<String>(key.ToString(), environment[key] != null ? environment[key].ToString() : null);
        }
    }
}
