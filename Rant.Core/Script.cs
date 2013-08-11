using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;
using Rant.Core.ScriptRunners;
using Rant.Common.Exceptions;

namespace Rant.Core
{
    /// <summary>
    /// RANT Script class. A script is a collection of configured steps to be executed in order to acomplish a certain goal. 
    /// A script implements <see cref="ITask" />, so a script could be used as a step on another script.
    /// </summary>
    public class Script : IScript
    {
        public event Delegates.ScriptEvent ScriptStarting;
        public event Delegates.ScriptFinishedEvent ScriptFinished;
        public event Delegates.ScriptError ScriptError;
        public event Delegates.ScriptStepEvent StepStarting;
        public event Delegates.ScriptStepEvent StepSkipped;
        public event Delegates.ScriptStepEvent StepFinished;
        public event Delegates.ScriptStepError StepError;

        private readonly String name;
        private readonly String description;
        private readonly IList<Step> steps;
        private readonly IDictionary<String, String> parameters;
        
        public Script(String name, String description)
        {
            this.name = name;
            this.description = description;
            this.steps = new List<Step>();
            this.parameters = new Dictionary<String, String>();
        }

        public String Name 
        {
            get { return name; }
        }

        public String Description
        {
            get { return description; }
        }

        public IDictionary<String, String> Parameters
        {
            get { return parameters; }
        }

        public Step AddStep(String name, String description, ITask task, bool required)
        {
            Step step = Step.Create(this, name, description, task, required);
            steps.Add(step);
            return step;
        }

        public void RemoveStep(Step step)
        {
            steps.Remove(step);
        }

        public string FirstParameter
        {
            get { return null; }
            set { /* Do nothing */ }
        }

        public void Execute()
        {
            Execute(ScriptRunnerFactory.Instance.GetDefaultScriptRunner());
        }
        
        public void Execute(IScriptRunner runner)
        {
            Step step = null;
            bool stepWithError = false;
            bool scriptWithErrors = false;

            try
            {
                if (!runner.ScriptStarting(this))
                    throw new Exception("Script runner decided NOT to start executing this script.");

                if (ScriptStarting != null)
                    ScriptStarting(this);

                for (int stepIndex = 0; stepIndex < steps.Count; stepIndex++)
                {
                    stepWithError = false;
                    step = steps[stepIndex];

                    try
                    {
                        runner.BeforeStepRun(step);

                        if (StepStarting != null)
                            StepStarting(step);

                        if (runner.StepRun(step))
                        {
                            if (StepFinished != null)
                                StepFinished(step);
                        }
                        else
                        {
                            if (StepSkipped != null)
                                StepSkipped(step);

                            if (step.Required)
                                throw new RequiredStepNotExecutedException(step);
                        }
                    }
                    catch (RequiredStepNotExecutedException requiredStepException) 
                    {
                        // Can't continue with script execution if a required step was not executed.
                        throw requiredStepException;
                    }
                    catch (Exception exception)
                    {
                        scriptWithErrors = true;

                        stepWithError = true;

                        runner.StepError(step, exception);

                        if (StepError != null)
                            StepError(step, exception);
                    }
                    finally
                    {
                        runner.AfterStepRun(step, stepWithError);
                    }
                }
            }
            catch (Exception exception)
            {
                scriptWithErrors = true;
                
                runner.ScriptError(this, exception);

                if (ScriptError != null)
                    ScriptError(this, exception);
            }
            finally
            {
                runner.ScriptFinished(this, scriptWithErrors);

                if (ScriptFinished != null)
                    ScriptFinished(this, scriptWithErrors);
            }
        }
    }
}
