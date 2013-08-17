using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rant.Common
{
    /// <summary>
    /// Task interface.
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// Name of this task.
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Parameters this task needs to be properly executed.
        /// </summary>
        IDictionary<String, String> Parameters { get; }
        
        /// <summary>
        /// Executes this task.
        /// </summary>
        void Execute(IScriptExecutionContext context);

        /// <summary>
        /// Gives a task the ability to set its first parameter's value.
        /// </summary>
        string FirstParameter { get; set; }
    }
}
