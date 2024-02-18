// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example
// This example shows how to obtain all branches at the root of the address space. For each branch, it displays whether 
// it may have child nodes.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.AddressSpace;
using OpcLabs.EasyOpc.OperationModel;

namespace DocExamples.DataAccess._EasyDAClient
{
    class BrowseBranches
    {
        public static void Main1()
        {
            // Instantiate the client object.
            var client = new EasyDAClient();
            DANodeElementCollection branchElements;
            try
            {
                branchElements = client.BrowseBranches("", "OPCLabs.KitServer.2", "");
            }
            catch (OpcException opcException)
            {
                Console.WriteLine("*** Failure: {0}", opcException.GetBaseException().Message);
                return;
            }

            foreach (DANodeElement branchElement in branchElements)
                Console.WriteLine($"BranchElements(\"{branchElement.Name}\").HasChildren: {branchElement.HasChildren}");
        }


        // Example output:
        //
        //BranchElements("$ServerControl").HasChildren: True
        //BranchElements("Boilers").HasChildren: True
        //BranchElements("Simulation").HasChildren: True
        //BranchElements("SimulateEvents").HasChildren: True
        //BranchElements("Trends").HasChildren: True
        //BranchElements("Demo").HasChildren: True
        //BranchElements("Greenhouse").HasChildren: True
    }
}
#endregion
