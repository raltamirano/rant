using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rant.Common
{
    /// <summary>
    /// A single step to be performed in a script.
    /// </summary>
    public class Step
    {
        private readonly IScript script;
        private readonly String name;
        private readonly String description;
        private readonly bool required;
        private readonly ITask task;

        private Step(IScript script, String name, String description, ITask task, bool required)
        {
            this.script = script;
            this.name = name;            
            this.description = description;
            this.required = required;
            this.task = task;            
        }

        public static Step Create(IScript script, String name, String description, ITask task, bool required) 
        {
            return new Step(script, name, description, task, required);
        }

        public IScript Script
        {
            get { return script; }
        }

        public String Name
        {
            get { return name; }
        }

        public String Description
        {
            get { return description; }
        }

        public ITask Task
        {
            get { return task; }
        }

        public bool Required
        {
            get { return required; }
        }

        public void Execute()
        {
            task.Execute();
        }
    }
}
