using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rant.Common.Exceptions
{
    public class RequiredStepNotExecutedException : Exception
    {
        private readonly Step step;

        public RequiredStepNotExecutedException(Step step) 
            : base()
        {
            this.step = step;
        }

        public Step Step
        {
            get { return step; }
        }

        public override string Message
        {
            get
            {
                return String.Format("Required step '{0}' was NOT executed!", step.Name);
            }
        }
    }
}
