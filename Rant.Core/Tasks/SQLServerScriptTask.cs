using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace Rant.Core.Tasks
{
    /// <summary>
    /// SQL Server script task.
    /// </summary>
    public class SQLServerScriptTask : AbstractTask
    {
        private const String TASK_NAME = "SQLServerScript";
        private const String FIRST_PARAMETER_NAME = "script";

        public SQLServerScriptTask() : base(TASK_NAME) { base.firstParameterName = FIRST_PARAMETER_NAME; }
        public SQLServerScriptTask(IDictionary<String, String> parameters) : base(TASK_NAME, parameters) { base.firstParameterName = FIRST_PARAMETER_NAME; }

        public override void Execute(IScriptExecutionContext context)
        {
            // The script to be executed.
            String script = Parameters["script"];
            
            // Connection string to target DB
            String connectionString = Parameters["connectionString"];
            
            // Treat the 'script' parameter as a script containing the script to be executed or as the script itself.
            Boolean useAsFile = Parameters.ContainsKey("useAsFile") ? Boolean.Parse(Parameters["useAsFile"]) : false;
            
            // Expressed in seconds.
            int commandTimeout = Parameters.ContainsKey("timeout") ? Int32.Parse(Parameters["timeout"]) : 30;

            if (useAsFile)
                script = File.ReadAllText(script);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = script;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandTimeout = commandTimeout;

                    command.ExecuteNonQuery();
                }
            }
            
        }
    }
}
