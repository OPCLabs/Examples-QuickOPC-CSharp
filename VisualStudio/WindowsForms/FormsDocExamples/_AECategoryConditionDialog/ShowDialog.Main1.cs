// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

#region Example
// This example shows how to let the user browse for an OPC Alarms&Events condition available on a specified event category.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System.Windows.Forms;
using OpcLabs.EasyOpc.AlarmsAndEvents.Forms.Browsing;

namespace FormsDocExamples._AECategoryConditionDialog
{
    static class ShowDialog
    {
        public static void Main1(IWin32Window owner)
        {
            var categoryConditionDialog = new AECategoryConditionDialog()
            {
                ServerDescriptor = {ServerClass = "OPCLabs.KitEventServer.2"},
                CategoryId = 0x00EC0002  // Deviation
            };

            DialogResult dialogResult = categoryConditionDialog.ShowDialog(owner);
            if (dialogResult != DialogResult.OK)
                return;

            // Display results
            MessageBox.Show(owner, $"ConditionElement: {categoryConditionDialog.ConditionElement}");
        }
    }
}
#endregion
