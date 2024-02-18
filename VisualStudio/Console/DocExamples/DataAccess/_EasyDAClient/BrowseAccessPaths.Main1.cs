// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example
// This example shows how to obtain all access paths available for an item.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.OperationModel;

namespace DocExamples.DataAccess._EasyDAClient
{
    class BrowseAccessPaths
    {
        public static void Main1()
        {
            // Instantiate the client object.
            var client = new EasyDAClient();
            string[] accessPaths;
            try
            {
                accessPaths = client.BrowseAccessPaths("OPCLabs.KitServer.2", "Simulation.Random");
            }
            catch (OpcException opcException)
            {
                Console.WriteLine("*** Failure: {0}", opcException.GetBaseException().Message);
                return;
            }

            for (int i = 0; i < accessPaths.Length; i++)
                Console.WriteLine($"accessPaths({i}): {accessPaths[i]}");
        }


        // Example output:
        //
        //accessPaths(0): Self
        //accessPaths(1): Other
    }
}
#endregion
