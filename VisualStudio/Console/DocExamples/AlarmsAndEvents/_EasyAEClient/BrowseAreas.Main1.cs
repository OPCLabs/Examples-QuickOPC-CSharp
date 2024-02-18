﻿// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example
// This example shows how to obtain all areas directly under the root (denoted by empty string for the parent).
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using System.Diagnostics;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.AlarmsAndEvents.AddressSpace;
using OpcLabs.EasyOpc.OperationModel;

namespace DocExamples.AlarmsAndEvents._EasyAEClient
{
    class BrowseAreas 
    { 
        public static void Main1()
        {
            // Instantiate the client object.
            var client = new EasyAEClient();

            AENodeElementCollection nodeElements;
            try
            {
                nodeElements = client.BrowseAreas("", "OPCLabs.KitEventServer.2", "");
            }
            catch (OpcException opcException)
            {
                Console.WriteLine("*** Failure: {0}", opcException.GetBaseException().Message);
                return;
            }

            foreach (AENodeElement nodeElement in nodeElements)
            {
                Debug.Assert(nodeElement != null);

                Console.WriteLine("nodeElements[\"{0}\"]:", nodeElement.Name);
                Console.WriteLine("    .QualifiedName: {0}", nodeElement.QualifiedName);
            }
        }
    } 
}
#endregion
