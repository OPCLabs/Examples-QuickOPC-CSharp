// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using EasyOpcUADemo.Properties;
using JetBrains.Annotations;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.Forms.Application;
using OpcLabs.EasyOpc.UA.OperationModel;

// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable InconsistentNaming
// ReSharper disable NotNullMemberIsNotInitialized
// ReSharper disable PossibleNullReferenceException

[assembly:CLSCompliant(true)]
namespace EasyOpcUADemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            UAAttributeData attributeData = null;
            Exception exception = null;
            try
            {
                attributeData = easyUAClient1.Read(serverUriTextBox.Text, nodeIdTextBox.Text);
            }
            catch (UAException ex)
            {
                exception = ex;
            }
            DisplayAttributeData(attributeData);
            DisplayException(exception);
        }

        private void DisplayAttributeData(UAAttributeData attributeData)
        {
            if (attributeData is null)
            {
                valueTextBox.Text = "";
                statusTextBox.Text = "";
                sourceTimestampTextBox.Text = "";
                serverTimestampTextBox.Text = "";
            }
            else
            {
                valueTextBox.Text = attributeData.DisplayValue();
                statusTextBox.Text = attributeData.StatusCode.ToString();
                sourceTimestampTextBox.Text = attributeData.SourceTimestamp.ToString(CultureInfo.CurrentCulture);
                serverTimestampTextBox.Text = attributeData.ServerTimestamp.ToString(CultureInfo.CurrentCulture);
            }
        }

        private void DisplayException(Exception exception)
        {
            exceptionTextBox.Text = (exception is null) ? "" : exception.GetBaseException().Message;
        }

        private bool _isSubscribed/* = false*/;
        private int _handle/* = 0*/;

        public bool IsSubscribed
        {
            get { return _isSubscribed; }
            set 
            {
                _isSubscribed = value;
                subscribeMonitoredItemButton.Enabled = !_isSubscribed;
                changeMonitoredItemSubscriptionButton.Enabled = _isSubscribed;
                unsubscribeMonitoredItemButton.Enabled = _isSubscribed;
            }
        }

        private void subscribeButton_Click(object sender, EventArgs e)
        {
            _handle = easyUAClient1.SubscribeDataChange(serverUriTextBox.Text, nodeIdTextBox.Text,
                                                           (int)samplingIntervalNumericUpDown.Value);
            IsSubscribed = true;
        }

        private void changeSubscriptionButton_Click(object sender, EventArgs e)
        {
            easyUAClient1.ChangeMonitoredItemSubscription(_handle, (int)samplingIntervalNumericUpDown.Value);
        }

        private void unsubscribeButton_Click(object sender, EventArgs e)
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            easyUAClient1.UnsubscribeMonitoredItem(_handle);
            _handle = 0;
            IsSubscribed = false;
        }

        private void easyUAClient1_DataChangeNotification(object sender, EasyUADataChangeNotificationEventArgs e)
        {
            DisplayAttributeData((e.Exception is null) ? e.AttributeData : null);
            DisplayException(e.Exception);
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, Assembly.GetExecutingAssembly().FullName, Resources.MainForm_AssemblyName, 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (IsSubscribed)
                Unsubscribe();
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            EasyUAFormsApplication.Instance.AddToSystemMenu(this);
        }

        private void discoverServersButton_Click(object sender, EventArgs e)
        {
            uaHostAndEndpointDialog1.EndpointDescriptor = serverUriTextBox.Text;
            if (uaHostAndEndpointDialog1.ShowDialog() == DialogResult.OK)
                serverUriTextBox.Text = uaHostAndEndpointDialog1.EndpointDescriptor.UrlString;
        }

        private void browseDataButton_Click(object sender, EventArgs e)
        {
            uaDataDialog1.EndpointDescriptor = serverUriTextBox.Text;
            if (uaDataDialog1.ShowDialog() == DialogResult.OK)
                nodeIdTextBox.Text = uaDataDialog1.NodeDescriptor.NodeId;
        }

        private void writeValueButton_Click(object sender, EventArgs e)
        {
            Exception exception = null;
            try
            {
                easyUAClient1.WriteValue(serverUriTextBox.Text, nodeIdTextBox.Text, valueToWriteTextBox.Text);
            }
            catch (UAException ex)
            {
                exception = ex;
            }
            DisplayException(exception);
        }
    }
}
