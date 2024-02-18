// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
#region Example
// This example shows how to obtain all ProgIDs of all OPC Alarms and Events servers on the local machine.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using System.Diagnostics;
using OpcLabs.EasyOpc;
using OpcLabs.EasyOpc.AlarmsAndEvents;
using OpcLabs.EasyOpc.OperationModel;

namespace DocExamples.AlarmsAndEvents._EasyAEClient
{
    class BrowseServers 
    { 
        public static void Main1()
        {
            // Instantiate the client object.
            var client = new EasyAEClient();

            ServerElementCollection serverElements;
            try
            {
                serverElements = client.BrowseServers("");
            }
            catch (OpcException opcException)
            {
                Console.WriteLine("*** Failure: {0}", opcException.GetBaseException().Message);
                return;
            }

            foreach (ServerElement serverElement in serverElements)
            {
                Debug.Assert(serverElement != null);
                Console.WriteLine("serverElements[\"{0}\"].ProgId: {1}", serverElement.Clsid, serverElement.ProgId);
            }
        }
    } 
}
#endregion
