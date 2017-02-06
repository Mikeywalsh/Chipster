using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipster
{   /// <summary>
    /// Interface used for classes wishing to implement input
    /// </summary>
    interface IInputHandler
    {
        byte? GetPressedKeyValue();
    }
}
