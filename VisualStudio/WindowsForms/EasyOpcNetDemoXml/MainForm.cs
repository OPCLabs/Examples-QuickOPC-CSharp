// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System.Diagnostics;
using EasyOpcNetDemoXml.Properties;
using JetBrains.Annotations;
using OpcLabs.BaseLib.ComInterop;
using OpcLabs.EasyOpc.DataAccess;
using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using OpcLabs.EasyOpc.DataAccess.OperationModel;
using OpcLabs.EasyOpc.OperationModel;

[assembly:CLSCompliant(true)]
namespace EasyOpcNetDemoXml
{
    public partial class MainForm : Form
    {
        // ReSharper disable once NotNullMemberIsNotInitialized
        public MainForm()
        {
            InitializeComponent();
        }

        // ReSharper disable InconsistentNaming
        private void browseItemsButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            Debug.Assert(serverUrlTextBox.Text != null);
            Debug.Assert(daItemDialog1.NodeDescriptor != null);

            daItemDialog1.ServerDescriptor.UrlString = serverUrlTextBox.Text;
            daItemDialog1.NodeDescriptor.ItemId = itemIdTextBox.Text;
            daItemDialog1.NodeDescriptor.NodePath = nodePathTextBox.Text;
            if (daItemDialog1.ShowDialog() == DialogResult.OK)
            {
                Debug.Assert(daItemDialog1.NodeDescriptor != null);
                itemIdTextBox.Text = daItemDialog1.NodeDescriptor.ItemId;
                nodePathTextBox.Text = daItemDialog1.NodeDescriptor.NodePath;
            }
        }

        // ReSharper disable InconsistentNaming
        private void readItemButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            Debug.Assert(serverUrlTextBox.Text != null);
            Debug.Assert(itemIdTextBox.Text != null);

            DAVtq vtq = null;
            Exception exception = null;
            try
            {
                vtq = easyDAClient1.ReadItem(
                    serverUrlTextBox.Text,
                    new DAItemDescriptor(itemIdTextBox.Text) { NodePath = nodePathTextBox.Text });
            }
            catch (OpcException ex)
            {
                exception = ex;
            }
            DisplayVtq(vtq);
            DisplayException(exception);
        }

        private void DisplayVtq(DAVtq vtq)
        {
            if (vtq is null)
            {
                valueTextBox.Text = "";
                timestampTextBox.Text = "";
                qualityTextBox.Text = "";
            }
            else
            {
                valueTextBox.Text = vtq.DisplayValue(); 
                timestampTextBox.Text = vtq.Timestamp.ToString(CultureInfo.CurrentCulture);
                qualityTextBox.Text = vtq.Quality.ToString();
            }
        }

        private void DisplayException(Exception exception)
        {
            exceptionTextBox.Text = (exception is null) ? "" : exception.GetBaseException().Message;
        }

        private bool _isItemSubscribedValue/* = false*/;
        private int _itemHandle/* = 0*/;

        public bool IsItemSubscribed
        {
            get { return _isItemSubscribedValue; }
            set 
            {
                _isItemSubscribedValue = value;
                subscribeItemButton.Enabled = !_isItemSubscribedValue;
                changeItemSubscriptionButton.Enabled = _isItemSubscribedValue;
                unsubscribeItemButton.Enabled = _isItemSubscribedValue;
            }
        }

        // ReSharper disable InconsistentNaming
        private void subscribeItemButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            Debug.Assert(serverUrlTextBox.Text != null);
            Debug.Assert(itemIdTextBox.Text != null);

            const VarTypes dataType = VarTypes.Empty;
            // ReSharper disable SuggestUseVarKeywordEvident
            int requestedUpdateRate = (int)requestedUpdateRateNumericUpDown.Value;
            float percentDeadband = (float)percentDeadbandNumericUpDown.Value;
            // ReSharper restore SuggestUseVarKeywordEvident
            _itemHandle = easyDAClient1.SubscribeItem(
                serverUrlTextBox.Text,
                new DAItemDescriptor(itemIdTextBox.Text, dataType) { NodePath = nodePathTextBox.Text }, 
                requestedUpdateRate, 
                percentDeadband);
            IsItemSubscribed = true;
        }

        // ReSharper disable InconsistentNaming
        private void changeItemSubscriptionButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            var groupParameters = new DAGroupParameters(
                (int)requestedUpdateRateNumericUpDown.Value, 
                (float)percentDeadbandNumericUpDown.Value);
            easyDAClient1.ChangeItemSubscription(_itemHandle, groupParameters);
        }

        // ReSharper disable InconsistentNaming
        private void unsubscribeItemButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            easyDAClient1.UnsubscribeItem(_itemHandle);
            _itemHandle = 0;
            IsItemSubscribed = false;
        }

        // ReSharper disable InconsistentNaming
        private void easyDAClient1_ItemChanged(object sender, EasyDAItemChangedEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            DisplayVtq(e.Vtq);
            DisplayException(e.Exception);
        }

        // ReSharper disable InconsistentNaming
        private void aboutButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            MessageBox.Show(this, Assembly.GetExecutingAssembly().FullName, 
                Resources.MainForm_aboutButton_Click_Assembly_Name, MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        // ReSharper disable InconsistentNaming
        private void browsePropertiesButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            Debug.Assert(serverUrlTextBox.Text != null);
            Debug.Assert(itemIdTextBox.Text != null);

            daPropertyDialog1.ServerDescriptor.UrlString = serverUrlTextBox.Text;
            daPropertyDialog1.NodeDescriptor.ItemId = itemIdTextBox.Text;
            daPropertyDialog1.NodeDescriptor.NodePath = nodePathTextBox.Text;
            if (daPropertyDialog1.ShowDialog() == DialogResult.OK)
            {
                Debug.Assert(daPropertyDialog1.PropertyElement != null);
                propertyTextBox.Text = daPropertyDialog1.PropertyDescriptor.ToString();
            }
        }

        // ReSharper disable InconsistentNaming
        private void getPropertyValueButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            Debug.Assert(serverUrlTextBox.Text != null);
            Debug.Assert(itemIdTextBox.Text != null);
            Debug.Assert(propertyTextBox.Text != null);

            object value = null;
            Exception exception = null;
            try
            {
                value = easyDAClient1.GetPropertyValue(
                    serverUrlTextBox.Text,
                    new DANodeDescriptor(itemIdTextBox.Text) { NodePath = nodePathTextBox.Text },
                    propertyTextBox.Text);
            }
            catch (OpcException ex)
            {
                exception = ex;
            }
            propertyValueTextBox.Text = (value is null) ? "(null)" : 
                String.Format(CultureInfo.CurrentCulture, "{0}", value);
            DisplayException(exception);
        }

        // ReSharper disable InconsistentNaming
        private void writeItemValueButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            Debug.Assert(serverUrlTextBox.Text != null);
            Debug.Assert(itemIdTextBox.Text != null);

            object value = valueToWriteTextBox.Text;
            Exception exception = null;
            try
            {
                easyDAClient1.WriteItemValue(
                    serverUrlTextBox.Text, 
                    new DAItemDescriptor(itemIdTextBox.Text) { NodePath = nodePathTextBox.Text }, 
                    value);
            }
            catch (OpcException ex)
            {
                exception = ex;
            }
            DisplayException(exception);
        }

        // ReSharper disable InconsistentNaming
        private void closeButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            Close();
        }

        // ReSharper disable InconsistentNaming
        private void MainForm_Load(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {

        }

        // ReSharper disable InconsistentNaming
        private void browseComputersAndServersButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            Debug.Assert(serverUrlTextBox.Text != null);

            opcComputerAndServerDialog1.ServerDescriptor.UrlString = serverUrlTextBox.Text;
            if (opcComputerAndServerDialog1.ShowDialog(this) == DialogResult.OK)
                serverUrlTextBox.Text = opcComputerAndServerDialog1.ServerDescriptor.UrlString;
        }
    }
}
