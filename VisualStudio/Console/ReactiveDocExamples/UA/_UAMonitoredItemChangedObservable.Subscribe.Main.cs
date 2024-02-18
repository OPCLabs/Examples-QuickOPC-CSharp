// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable PossibleNullReferenceException
#region Example
// Shows how to create an observable for OPC-UA monitored item changes, and subscribe to it.
using OpcLabs.EasyOpc.UA.Reactive;
using System;
using System.Threading;

namespace ReactiveDocExamples
{
    namespace _UAMonitoredItemChangedObservable
    {
        class Subscribe
        {
            public static void Main()
            {
                Console.WriteLine("Creating observable...");
                UAMonitoredItemChangedObservable<float> dynamic =
                    UAMonitoredItemChangedObservable.Create<float>(
                        "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer", "nsu=http://test.org/UA/Data/;i=10853", 1000);

                Console.WriteLine("Subscribing...");
                using (dynamic.Subscribe(e => Console.WriteLine(
                    e.Exception == null ? e.AttributeData.ToString() : e.Exception.GetBaseException().ToString())))
                {
                    Console.WriteLine("Waiting for 10 seconds...");
                    Thread.Sleep(10*1000);

                    Console.WriteLine("Unsubscribing...");
                }
            }
        }
    }
}
#endregion
// ReSharper restore PossibleNullReferenceException
// ReSharper restore CheckNamespace
