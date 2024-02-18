﻿// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable LocalizableElement
// ReSharper disable PossibleNullReferenceException
#region Example
// This example shows how to obtain information about OPC UA servers available on the network.
// The result is flat, i.e. each discovery URL is returned in separate element, with possible repetition of the servers.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.Discovery;
using OpcLabs.EasyOpc.UA.OperationModel;

namespace UADocExamples._EasyUAClient
{
    partial class DiscoverNetworkServers
    {
        public static void Main1()
        {
            // Instantiate the client object.
            var client = new EasyUAClient();

            // Obtain collection of application elements.
            UADiscoveryElementCollection discoveryElementCollection;
            try
            {
                discoveryElementCollection = client.DiscoverNetworkServers("opcua.demo-this.com");
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
                return;
            }

            // Display results.
            foreach (UADiscoveryElement discoveryElement in discoveryElementCollection)
            {
                Console.WriteLine();
                Console.WriteLine($"Server name: {discoveryElement.ServerName}");
                Console.WriteLine($"Discovery URI string: {discoveryElement.DiscoveryUriString}");
                Console.WriteLine($"Server capabilities: {discoveryElement.ServerCapabilities}");
                Console.WriteLine($"Application URI string: {discoveryElement.ApplicationUriString}");
                Console.WriteLine($"Product URI string: {discoveryElement.ProductUriString}");
            }
        }
    }
}
#endregion
