// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable AssignNullToNotNullAttribute
#region Example
// This example shows how to obtain all nodes under the "Simulation" branch of the address space. For each node, it displays
// whether the node is a branch or a leaf.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.AddressSpace;
using OpcLabs.EasyOpc.OperationModel;

namespace DocExamples.DataAccess._EasyDAClient
{
    partial class BrowseNodes
    {
        public static void Main1()
        {
            // Instantiate the client object.
            var client = new EasyDAClient();

            DANodeElementCollection nodeElements;
            try
            {
                nodeElements = client.BrowseNodes("", "OPCLabs.KitServer.2", "Greenhouse", DABrowseParameters.Default);
            }
            catch (OpcException opcException)
            {
                Console.WriteLine($"*** Failure: {opcException.GetBaseException().Message}");
                return;
            }

            foreach (DANodeElement nodeElement in nodeElements)
            {
                Console.WriteLine($"NodeElements(\"{nodeElement.Name}\"):");
                Console.WriteLine($"    .IsBranch: {nodeElement.IsBranch}");
                Console.WriteLine($"    .IsLeaf: {nodeElement.IsLeaf}");
            }
        }
    }
}
#endregion
