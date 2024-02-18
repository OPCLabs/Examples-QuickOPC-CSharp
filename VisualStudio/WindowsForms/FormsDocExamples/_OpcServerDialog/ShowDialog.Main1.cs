// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

#region Example
// This example shows how to let the user browse for an OPC "Classic" server.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System.Windows.Forms;
using OpcLabs.EasyOpc.Forms.Browsing;

namespace FormsDocExamples._OpcServerDialog
{
    static class ShowDialog
    {
        public static void Main1(IWin32Window owner)
        {
            var serverDialog = new OpcServerDialog();
            //serverDialog.Location = "";

            DialogResult dialogResult = serverDialog.ShowDialog(owner);
            if (dialogResult != DialogResult.OK)
                return;

            // Display results
            MessageBox.Show(owner, serverDialog.ServerElement);
        }
    }
}
#endregion
