using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;
using Rant.Core.Tasks;

namespace Rant.Core.Tasks
{
    /// <summary>
    /// Task factory.
    /// </summary>
    public class TaskFactory
    {
        private readonly ITask dumpEnvironmentTask;

        #region Singleton
        
        private readonly static TaskFactory instance = new TaskFactory();

        private TaskFactory()
        {
            dumpEnvironmentTask = CreateTask(BuiltinTasks.DumpEnvironment.ToString());
        }

        public static TaskFactory Instance
        {
            get { return instance; }
        }

        #endregion
        
        public ITask CreateTask(String taskName)
        {
            ITask task = null;
            taskName = taskName.ToLower().Trim();

            if (taskName == BuiltinTasks.Echo.ToString().ToLower())
                task = new EchoTask();
            else if (taskName == BuiltinTasks.Fail.ToString().ToLower())
                task = new FailTask();
            else if (taskName == BuiltinTasks.DumpEnvironment.ToString().ToLower())
                task = new DumpEnvironmentTask();
            else
                throw new NotImplementedException("No generic task instantiation process yet!");

            if (task == null)
                throw new Exception("Could not get an implementation for task '" + taskName + "'");

            return task;
        }

        public ITask CreateTask(String taskName, IDictionary<String, String> parameters) 
        {
            ITask task = CreateTask(taskName);

            if (parameters != null)
                foreach (String key in parameters.Keys)
                    task.Parameters.Add(key, parameters[key]);

            return task;
        }

        public ITask CreateTask(String taskName, String firstParameter)
        {
            ITask task = CreateTask(taskName);
            
            task.FirstParameter = firstParameter;

            return task;
        }

        #region Built-in tasks

        public ITask Echo(String message)
        {
            return CreateTask(BuiltinTasks.Echo.ToString(), message);
        }

        public ITask Fail(String message)
        {
            return CreateTask(BuiltinTasks.Fail.ToString(), message);
        }
        
        public ITask DumpEnvironment()
        {
            return dumpEnvironmentTask;
        }

        #endregion
    }

    /// <summary>
    /// Built-in tasks.
    /// </summary>
    enum BuiltinTasks 
    {
        /// <summary>
        /// Outputs a message to stdout.
        /// </summary>
        Echo,

        /// <summary>
        /// Throws an exception with a given reason/message.
        /// </summary>
        Fail,

        /// <summary>
        /// Prints all environment variables to stdout.
        /// </summary>
        DumpEnvironment
    }
}
