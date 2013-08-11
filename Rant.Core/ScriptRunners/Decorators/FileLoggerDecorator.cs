using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;
using System.IO;

namespace Rant.Core.ScriptRunners.Decorators
{
    /// <summary>
    /// Logs every phase/event a script runner handles to a file.
    /// </summary>
    public class FileLoggerDecorator : IScriptRunnerDecorator
    {
        private readonly bool newFileOnScriptStart;
        private readonly IScriptRunner scriptRunner;
        private readonly FileInfo logDirectory;
        private StreamWriter logFile;
        
        public FileLoggerDecorator(IScriptRunner scriptRunner, FileInfo logDirectory, bool newFileOnScriptStart)
        {
            this.scriptRunner = scriptRunner;
            this.logDirectory = logDirectory;
            this.newFileOnScriptStart = newFileOnScriptStart;
        }

        public bool ScriptStarting(IScript script)
        {
            try
            {
                if (logFile != null && newFileOnScriptStart)
                {
                    closeLogFile();
                }

                if (logFile == null)
                {
                    String logFilename = Path.Combine(logDirectory.FullName, String.Format("{0}-script-run-{1}.log",
                        script.Name, DateTime.Now.ToString("yyyyMMddHHmmssfff")));

                    logFile = File.CreateText(logFilename);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(String.Format("Could not setup logging file. Exception: {0}", e));
            }

            log(String.Format("Script '{0}' starting...", script.Name));
            
            return scriptRunner.ScriptStarting(script);
        }

        public void ScriptFinished(IScript script, bool withErrors)
        {
            scriptRunner.ScriptFinished(script, withErrors);

            try
            {
                if (withErrors)
                    log(String.Format("Script '{0}' finished WITH ERRORS.", script.Name));
                else
                    log(String.Format("Script '{0}' finished OK.", script.Name));
                    
                if (newFileOnScriptStart)
                    closeLogFile();
            }
            catch 
            {
                // Do nothing.
            }
        }

        public void ScriptError(IScript script, Exception exception)
        {
            scriptRunner.ScriptError(script, exception);

            log(String.Format("Error on script execution: {0}", exception));
        }

        public void BeforeStepRun(Step step)
        {
            scriptRunner.BeforeStepRun(step);

            log(String.Format("About to execute step '{0}'.", step.Name));
        }

        public bool StepRun(Step step)
        {
            bool stepExecuted = scriptRunner.StepRun(step);

            if (stepExecuted)
                log(String.Format("Script runner decided to execute step '{0}'.", step.Name));
            else
                log(String.Format("Script runner decided NOT to execute step '{0}'.", step.Name));

            return stepExecuted;
        }

        public void AfterStepRun(Step step, bool withError)
        {
            scriptRunner.AfterStepRun(step, withError);

            if (withError)
                log(String.Format("Step '{0}' finished, but an error ocurred.", step.Name));
            else
                log(String.Format("Step '{0}' finished.", step.Name));
        }

        public void StepError(Step step, Exception exception)
        {
            scriptRunner.StepError(step, exception);

            log(String.Format("Error executing step '{0}': {1}", step.Name, exception));
        }

        public bool AskConfirmation(string item)
        {
            return scriptRunner.AskConfirmation(item);
        }

        private void log(string text)
        {
            if (logFile == null) return;

            try
            {
                logFile.WriteLine(String.Format("{0} - {1}", 
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), text));
            }
            catch
            {
                // Do nothing.
            }
        }

        private void closeLogFile()
        {
            logFile.Flush();
            logFile.Close();
            logFile = null;
        }
    }
}
