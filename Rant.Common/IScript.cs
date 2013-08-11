using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rant.Common
{
    /// <summary>
    /// RANT Script interface. A script is a collection of configured steps to be executed in order to acomplish a certain goal. 
    /// A script implements <see cref="ITask" />, so a script could be used as a step on another script.
    /// </summary>
    public interface IScript : ITask
    {
        event Delegates.ScriptEvent ScriptStarting;
        event Delegates.ScriptFinishedEvent ScriptFinished;
        event Delegates.ScriptError ScriptError;
        event Delegates.ScriptStepEvent StepStarting;
        event Delegates.ScriptStepEvent StepSkipped;
        event Delegates.ScriptStepEvent StepFinished;
        event Delegates.ScriptStepError StepError;

        /// <summary>
        /// Script description.
        /// </summary>
        String Description { get; }
        
        /// <summary>
        /// Adds a step to this script.
        /// </summary>
        Step AddStep(String name, String description, ITask task, bool required);

        /// <summary>
        /// Removes a step from this script.
        /// </summary>
        void RemoveStep(Step step);

        /// <summary>
        /// Executes this script with a specific script runn
        /// </summary>
        /// <param name="runner"></param>
        void Execute(IScriptRunner runner);
    }
}
