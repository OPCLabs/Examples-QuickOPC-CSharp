// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using System.Windows.Forms;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.OperationModel;

namespace ValueToMessageBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create EasyOPC-DA component
            var client = new EasyDAClient();

            // Read item value and display it in a message box
            try
            {
                object value = client.ReadItemValue("", "OPCLabs.KitServer.2", "Demo.Single");
                MessageBox.Show(value?.ToString());
            }
            catch (OpcException opcException)
            {
                MessageBox.Show($"*** {opcException.Message}");
            }
        }
    }
}
