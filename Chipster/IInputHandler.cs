using System.Windows.Forms;

namespace Chipster
{   /// <summary>
    /// Interface used for classes wishing to implement input
    /// </summary>
    interface IInputHandler
    {
        void GetKeyCode(Keys k, out byte? b);
    }
}
