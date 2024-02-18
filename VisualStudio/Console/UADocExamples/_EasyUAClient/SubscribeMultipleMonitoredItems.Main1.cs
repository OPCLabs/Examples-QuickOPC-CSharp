﻿// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable LocalizableElement
// ReSharper disable InconsistentNaming
// ReSharper disable PossibleNullReferenceException
// ReSharper disable ConvertIfStatementToConditionalTernaryExpression
#region Example
// This example shows how to subscribe to changes of multiple monitored items and display the value of the monitored item with 
// each change.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.OperationModel;

namespace UADocExamples._EasyUAClient
{
    partial class SubscribeMultipleMonitoredItems
    {
        public static void Main1()
        {
            UAEndpointDescriptor endpointDescriptor =
                "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer";
            // or "http://opcua.demo-this.com:51211/UA/SampleServer" (currently not supported)
            // or "https://opcua.demo-this.com:51212/UA/SampleServer/"

            // Instantiate the client object and hook events.
            var client = new EasyUAClient();
            client.DataChangeNotification += client_DataChangeNotification_Main1;

            Console.WriteLine("Subscribing...");
            client.SubscribeMultipleMonitoredItems(new[]
                {
                    new EasyUAMonitoredItemArguments(null, endpointDescriptor, 
                        "nsu=http://test.org/UA/Data/ ;i=10845", 1000),
                    new EasyUAMonitoredItemArguments(null, endpointDescriptor, 
                        "nsu=http://test.org/UA/Data/ ;i=10853", 1000),
                    new EasyUAMonitoredItemArguments(null, endpointDescriptor, 
                        "nsu=http://test.org/UA/Data/ ;i=10855", 1000)
                });

            Console.WriteLine("Processing monitored item changed events for 10 seconds...");
            System.Threading.Thread.Sleep(10 * 1000);

            Console.WriteLine("Unsubscribing...");
            client.UnsubscribeAllMonitoredItems();

            Console.WriteLine("Waiting for 5 seconds...");
            System.Threading.Thread.Sleep(5 * 1000);

            Console.WriteLine("Finished.");
        }

        static void client_DataChangeNotification_Main1(object sender, EasyUADataChangeNotificationEventArgs e)
        {
            // Display value.
            if (e.Succeeded)
                Console.WriteLine($"{e.Arguments.NodeDescriptor}: {e.AttributeData.Value}");
            else
                Console.WriteLine($"{e.Arguments.NodeDescriptor} *** Failure: {e.ErrorMessageBrief}");
        }
    }
}
#endregion
