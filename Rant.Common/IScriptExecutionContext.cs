using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rant.Common
{
    /// <summary>
    /// Script execution context interface.
    /// </summary>
    public interface IScriptExecutionContext
    {
        /// <summary>
        /// Sets a variable's value for this context.
        /// </summary>
        void SetVariable<T>(String name, T value);

        /// <summary>
        /// Retries the value of a variable in this context.
        /// </summary>
        T GetVariable<T>(String name);
    }
}
