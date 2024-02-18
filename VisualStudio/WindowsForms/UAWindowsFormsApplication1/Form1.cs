// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable NotNullMemberIsNotInitialized

//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using System.Windows.Forms;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.OperationModel;

namespace UAWindowsFormsApplication1
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
                object value = easyUAClient1.ReadValue(
                    "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer",
                    "nsu=http://test.org/UA/Data/ ;i=10853");
                textBox1.Text = value?.ToString() ?? "";
            }
            catch (UAException uaException)
            {
                textBox1.Text = $"*** {uaException.Message}";
            }
        }
    }
}
