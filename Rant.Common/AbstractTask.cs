using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rant.Common
{
    /// <summary>
    /// Supportive class to define new tasks.
    /// </summary>
    public abstract class AbstractTask : ITask
    {
        private readonly String name;
        private readonly IDictionary<String, String> parameters;
        protected String firstParameterName = "$$FIRST_PARAMETER$$";

        public AbstractTask(String name)
        {
            this.name = name;
            this.parameters = new Dictionary<String, String>();
        }

        public AbstractTask(String name, IDictionary<String, String> parameters)
        {
            this.name = name;
            this.parameters = new Dictionary<String, String>(parameters);
        }

        public String Name 
        {
            get { return name; }
        }

        public IDictionary<String, String> Parameters
        {
            get { return parameters; }
        }

        public string FirstParameter
        {
            get { return Parameters[FirstParameterName]; }
            set { Parameters[FirstParameterName] = value; }
        }

        public String FirstParameterName
        {
            get { return firstParameterName; }
        }

        public abstract void Execute(IScriptExecutionContext context);
    }
}
