// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
#region Example
// This example shows how to enumerate all event conditions associated with the specified event source.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using System.Diagnostics;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.AlarmsAndEvents.AddressSpace;
using OpcLabs.EasyOpc.OperationModel;

namespace DocExamples.AlarmsAndEvents._EasyAEClient
{
    class QuerySourceConditions 
    { 
        public static void Main1()
        {
            // Instantiate the client object.
            var client = new EasyAEClient();

            AEConditionElementCollection conditionElements;
            try
            {
                conditionElements = client.QuerySourceConditions("", "OPCLabs.KitEventServer.2", 
                    "Simulation.ConditionState1");
            }
            catch (OpcException opcException)
            {
                Console.WriteLine("*** Failure: {0}", opcException.GetBaseException().Message);
                return;
            }

            foreach (AEConditionElement conditionElement in conditionElements)
            {
                Debug.Assert(conditionElement != null);
                Console.WriteLine("ConditionElements[\"{0}\"]: {1} subcondition(s)", 
                    conditionElement.Name, conditionElement.SubconditionNames.Length);
            }
        }
    } 
}
#endregion
