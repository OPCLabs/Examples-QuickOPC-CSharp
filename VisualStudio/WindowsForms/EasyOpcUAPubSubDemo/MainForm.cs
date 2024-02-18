// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using OpcLabs.EasyOpc.UA.PubSub;
using OpcLabs.EasyOpc.UA.PubSub.Extensions;
using OpcLabs.EasyOpc.UA.PubSub.Engine;
using OpcLabs.EasyOpc.UA.PubSub.OperationModel;

// ReSharper disable StringLiteralTypo

namespace EasyOpcUAPubSubDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private bool _subscribed;

        private bool Subscribed
        {
            get => _subscribed;
            set
            {
                if (value == _subscribed)
                    return;
                _subscribed = value;
                OnSubscribedChanged();
            }
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, Assembly.GetExecutingAssembly().FullName, "Assembly Name",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void easyUASubscriber1_DataSetMessage(object sender, EasyUADataSetMessageEventArgs e)
        {
            Debug.Assert(!(e is null));

            errorTextBox.BackColor = e.Succeeded ? SystemColors.Control : Color.Orange;
            errorTextBox.Text = e.Succeeded ? "" : e.Exception?.GetBaseException().Message;

            uaDataSetDataControl1.Value = e.DataSetData;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Subscribed = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            readyMadeSettingsComboBox.SelectedIndex = 4;
        }

        private void OnSubscribedChanged()
        {
            if (Subscribed)
            {
                if (!(SubscribeDataSetArguments is null))
                    easyUASubscriber1.SubscribeDataSet(SubscribeDataSetArguments);
            }
            else
                easyUASubscriber1.UnsubscribeAllDataSets();

            readyMadeSettingsComboBox.Enabled = !Subscribed;
            subscribeButton.Enabled = !Subscribed;
            unsubscribeButton.Enabled = Subscribed;
        }

        private void readyMadeSettingsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UASubscribeDataSetArguments subscribeDataSetArguments = null;
            string info = null;

            switch (readyMadeSettingsComboBox.SelectedIndex)
            {
                case 0:
                    subscribeDataSetArguments = UASubscribeDataSetArguments.Default;
                    break;

                case 1:
                    subscribeDataSetArguments = new UASubscribeDataSetArguments
                    {
                        DataSetSubscriptionDescriptor =
                        {
                            CommunicationParameters =
                                {BrokerDataSetReaderTransportParameters = {QueueName = "opcuademo/json"}},
                            ConnectionDescriptor =
                            {
                                ResourceAddress = "mqtt://opcua-pubsub.demo-this.com",
                                TransportProfileUriString = UAPubSubTransportProfileUriStrings.MqttJson
                            },
                            Filter =
                            {
                                //DataSetWriterDescriptor = 4,  // not contained in the message
                                PublisherId = { ExternalValue = "32" }
                            }
                        }
                    };
                    break;

                case 2:
                    subscribeDataSetArguments = new UASubscribeDataSetArguments
                    {
                        DataSetSubscriptionDescriptor =
                        {
                            ConnectionDescriptor =
                            {
                                ResourceAddress = "opc.eth://FF-FF-FF-FF-FF-FF",
                                TransportProfileUriString = UAPubSubTransportProfileUriStrings.EthUadp
                            },
                            Filter =
                            {
                                DataSetWriterDescriptor = 4,
                                PublisherId = { ExternalValue = (Decimal)31 }
                            }
                        }
                    };
                    try
                    {
                        subscribeDataSetArguments.DataSetSubscriptionDescriptor.ConnectionDescriptor
                            .UseEthernetCaptureFile("UADemoPublisher-Ethernet.pcap");
                    }
                    catch (Exception exception)
                    {
                        errorTextBox.BackColor = Color.Orange;
                        errorTextBox.Text = exception.GetBaseException().Message;
                    }
                    break;

                case 3:
                    subscribeDataSetArguments = new UASubscribeDataSetArguments
                    {
                        DataSetSubscriptionDescriptor =
                        {
                            ConnectionDescriptor =
                            {
                                ResourceAddress = "opc.eth://FF-FF-FF-FF-FF-FF",
                                TransportProfileUriString = UAPubSubTransportProfileUriStrings.EthUadp
                            },
                            Filter =
                            {
                                DataSetWriterDescriptor = 4,
                                PublisherId = { ExternalValue = (Decimal)31 }
                            }
                        }
                    };
                    info = "In order to produce network messages for this demo, run the UADemoPublisher tool with the -eth switch. In some cases, you may have to specify the interface name to be used. Additional software may be needed.";
                    break;

                case 4:
                    subscribeDataSetArguments = new UASubscribeDataSetArguments
                    {
                        DataSetSubscriptionDescriptor =
                        {
                            CommunicationParameters =
                                {BrokerDataSetReaderTransportParameters = {QueueName = "opcuademo/uadp/none"}},
                            ConnectionDescriptor =
                            {
                                ResourceAddress = "mqtt://opcua-pubsub.demo-this.com",
                                TransportProfileUriString = UAPubSubTransportProfileUriStrings.MqttUadp
                            },
                            Filter =
                            {
                                DataSetWriterDescriptor = 4,
                                PublisherId = { ExternalValue = "32" }
                            }
                        }
                    };
                    break;

                case 5:
                    subscribeDataSetArguments = new UASubscribeDataSetArguments
                    {
                        DataSetSubscriptionDescriptor =
                        {
                            ConnectionDescriptor =
                            {
                                ResourceAddress = "opc.udp://239.0.0.1",
                                TransportProfileUriString = UAPubSubTransportProfileUriStrings.UdpUadp
                            },
                            Filter =
                            {
                                DataSetWriterDescriptor = 4,
                                PublisherId = { ExternalValue = (Decimal)31 }
                            }
                        }
                    };
                    info = "In order to produce network messages for this demo, run the UADemoPublisher tool. In some cases, you may have to specify the interface name to be used (on the publisher or subscriber side, or both).";
                    break;

                case 6:
                    subscribeDataSetArguments = new UASubscribeDataSetArguments
                    {
                        DataSetSubscriptionDescriptor =
                        {
                            ConnectionDescriptor = { Name = "FixedLayoutConnection" },
                            Filter =
                            {
                                DataSetWriterDescriptor = { Name = "SimpleWriter" },
                                WriterGroupDescriptor = { Name = "FixedLayoutGroup" }
                            },
                            ResolverDescriptor =
                            {
                                PublisherFileResourceDescriptor = "UADemoPublisher-Default.uabinary",
                                ResolverKind = UAPubSubResolverKind.PublisherFile
                            }
                        }
                    };
                    info = "In order to produce network messages for this demo, run the UADemoPublisher tool. In some cases, you may have to specify the interface name to be used (on the publisher or subscriber side, or both).";
                    break;
            }

            SubscribeDataSetArguments = subscribeDataSetArguments;
            infoLabel.Visible = !string.IsNullOrEmpty(info);
            infoLabel.Text = info;
        }

        private void subscribeButton_Click(object sender, EventArgs e)
        {
            Subscribed = true;
        }

        private UASubscribeDataSetArguments SubscribeDataSetArguments
        {
            get => (UASubscribeDataSetArguments)subscribeDataSetArgumentsControl.GetControlValue();
            set => subscribeDataSetArgumentsControl.SetControlValue(value);
        }

        private void unsubscribeButton_Click(object sender, EventArgs e)
        {
            Subscribed = false;
        }
    }
}
