using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;
using Rant.Core.ScriptRunners;
using Rant.Common.Exceptions;
using System.Transactions;
using Rant.Core.ScriptExecutionContexts;

namespace Rant.Core
{
    /// <summary>
    /// RANT Script class. A script is a collection of configured steps to be executed in order to acomplish a certain goal. 
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
        private bool scriptWithErrors = false;
        
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

        public void Execute(IScriptRunner scriptRunner)
        {
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                internalExecution(scriptRunner);

                if (LastRunWasSuccessful) 
                    transaction.Complete();
            }
        }

        public bool LastRunWasSuccessful
        {
            get { return !scriptWithErrors; }
        }

        private void internalExecution(IScriptRunner scriptRunner)
        {
            Step step = null;
            bool stepWithError = false;
            
            scriptWithErrors = false;
            try
            {
                if (!scriptRunner.ScriptStarting(this))
                    throw new Exception("Script runner decided NOT to start executing this script.");

                if (ScriptStarting != null)
                    ScriptStarting(this);

                for (int stepIndex = 0; stepIndex < steps.Count; stepIndex++)
                {
                    stepWithError = false;
                    step = steps[stepIndex];

                    try
                    {
                        scriptRunner.BeforeStepRun(step);

                        if (StepStarting != null)
                            StepStarting(step);

                        if (scriptRunner.StepRun(step))
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
                    catch (RequiredStepNotExecutedException)
                    {
                        // Can't continue with script execution if a required step was not executed.
                        throw;
                    }
                    catch (Exception exception)
                    {
                        scriptWithErrors = true;

                        stepWithError = true;

                        scriptRunner.StepError(step, exception);

                        if (StepError != null)
                            StepError(step, exception);

                        if (step.Required)
                            throw new RequiredStepNotExecutedException(step);
                    }
                    finally
                    {
                        scriptRunner.AfterStepRun(step, stepWithError);
                    }
                }
            }
            catch (Exception exception)
            {
                scriptWithErrors = true;

                scriptRunner.ScriptError(this, exception);

                if (ScriptError != null)
                    ScriptError(this, exception);
            }
            finally
            {
                scriptRunner.ScriptFinished(this, scriptWithErrors);

                if (ScriptFinished != null)
                    ScriptFinished(this, scriptWithErrors);
            }        
        }
    }
}
