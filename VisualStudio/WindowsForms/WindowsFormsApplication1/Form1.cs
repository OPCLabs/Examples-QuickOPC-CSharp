// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable NotNullMemberIsNotInitialized

//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using System.Windows.Forms;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.OperationModel;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                object value = easyDAClient1.ReadItemValue("", "OPCLabs.KitServer.2", "Demo.Single");
                textBox1.Text = value?.ToString() ?? "";
            }
            catch (OpcException opcException)
            {
                textBox1.Text = $"*** {opcException.Message}";
            }
        }
    }
}
