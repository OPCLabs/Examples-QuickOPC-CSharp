// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example
// This example shows information available about OPC event attribute.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using System.Diagnostics;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.AlarmsAndEvents.AddressSpace;
using OpcLabs.EasyOpc.OperationModel;

namespace DocExamples.AlarmsAndEvents._AEAttributeElement
{
    class Properties
    {
        public static void Main1()
        {
            // Instantiate the client object.
            var client = new EasyAEClient();

            AECategoryElementCollection categoryElements;
            try
            {
                categoryElements = client.QueryEventCategories("", "OPCLabs.KitEventServer.2");
            }
            catch (OpcException opcException)
            {
                Console.WriteLine("*** Failure: {0}", opcException.GetBaseException().Message);
                return;
            }

            foreach (AECategoryElement categoryElement in categoryElements)
            {
                Debug.Assert(categoryElement != null);

                Console.WriteLine("Category {0}:", categoryElement);
                foreach (AEAttributeElement attributeElement in categoryElement.AttributeElements)
                {
                    Debug.Assert(attributeElement != null);

                    Console.WriteLine("    Information about attribute {0}:", attributeElement);
                    Console.WriteLine("        .AttributeId: {0}", attributeElement.AttributeId);
                    Console.WriteLine("        .Description: {0}", attributeElement.Description);
                    Console.WriteLine("        .DataType: {0}", attributeElement.DataType);
                }
            }
        }
    }
}
#endregion
