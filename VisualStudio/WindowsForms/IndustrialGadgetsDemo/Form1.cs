
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System.Diagnostics;
using System.Windows.Forms;

namespace IndustrialGadgetsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ReSharper disable InconsistentNaming
        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            Debug.Assert(e != null);
            Process.Start(e.LinkText);
        }
    }
}
