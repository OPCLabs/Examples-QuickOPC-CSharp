
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System.Windows.Forms;
using OpcLabs.BaseLib.Runtime.InteropServices;

namespace LiveBindingDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]   // removed for COM security initialization to succeed
        static void Main()
        {
            ComManagement.Instance.AssureSecurityInitialization();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
