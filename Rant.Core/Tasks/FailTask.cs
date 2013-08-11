using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;

namespace Rant.Core.Tasks
{
    /// <summary>
    /// Generates an exception given a error message/reason.
    /// </summary>
    public class FailTask : AbstractTask
    {
        private const String TASK_NAME = "Fail";
        private const String FIRST_PARAMETER_NAME = "message";

        public FailTask() : base(TASK_NAME) { base.firstParameterName = FIRST_PARAMETER_NAME; }
        public FailTask(IDictionary<String, String> parameters) : base(TASK_NAME, parameters) { base.firstParameterName = FIRST_PARAMETER_NAME; }

        public override void Execute()
        {
            throw new Exception(FirstParameter);
        }
    }
}
