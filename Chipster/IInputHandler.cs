using System.Windows.Forms;

namespace Chipster
{   /// <summary>
    /// Interface used for classes wishing to implement input
    /// </summary>
    interface IInputHandler
    {
        byte? GetKeyCode(Keys k);
    }
}
