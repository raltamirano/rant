using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rant.Common;
using System.IO;

namespace Rant.Core.ScriptReaders
{
    /// <summary>
    /// Script Reader factory.
    /// </summary>
    public class ScriptReaderFactory
    {
        private readonly static ScriptReaderFactory instance = new ScriptReaderFactory();

        private ScriptReaderFactory()
        {
        }

        public static ScriptReaderFactory Instance
        {
            get { return instance; }
        }

        public IScriptReader CreateFileReader(String rantFile)
        {
            return CreateFileReader(new FileInfo(rantFile));
        }

        public IScriptReader CreateFileReader(FileInfo rantFile)
        {
            return new FileScriptReader(rantFile);
        }
    }
}
