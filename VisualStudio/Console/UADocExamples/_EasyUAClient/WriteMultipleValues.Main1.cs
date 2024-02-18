// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

#region Example
// This example shows how to write values into 3 nodes at once.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.OperationModel;

namespace UADocExamples._EasyUAClient
{
    partial class WriteMultipleValues
    {
        public static void Main1()
        {
            UAEndpointDescriptor endpointDescriptor =
                "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer";
            // or "http://opcua.demo-this.com:51211/UA/SampleServer" (currently not supported)
            // or "https://opcua.demo-this.com:51212/UA/SampleServer/"

            // Instantiate the client object
            var client = new EasyUAClient();

            // Modify value of a node
            client.WriteMultipleValues(new[]
                {
                    new UAWriteValueArguments(endpointDescriptor, "nsu=http://test.org/UA/Data/ ;i=10221", 23456),
                    new UAWriteValueArguments(endpointDescriptor, "nsu=http://test.org/UA/Data/ ;i=10226", 2.34567890),
                    new UAWriteValueArguments(endpointDescriptor, "nsu=http://test.org/UA/Data/ ;i=10227", "ABC")
                });
            // Production code would check the success of the operation. See separate example for that.
        }
    }
}
#endregion
