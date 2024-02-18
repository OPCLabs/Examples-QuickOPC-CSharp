// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable StringLiteralTypo
#region Example
// This example shows how to let the user browse for multiple OPC-UA nodes.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System.Windows.Forms;
using OpcLabs.EasyOpc.UA.Forms.Browsing;

namespace UAFormsDocExamples._UABrowseDialog
{
    static partial class ShowDialog
    {
        public static void MultiSelect(IWin32Window owner)
        {
            var browseDialog = new UABrowseDialog();
            browseDialog.InputsOutputs.CurrentNodeDescriptor.EndpointDescriptor.Host = "opcua.demo-this.com";
            browseDialog.Mode.AnchorElementType = UAElementType.Host;
            browseDialog.Mode.MultiSelect = true;

            DialogResult dialogResult = browseDialog.ShowDialog(owner);
            if (dialogResult != DialogResult.OK)
                return;

            // Display results
            UABrowseNodeElementCollection selectionElements = browseDialog.Outputs.SelectionElements;
            string text = "";
            for (int i = 0; i < selectionElements.Count; i++)
            {
                UABrowseNodeElement selectionElement = selectionElements[i];
                text += $"SelectionElements({i}): {selectionElement.NodeElement}\r\n";
            }
            MessageBox.Show(owner, text);
        }
    }
}
#endregion
