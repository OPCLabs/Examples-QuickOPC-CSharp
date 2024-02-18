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

namespace DocExamples.DataAccess.Xml
{
    class BrowseBranches
    {
        public static void Main1Xml()
        {
            // Instantiate the client object.
            var client = new EasyDAClient();
            DANodeElementCollection branchElements;
            try
            {
                branchElements = client.BrowseBranches("http://opcxml.demo-this.com/XmlDaSampleServer/Service.asmx");
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
        //BranchElements("Static").HasChildren: True
        //BranchElements("Dynamic").HasChildren: True
    }
}
#endregion
