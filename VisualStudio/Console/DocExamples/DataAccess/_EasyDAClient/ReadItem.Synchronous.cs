// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
#region Example 
// This example shows how to read an item synchronously, and display its value, timestamp and quality.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.OperationModel;

namespace DocExamples.DataAccess._EasyDAClient
{
    partial class ReadItem
    {
        public static void Synchronous()
        {
            // Instantiate the client object.
            var client = new EasyDAClient();

            // Specify that only synchronous method is allowed. By default, both synchronous and asynchronous methods are
            // allowed, and the component picks a suitable method automatically. Disallowing asynchronous method leaves
            // only the synchronous method available for selection.
            client.InstanceParameters.Mode.AllowAsynchronousMethod = false;

            DAVtq vtq;
            try
            {
                vtq = client.ReadItem("", "OPCLabs.KitServer.2", "Simulation.Random");
            }
            catch (OpcException opcException)
            {
                Console.WriteLine("*** Failure: {0}", opcException.GetBaseException().Message);
                return;
            }

            Console.WriteLine("Vtq: {0}", vtq);
        }
    }
}
#endregion
