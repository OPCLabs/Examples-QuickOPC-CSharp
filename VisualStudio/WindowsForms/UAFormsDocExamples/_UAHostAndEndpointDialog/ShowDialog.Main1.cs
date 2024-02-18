// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable PossibleNullReferenceException
// ReSharper disable StringLiteralTypo
#region Example
// This example shows how to let the user browse for a host (computer) and an endpoint of an OPC-UA server residing on it.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System.Windows.Forms;
using OpcLabs.EasyOpc.UA.Forms.Browsing;

namespace UAFormsDocExamples._UAHostAndEndpointDialog
{
    static class ShowDialog
    {
        public static void Main1(IWin32Window owner)
        {
            var hostAndEndpointDialog = new UAHostAndEndpointDialog
            {
                EndpointDescriptor = {Host = "opcua.demo-this.com"}
            };

            DialogResult dialogResult = hostAndEndpointDialog.ShowDialog(owner);
            if (dialogResult != DialogResult.OK)
                return;

            // Display results
            MessageBox.Show(owner, 
                $"HostElement: {hostAndEndpointDialog.HostElement}\r\n" +
                $"DiscoveryElement: {hostAndEndpointDialog.DiscoveryElement}");
        }
    }
}
#endregion
