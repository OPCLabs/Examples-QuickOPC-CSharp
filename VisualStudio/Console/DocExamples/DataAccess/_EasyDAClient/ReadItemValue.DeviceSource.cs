// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example
// This example shows how to read a value of a single item from the device and display its value.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.OperationModel;

namespace DocExamples.DataAccess._EasyDAClient
{
    partial class ReadItemValue
    {
        public static void DeviceSource()
        {
            // Instantiate the client object.
            var client = new EasyDAClient();

            Console.WriteLine("Reading item value...");
            object value;
            try
            {
                // DADataSource enumeration:
                // Selects the data source for OPC reads (from device, from OPC cache, or dynamically determined).
                // The data source (memory, OPC cache or OPC device) selection is based on the desired value age and
                // current status of data received from the server.

                value = client.ReadItemValue("OPCLabs.KitServer.2", "Demo.Ramp", DADataSource.Device);
            }
            catch (OpcException opcException)
            {
                Console.WriteLine("*** Failure: {0}", opcException.GetBaseException().Message);
                return;
            }

            Console.WriteLine(value);
        }
    }
}
#endregion
