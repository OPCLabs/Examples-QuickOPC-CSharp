// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

#region Example
// This example shows how to let the user browse for an OPC Data Access node in a dialog.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System.Windows.Forms;
using OpcLabs.EasyOpc.Forms.Browsing;

namespace FormsDocExamples._OpcBrowseDialog
{
    static class ShowDialog
    {
        public static void Main1(IWin32Window owner)
        {
            var browseDialog = new OpcBrowseDialog();

            DialogResult dialogResult = browseDialog.ShowDialog(owner);
            if (dialogResult != DialogResult.OK)
                return;

            // Display results
            MessageBox.Show(owner, browseDialog.Outputs.CurrentNodeElement.DANodeElement);
        }
    }
}
#endregion
