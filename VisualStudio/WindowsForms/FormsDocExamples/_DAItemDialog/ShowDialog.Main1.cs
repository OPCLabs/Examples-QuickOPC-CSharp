// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

#region Example
// This example shows how to let the user browse for an OPC Data Access item. 
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System.Windows.Forms;
using OpcLabs.EasyOpc.DataAccess.Forms.Browsing;

namespace FormsDocExamples._DAItemDialog
{
    static class ShowDialog
    {
        public static void Main1(IWin32Window owner)
        {
            var itemDialog = new DAItemDialog
            {
                ServerDescriptor = {ServerClass = "OPCLabs.KitServer.2"}
            };

            DialogResult dialogResult = itemDialog.ShowDialog(owner);
            if (dialogResult != DialogResult.OK)
                return;

            // Display results
            MessageBox.Show(owner, $"NodeElement: {itemDialog.NodeElement}");
        }
    }
}
#endregion
