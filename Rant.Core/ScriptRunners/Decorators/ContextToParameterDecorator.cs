using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;
using System.Text.RegularExpressions;

namespace Rant.Core.ScriptRunners.Decorators
{
    /// <summary>
    /// This decorator maps/replaces placeholders in the step's parameters with values from the script 
    /// runner's context BEFORE the step is actually executed.
    /// </summary>
    public class ContextToParameterDecorator : IScriptRunnerDecorator
    {
        private const String VARIABLE_PLACEHOLDER = @"\$\{\{(?<varName>.+)\}\}";
        
        private readonly IScriptRunner scriptRunner;

        public ContextToParameterDecorator(IScriptRunner scriptRunner)
        {
            this.scriptRunner = scriptRunner;
        }
        
        public IScriptExecutionContext Context
        {
            get { return scriptRunner.Context; }
            set { scriptRunner.Context = value; }
        }

        public bool ScriptStarting(IScript script)
        {
            return scriptRunner.ScriptStarting(script);
        }

        public void ScriptFinished(IScript script, bool withErrors)
        {
            scriptRunner.ScriptFinished(script, withErrors);
        }

        public void ScriptError(IScript script, Exception exception)
        {
            scriptRunner.ScriptError(script, exception);
        }

        public void BeforeStepRun(Step step)
        {
            IDictionary<String, String> replacements = new Dictionary<String, String>();
            foreach(String key in step.Task.Parameters.Keys) {
                String currentValue = step.Task.Parameters[key];
                if (currentValue != null)
                {
                    foreach (Match match in Regex.Matches(currentValue, VARIABLE_PLACEHOLDER))
                    {
                        String variableName = match.Groups["varName"].Value;
                        currentValue = currentValue.Replace("${{" + variableName + "}}", Context.GetVariable<Object>(variableName) != null ? Context.GetVariable<Object>(variableName).ToString() : "");
                    }

                    replacements.Add(key, currentValue);
                }
            }

            foreach(String key in replacements.Keys)
                step.Task.Parameters[key] = replacements[key];
            
            scriptRunner.BeforeStepRun(step);
        }

        public bool StepRun(Step step)
        {
            return scriptRunner.StepRun(step);
        }

        public void AfterStepRun(Step step, bool withError)
        {
            scriptRunner.AfterStepRun(step, withError);
        }

        public void StepError(Step step, Exception exception)
        {
            scriptRunner.StepError(step, exception);
        }

        public bool AskConfirmation(string item)
        {
            return scriptRunner.AskConfirmation(item);
        }

        public object RequestInput(string prompt)
        {
            return scriptRunner.RequestInput(prompt);
        }

        public object RequestInput(string prompt, object defaultValue)
        {
            return scriptRunner.RequestInput(prompt, defaultValue);
        }

    }
}
