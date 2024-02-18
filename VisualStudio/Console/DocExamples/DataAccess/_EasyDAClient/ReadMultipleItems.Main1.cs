// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
#region Example
// This example shows how to read 4 items at once, and display their values, timestamps and qualities.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using System.Diagnostics;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.OperationModel;

namespace DocExamples.DataAccess._EasyDAClient
{
    partial class ReadMultipleItems
    {
        public static void Main1()
        {
            // Instantiate the client object.
            var client = new EasyDAClient();

            DAVtqResult[] vtqResults = client.ReadMultipleItems("OPCLabs.KitServer.2",
                new DAItemDescriptor[]
                    {
                        "Simulation.Random", "Trends.Ramp (1 min)", "Trends.Sine (1 min)", "Simulation.Register_I4"
                    });

            for (int i = 0; i < vtqResults.Length; i++)
            {
                Debug.Assert(vtqResults[i] != null);

                if (vtqResults[i].Succeeded)
                    Console.WriteLine("vtqResults[{0}].Vtq: {1}", i, vtqResults[i].Vtq);
                else
                    Console.WriteLine("vtqResults[{0}] *** Failure: {1}", i, vtqResults[i].ErrorMessageBrief);
            }
        }
    }
}
#endregion
