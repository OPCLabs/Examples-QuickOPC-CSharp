﻿// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

#region Example
// This example shows how to let the user browse for OPC Alarms&Events categories. 
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System.Linq;
using System.Windows.Forms;
using OpcLabs.EasyOpc.AlarmsAndEvents.Forms.Browsing;

namespace FormsDocExamples._AECategoryDialog
{
    static class ShowDialog
    {
        public static void Main1(IWin32Window owner)
        {
            var categoryDialog = new AECategoryDialog
            {
                ServerDescriptor = {ServerClass = "OPCLabs.KitEventServer.2"}
            };

            DialogResult dialogResult = categoryDialog.ShowDialog(owner);
            if (dialogResult != DialogResult.OK)
                return;

            // Display results
            string categoryElementsString = string.Join("\n", categoryDialog.CategoryElements.Select(element => element));
            MessageBox.Show(owner, categoryElementsString);
        }
    }
}
#endregion
