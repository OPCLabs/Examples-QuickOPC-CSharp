// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System.Windows;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.OperationModel;

namespace UAWpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow/* : Window*/
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var client = new EasyUAClient();
            try
            {
                object value = client.ReadValue(
                    "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer",
                    "nsu=http://test.org/UA/Data/ ;i=10853");
                TextBox1.Text = value?.ToString() ?? "";
            }
            catch (UAException uaException)
            {
                TextBox1.Text = $"*** {uaException}";
            }
        }
    }
}
