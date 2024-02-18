﻿// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable ArrangeModifiersOrder
// ReSharper disable InconsistentNaming

//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using OpcLabs.EasyOpc.UA;
using System;

namespace UAWebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        // Use a shared client instance to allow for better optimization.
        static private readonly EasyUAClient Client = new EasyUAClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            UAEndpointDescriptor endpointDescriptor =
                "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer";
            // or "http://opcua.demo-this.com:51211/UA/SampleServer" (currently not supported)
            // or "https://opcua.demo-this.com:51212/UA/SampleServer/"

            TextBox1.Text = Client.ReadValue(endpointDescriptor, "nsu=http://test.org/UA/Data/ ;i=10853")?.ToString();
        }
    }
}
