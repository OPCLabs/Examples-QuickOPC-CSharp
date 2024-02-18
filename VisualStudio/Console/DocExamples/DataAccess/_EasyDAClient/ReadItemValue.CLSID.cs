// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
#region Example
// This example shows how to read value of a single item, and display it, using CLSID instead of ProgID of the OPC Server.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.OperationModel;

namespace DocExamples.DataAccess._EasyDAClient
{
    partial class ReadItemValue
    {
        public static void CLSID()
        {
            // Instantiate the client object.
            var client = new EasyDAClient();

            Console.WriteLine("Reading item value...");
            object value;
            try
            {
                value = client.ReadItemValue("", "{C8A12F17-1E03-401E-B53D-6C654DD576DA}", "Simulation.Random");
            }
            catch (OpcException opcException)
            {
                Console.WriteLine("*** Failure: {0}", opcException.GetBaseException().Message);
                return;
            }

            Console.WriteLine($"value: {value}");
        }
    }
}
#endregion
