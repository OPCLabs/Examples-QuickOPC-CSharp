// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable ArrangeModifiersOrder
// ReSharper disable InconsistentNaming
// ReSharper disable StringLiteralTypo

//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.Discovery;
using OpcLabs.EasyOpc.UA.OperationModel;

namespace UADiscoverServersWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        // Use a shared client instance to allow for better optimization.
        static private readonly EasyUAClient Client = new EasyUAClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UADiscoveryElementCollection discoveryElements = Client.DiscoverLocalServers("opcua.demo-this.com");
                foreach (UADiscoveryElement discoveryElement in discoveryElements)
                    ListBox1.Items.Add(discoveryElement.ToString());
                ListBox1.Visible = true;
            }
            catch (UAException ex)
            {
                TextBox1.Text = ex.GetBaseException().Message;
                TextBox1.Visible = true;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Load += Page_Load;
        }
    }
}