// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System.Diagnostics;
using EasyOpcNetDemo.Properties;
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
namespace EasyOpcNetDemo
{
    public partial class MainForm : Form
    {
        // ReSharper disable once NotNullMemberIsNotInitialized
        public MainForm()
        {
            InitializeComponent();
        }

        // ReSharper disable InconsistentNaming
        private void browseServersButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            Debug.Assert(machineNameTextBox.Text != null);

            opcServerDialog1.Location = machineNameTextBox.Text;
            if (opcServerDialog1.ShowDialog(this) == DialogResult.OK)
            {
                Debug.Assert(opcServerDialog1.ServerElement != null);
                serverClassTextBox.Text = opcServerDialog1.ServerElement.ServerClass;
            }
        }

        // ReSharper disable InconsistentNaming
        private void browseItemsButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            Debug.Assert(machineNameTextBox.Text != null);
            Debug.Assert(serverClassTextBox.Text != null);

            daItemDialog1.ServerDescriptor.MachineName = machineNameTextBox.Text;
            daItemDialog1.ServerDescriptor.ServerClass = serverClassTextBox.Text;
            if (daItemDialog1.ShowDialog() == DialogResult.OK)
            {
                Debug.Assert(daItemDialog1.NodeElement != null);
                itemIdTextBox.Text = daItemDialog1.NodeElement.ItemId;
            }
        }

        // ReSharper disable InconsistentNaming
        private void readItemButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            Debug.Assert(machineNameTextBox.Text != null);
            Debug.Assert(serverClassTextBox.Text != null);
            Debug.Assert(itemIdTextBox.Text != null);

            DAVtq vtq = null;
            Exception exception = null;
            try
            {
                vtq = easyDAClient1.ReadItem(
                    machineNameTextBox.Text,
                    serverClassTextBox.Text,
                    itemIdTextBox.Text);
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
            Debug.Assert(machineNameTextBox.Text != null);
            Debug.Assert(serverClassTextBox.Text != null);
            Debug.Assert(itemIdTextBox.Text != null);

            const VarTypes dataType = VarTypes.Empty;
            // ReSharper disable SuggestUseVarKeywordEvident
            int requestedUpdateRate = (int)requestedUpdateRateNumericUpDown.Value;
            float percentDeadband = (float)percentDeadbandNumericUpDown.Value;
            // ReSharper restore SuggestUseVarKeywordEvident
            _itemHandle = easyDAClient1.SubscribeItem(
                machineNameTextBox.Text,
                serverClassTextBox.Text,
                itemIdTextBox.Text, 
                dataType, 
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
        private void browseMachinesButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            if (computerBrowserDialog1.ShowDialog() == DialogResult.OK)
               machineNameTextBox.Text = computerBrowserDialog1.SelectedName;
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
            Debug.Assert(machineNameTextBox.Text != null);
            Debug.Assert(serverClassTextBox.Text != null);
            Debug.Assert(itemIdTextBox.Text != null);

            daPropertyDialog1.ServerDescriptor.MachineName = machineNameTextBox.Text;
            daPropertyDialog1.ServerDescriptor.ServerClass = serverClassTextBox.Text;
            daPropertyDialog1.NodeDescriptor = itemIdTextBox.Text;
            if (daPropertyDialog1.ShowDialog() == DialogResult.OK)
            {
                Debug.Assert(daPropertyDialog1.PropertyElement != null);
                propertyIdMaskedTextBox.Text = daPropertyDialog1.PropertyElement.PropertyId.ToString();
            }
        }

        // ReSharper disable InconsistentNaming
        private void getPropertyValueButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            Debug.Assert(machineNameTextBox.Text != null);
            Debug.Assert(serverClassTextBox.Text != null);
            Debug.Assert(itemIdTextBox.Text != null);

            int propertyId = Convert.ToInt32(propertyIdMaskedTextBox.Text, CultureInfo.CurrentCulture);
            object value = null;
            Exception exception = null;
            try
            {
                value = easyDAClient1.GetPropertyValue(
                    machineNameTextBox.Text,
                    serverClassTextBox.Text,
                    itemIdTextBox.Text,
                    propertyId);
            }
            catch (OpcException ex)
            {
                exception = ex;
            }
            propertyValueTextBox.Text = (value is null ? "(null)" : 
                String.Format(CultureInfo.CurrentCulture, "{0}", value));
            DisplayException(exception);
        }

        // ReSharper disable InconsistentNaming
        private void writeItemValueButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            Debug.Assert(machineNameTextBox.Text != null);
            Debug.Assert(serverClassTextBox.Text != null);
            Debug.Assert(itemIdTextBox.Text != null);

            object value = valueToWriteTextBox.Text;
            Exception exception = null;
            try
            {
                easyDAClient1.WriteItemValue(
                    machineNameTextBox.Text, 
                    serverClassTextBox.Text, 
                    itemIdTextBox.Text, 
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
    }
}
