// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable LocalizableElement
// ReSharper disable PossibleNullReferenceException
// ReSharper disable StringLiteralTypo
#region Example
// This example shows how to obtain application URLs of all OPC Unified Architecture servers on a given machine.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.Discovery;
using OpcLabs.EasyOpc.UA.OperationModel;

namespace UADocExamples._EasyUAClient
{
    class DiscoverLocalServers
    {
        public static void Overload1()
        {
            // Instantiate the client object.
            var client = new EasyUAClient();

            // Obtain collection of server elements.
            UADiscoveryElementCollection discoveryElementCollection;
            try
            {
                discoveryElementCollection = client.DiscoverLocalServers("opcua.demo-this.com");
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
                return;
            }

            // Display results.
            foreach (UADiscoveryElement discoveryElement in discoveryElementCollection)
                Console.WriteLine($"discoveryElementCollection[\"{discoveryElement.DiscoveryUriString}\"].ApplicationUriString: {discoveryElement.ApplicationUriString}");

            
            // Example output:
            //
            //discoveryElementCollection["opc.tcp://opcua.demo-this.com:51210/UA/SampleServer"].ApplicationUriString: urn: DEMO - 5:UA Sample Server
            //discoveryElementCollection["http://opcua.demo-this.com:51211/UA/SampleServer"].ApplicationUriString: urn: DEMO - 5:UA Sample Server
            //discoveryElementCollection["https://opcua.demo-this.com:51212/UA/SampleServer/"].ApplicationUriString: urn: DEMO - 5:UA Sample Server
            //discoveryElementCollection["http://opcua.demo-this.com:62543/Quickstarts/AlarmConditionServer"].ApplicationUriString: urn: opcua.demo - this.com:Quickstart Alarm Condition Server
            //discoveryElementCollection["opc.tcp://opcua.demo-this.com:62544/Quickstarts/AlarmConditionServer"].ApplicationUriString: urn: opcua.demo - this.com:Quickstart Alarm Condition Server
        }
    }
}
#endregion
