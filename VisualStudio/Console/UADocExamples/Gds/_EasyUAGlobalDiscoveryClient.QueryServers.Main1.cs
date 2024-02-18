// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable LocalizableElement
// ReSharper disable PossibleNullReferenceException
#region Example
// Shows how to find server applications that meet the specified filters, using the global discovery client.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.EasyOpc.UA.Discovery;
using OpcLabs.EasyOpc.UA.Gds;
using OpcLabs.EasyOpc.UA.OperationModel;

namespace UADocExamples.Gds._EasyUAGlobalDiscoveryClient
{
    class QueryServers
    {
        public static void Main1()
        {
            // Instantiate the global discovery client object
            var globalDiscoveryClient = new EasyUAGlobalDiscoveryClient();

            // Find all servers registered in the GDS.
            UAServerOnNetwork[] serverOnNetworkArray;
            try
            {
                globalDiscoveryClient.QueryServers(
                    gdsEndpointDescriptor:"opc.tcp://opcua.demo-this.com:58810/GlobalDiscoveryServer",
                    startingRecordId:0,
                    maximumRecordsToReturn:0,
                    applicationName:"",
                    applicationUriString:"",
                    productUriString:"",
                    serverCapabilities:new string[0],
                    lastCounterResetTime:out _,
                    serverOnNetworkArray:out serverOnNetworkArray);
            }
            catch (UAException uaException)
            {
                Console.WriteLine("*** Failure: {0}", uaException.GetBaseException().Message);
                return;
            }

            // Display results
            foreach (UAServerOnNetwork serverOnNetwork in serverOnNetworkArray)
            {
                Console.WriteLine();
                Console.WriteLine("Server name: {0}", serverOnNetwork.ServerName);
                Console.WriteLine("Discovery URL string: {0}", serverOnNetwork.DiscoveryUrlString);
                Console.WriteLine("Server capabilities: {0}", serverOnNetwork.ServerCapabilities);
            }
        }
    }
}
#endregion
