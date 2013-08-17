using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rant.Common
{
    /// <summary>
    /// Script runner interface.
    /// </summary>
    public interface IScriptRunner
    {
        /// <summary>
        /// Script execution context.
        /// </summary>
        IScriptExecutionContext Context { get; set;  }

        /// <summary>
        /// Asks this script runner to begin executing a script.
        /// </summary>
        bool ScriptStarting(IScript script);

        /// <summary>
        /// Tells this script runner a script has finished its execution.
        /// </summary>
        void ScriptFinished(IScript script, bool withErrors);

        /// <summary>
        /// Signals an exception has ocurred executin this script.
        /// </summary>
        void ScriptError(IScript script, Exception exception);

        /// <summary>
        /// Tells this script runner a step it's about to being executed.
        /// </summary>
        void BeforeStepRun(Step step);

        /// <summary>
        /// Asks this script runner to execute a script's step.
        /// </summary>
        bool StepRun(Step step);

        /// <summary>
        /// Tells this script runner a step has been executed.
        /// </summary>
        void AfterStepRun(Step step, bool withError);

        /// <summary>
        /// Tells this script runner a error has ocurred while a step was being executed.
        /// </summary>
        void StepError(Step step, Exception exception);

        /// <summary>
        /// Ask confirmation on a certain proposition to the environment of this script runner.
        /// </summary>
        bool AskConfirmation(string item);

        /// <summary>
        /// Request the "client" (usually a human interacting with this API by means of an interactive script runner)
        /// to provide some data.
        /// </summary>
        object RequestInput(String prompt);

        /// <summary>
        /// Request the "client" (usually a human interacting with this API by means of an interactive script runner)
        /// to provide some data.
        /// </summary>
        object RequestInput(String prompt, object defaultValue);

    }
}
