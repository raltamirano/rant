using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;
using System.IO;
using System.Xml;
using Rant.Core.Tasks;

namespace Rant.Core.ScriptReaders
{
    /// <summary>
    /// File-based script reader.
    /// </summary>
    public class FileScriptReader : IScriptReader
    {
        private readonly FileInfo rantFile;

        public FileScriptReader(FileInfo rantFile)
        {
            this.rantFile = rantFile;
        }

        public IScript Read()
        {
            ScriptBuilder builder = ScriptBuilder.Create();

            XmlDocument xml = new XmlDocument();
            using (FileStream fileStream = new FileStream(rantFile.FullName, FileMode.Open))
            {
                xml.Load(fileStream);

                String scriptName = xml.DocumentElement.Attributes["name"].Value;
                String scriptDescription = xml.DocumentElement.SelectSingleNode("description/text()").Value;

                builder.Initialize(scriptName, scriptDescription);

                foreach (XmlNode stepNode in xml.DocumentElement.SelectNodes("steps/step"))
                {
                    String stepName = stepNode.Attributes["name"].Value;
                    String stepDescription = stepNode.SelectSingleNode("description/text()").Value;
                    String taskName = stepNode.Attributes["task"].Value;
                    bool required = Boolean.Parse(stepNode.Attributes["required"].Value);

                    // Read all parameters for this step
                    IDictionary<String, String> parameters = new Dictionary<String, String>();
                    foreach (XmlNode parameterNode in stepNode.SelectNodes("parameters/parameter"))
                        parameters.Add(parameterNode.Attributes["name"].Value, parameterNode.InnerText);

                    ITask task = TaskFactory.Instance.CreateTask(taskName, parameters);
                    builder.AddStep(stepName, stepDescription, task, required);
                }
            }

            return builder.Build();
        }
    }
}
