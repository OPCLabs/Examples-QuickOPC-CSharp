// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

#region Example
// This example shows how to let the user browse for an OPC Alarms&Events attribute.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System.Windows.Forms;
using OpcLabs.EasyOpc.AlarmsAndEvents.Forms.Browsing;

namespace FormsDocExamples._AEAttributeDialog
{
    static class ShowDialog
    {
        public static void Main1(IWin32Window owner)
        {
            var attributeDialog = new AEAttributeDialog
            {
                ServerDescriptor = {ServerClass = "OPCLabs.KitEventServer.2"},
                CategoryId = 0x00EC0001
            };

            DialogResult dialogResult = attributeDialog.ShowDialog(owner);
            if (dialogResult != DialogResult.OK)
                return;

            // Display results
            MessageBox.Show(owner, $"AttributeElement: {attributeDialog.AttributeElement}");
        }
    }
}
#endregion
