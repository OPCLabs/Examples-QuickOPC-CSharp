// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
#region Example
// This example shows how to subscribe to events and display the event message with each notification, using a callback method
// specified using lambda expression.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using System.Diagnostics;
using System.Threading;
using OpcLabs.EasyOpc.AlarmsAndEvents;

namespace DocExamples.AlarmsAndEvents._EasyAEClient
{
    partial class SubscribeEvents
    {
        public static void CallbackLambda()
        {
            // Instantiate the client object.
            var client = new EasyAEClient();

            Console.WriteLine("Subscribing...");
            // The callback is a lambda expression the displays the event message
            client.SubscribeEvents("", "OPCLabs.KitEventServer.2", 1000,
                (sender, eventArgs) =>
                {
                    Debug.Assert(eventArgs != null);
                    if (!eventArgs.Succeeded)
                    {
                        Console.WriteLine("*** Failure: {0}", eventArgs.ErrorMessageBrief);
                        return;
                    }
                    if (!(eventArgs.EventData is null))
                        Console.WriteLine(eventArgs.EventData.Message);
                });

            Console.WriteLine("Processing event notifications for 20 seconds...");
            Thread.Sleep(20 * 1000);

            Console.WriteLine("Unsubscribing...");
            client.UnsubscribeAllEvents();

            Console.WriteLine("Waiting for 2 seconds...");
            Thread.Sleep(2 * 1000);
        }
    }
}
#endregion
