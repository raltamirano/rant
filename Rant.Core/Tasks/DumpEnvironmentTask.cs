using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;
using System.Collections;

namespace Rant.Core.Tasks
{
    /// <summary>
    /// Dumps all environment variables to stdout.
    /// </summary>
    public class DumpEnvironmentTask : AbstractTask
    {
        private const String TASK_NAME = "DumpEnvironment";

        public DumpEnvironmentTask() : base(TASK_NAME) { }
        public DumpEnvironmentTask(IDictionary<String, String> parameters) : base(TASK_NAME, parameters) { }

        public override void Execute(IScriptExecutionContext context)
        {
            IDictionary environment = Environment.GetEnvironmentVariables();
            foreach (Object key in environment.Keys)
            {
                Console.WriteLine(String.Format("{0} => {1}", key, environment[key]));
            }
        }
    }
}
