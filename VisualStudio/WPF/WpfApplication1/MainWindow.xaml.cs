﻿// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System.Windows;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.OperationModel;

namespace WpfApplication1
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
            var client = new EasyDAClient();
            try
            {
                var value = client.ReadItemValue("", "OPCLabs.KitServer.2", "Demo.Single");
                TextBox1.Text = value?.ToString() ?? "";
            }
            catch (OpcException opcException)
            {
                TextBox1.Text = $"*** {opcException}";
            }
        }
    }
}
