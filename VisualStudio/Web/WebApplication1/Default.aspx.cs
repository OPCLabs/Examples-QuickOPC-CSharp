// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable ArrangeModifiersOrder
// ReSharper disable InconsistentNaming

//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using OpcLabs.EasyOpc.DataAccess;
using System;
using OpcLabs.EasyOpc.DataAccess.Extensions;
using OpcLabs.EasyOpc.OperationModel;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        static _Default()
        {
            // Enable auto-subscribing optimization (not necessary), which can improve performance with repeated Read requests.
            Client.TryEnableAutoSubscribingOptimization();
        }

        // Use a shared client instance to allow for better optimization.
        static private readonly EasyDAClient Client = new EasyDAClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                object value = Client.ReadItemValue("", "OPCLabs.KitServer.2", "Demo.Single");
                TextBox1.Text = value?.ToString() ?? "";
            }
            catch (OpcException opcException)
            {
                TextBox1.Text = $"*** {opcException.Message}";
            }
        }
    }
}
