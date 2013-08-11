using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rant.Common
{
    /// <summary>
    /// Script reader interface.
    /// </summary>
    public interface IScriptReader
    {
        /// <summary>
        /// Reads the next available script.
        /// </summary>
        IScript Read();
    }
}
