// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

#region Example
// This example shows how to let the user browse for computers on the network.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System.Windows.Forms;
using OpcLabs.BaseLib.Forms.Browsing.Specialized;

namespace FormsDocExamples._ComputerBrowserDialog
{
    static class ShowDialog
    {
        public static void Main1(IWin32Window owner)
        {
            var computerBrowserDialog = new ComputerBrowserDialog();

            DialogResult dialogResult = computerBrowserDialog.ShowDialog(owner);
            if (dialogResult != DialogResult.OK)
                return;

            // Display results
            MessageBox.Show(owner, computerBrowserDialog.SelectedName);
        }
    }
}
#endregion
