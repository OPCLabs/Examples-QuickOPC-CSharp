// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example
// This example shows information available about OPC event condition.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using System.Diagnostics;
using System.Collections.Generic;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.AlarmsAndEvents.AddressSpace;
using OpcLabs.EasyOpc.OperationModel;

namespace DocExamples.AlarmsAndEvents._AEConditionElement 
{ 
    class Properties 
    {
        static void DumpSubconditionNames(IEnumerable<string> subconditionNames)
        {
            foreach (string name in subconditionNames) Console.WriteLine("            {0}", name);
        }

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
                foreach (AEConditionElement conditionElement in categoryElement.ConditionElements)
                {
                    Debug.Assert(conditionElement != null);

                    Console.WriteLine("    Information about condition \"{0}\":", conditionElement);
                    Console.WriteLine("        .Name: {0}", conditionElement.Name);
                    Console.WriteLine("        .SubconditionNames:");
                    DumpSubconditionNames(conditionElement.SubconditionNames);
                }
            }
        }
    } 
}
#endregion
