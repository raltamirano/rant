using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;

namespace Rant.Core.Tasks
{
    /// <summary>
    /// Echoes a message to stdout.
    /// </summary>
    public class EchoTask : AbstractTask
    {
        private const String TASK_NAME = "Echo";
        private const String FIRST_PARAMETER_NAME = "message";

        public EchoTask() : base(TASK_NAME) { base.firstParameterName = FIRST_PARAMETER_NAME; }
        public EchoTask(IDictionary<String, String> parameters) : base(TASK_NAME, parameters) { base.firstParameterName = FIRST_PARAMETER_NAME; }

        public override void Execute()
        {
            Console.WriteLine(FirstParameter);
        }
    }
}
