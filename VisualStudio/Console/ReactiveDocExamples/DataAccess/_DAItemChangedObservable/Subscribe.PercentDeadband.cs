// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable PossibleNullReferenceException
#region Example
// Shows how to create an observable for OPC-DA item changes, and subscribe to it with percent deadband.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using System.Threading;
using OpcLabs.EasyOpc.DataAccess.Reactive;

namespace ReactiveDocExamples
{
    namespace _DAItemChangedObservable
    {
        partial class Subscribe
        {
            public static void PercentDeadband()
            {
                const float percentDeadband = 5.0f;
                Console.WriteLine($"Creating observable with {percentDeadband}% deadband...");
                DAItemChangedObservable<double> ramp = 
                    DAItemChangedObservable.Create<double>("", "OPCLabs.KitServer.2", "Simulation.Ramp 0:100 (10 s)", 
                        requestedUpdateRate:100, percentDeadband:percentDeadband);

                Console.WriteLine("Subscribing...");
                using (ramp.Subscribe(e => Console.WriteLine(
                    (e.Exception is null) ? e.Vtq.ToString() : e.Exception.GetBaseException().ToString())))
                {
                    Console.WriteLine("Waiting for 10 seconds...");
                    Thread.Sleep(10*1000);

                    Console.WriteLine("Unsubscribing...");
                }

                Console.WriteLine("Waiting for 2 seconds...");
                Thread.Sleep(2 * 1000);
            }
        }
    }
}
#endregion
