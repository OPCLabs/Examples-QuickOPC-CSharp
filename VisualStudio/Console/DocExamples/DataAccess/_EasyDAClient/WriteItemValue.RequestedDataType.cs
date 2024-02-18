﻿// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
#region Example
// This example shows how to write a value into a single item, specifying its requested data type.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.BaseLib.ComInterop;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.OperationModel;

namespace DocExamples.DataAccess._EasyDAClient
{
    partial class WriteItemValue
    {
        public static void RequestedDataType()
        {
            // Instantiate the client object.
            var client = new EasyDAClient();

            try
            {
                client.WriteItemValue("", "OPCLabs.KitServer.2", "Simulation.Register_I4", 12345,
                    VarTypes.I4);   // <-- the requested data type
            }
            catch (OpcException opcException)
            {
                Console.WriteLine("*** Failure: {0}", opcException.GetBaseException().Message);
            }
        }
    }
}
#endregion
