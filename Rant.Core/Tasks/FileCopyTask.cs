using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;
using System.IO;

namespace Rant.Core.Tasks
{
    /// <summary>
    /// File copy task.
    /// </summary>
    public class FileCopyTask : AbstractTask
    {
        private const String TASK_NAME = "FileCopy";

        public FileCopyTask() : base(TASK_NAME) { }
        public FileCopyTask(IDictionary<String, String> parameters) : base(TASK_NAME, parameters) { }

        public override void Execute(IScriptExecutionContext context)
        {
            FileInfo sourceFile = new FileInfo(Parameters["source"]);
            FileInfo target = new FileInfo(Parameters["target"]);
            bool targetIsDirectory = Boolean.Parse(Parameters["targetIsDirectory"]);
            bool overwriteTarget = Parameters.ContainsKey("overwrite") ? Boolean.Parse(Parameters["overwrite"]) : false;

            if (!sourceFile.Exists)
                throw new Exception(String.Format("Source file '{0}' does not exists!", sourceFile.FullName));

            if (IsDirectory(sourceFile))
                throw new Exception(String.Format("Source file '{0}' points to a directory and should point to a file instead!", sourceFile.FullName));

            if (targetIsDirectory)
            {
                if (!target.Exists)
                    Directory.CreateDirectory(target.FullName);

                target = new FileInfo(Path.Combine(target.FullName, Path.GetFileName(sourceFile.FullName)));
            }
            else 
            {
                if (!Directory.Exists(Path.GetDirectoryName(target.FullName)))
                    Directory.CreateDirectory(Path.GetDirectoryName(target.FullName));
            }

            if (target.Exists && !overwriteTarget)
                throw new Exception(String.Format("Target '{0}' already exists and overwrite was not requested!", target.FullName));
            
            File.Copy(sourceFile.FullName, target.FullName, overwriteTarget);
        }

        private static bool IsDirectory(FileInfo sourceFile)
        {
            return (sourceFile.Attributes & FileAttributes.Directory) == FileAttributes.Directory;
        }
    }
}
