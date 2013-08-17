using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rant.Common
{
    /// <summary>
    /// Abstract script execution context.
    /// </summary>
    public abstract class AbstractScriptExecutionContext : IScriptExecutionContext 
    {
        private IDictionary<String, Object> variables = new Dictionary<String, Object>();        

        public void SetVariable<T>(string name, T value)
        {
            variables[name] = value;
        }

        public T GetVariable<T>(string name)
        {
            return (T)(variables.ContainsKey(name) ? variables[name] : null);
        }
    }
}
