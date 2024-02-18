// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
#region Example
// This example shows how to write a value, timestamp and quality into a single item.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.OperationModel;

namespace DocExamples.DataAccess._EasyDAClient
{
    class WriteItem
    {
        public static void Main1()
        {
            // Instantiate the client object.
            var client = new EasyDAClient();

            try
            {
                client.WriteItem("", "OPCLabs.KitServer.2", "Simulation.Register_I4", 
                    12345, DateTime.SpecifyKind(new DateTime(1980, 1, 1), DateTimeKind.Utc), 192);
            }
            catch (OpcException opcException)
            {
                Console.WriteLine($"*** Failure: {opcException.GetBaseException().Message}");
                return;
            }
            Console.WriteLine("Success");
        }
    }
}
#endregion
