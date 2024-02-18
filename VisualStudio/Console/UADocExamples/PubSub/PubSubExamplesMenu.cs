// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable LocalizableElement

using System;
using System.Collections.Generic;
using OpcLabs.BaseLib.Console;
using OpcLabs.EasyOpc.UA.PubSub;
using OpcLabs.EasyOpc.UA.PubSub.Engine;

namespace UADocExamples.PubSub
{
    static class PubSubExamplesMenu
    {
        public static void Main1()
        {
            var actionArray = new Action[] {
                // ReSharper disable RedundantCommaInArrayInitializer
                _EasyUASubscriber.PullDataSetMessage.Main1,
                _EasyUASubscriber.SubscribeDataSet.Callback,
                _EasyUASubscriber.SubscribeDataSet.CaptureFile,
                _EasyUASubscriber.SubscribeDataSet.Ethernet,
                _EasyUASubscriber.SubscribeDataSet.ExtractField,
                _EasyUASubscriber.SubscribeDataSet.FieldNames,
                _EasyUASubscriber.SubscribeDataSet.Filter,
                _EasyUASubscriber.SubscribeDataSet.Main1,
                _EasyUASubscriber.SubscribeDataSet.MappingParameters,
                _EasyUASubscriber.SubscribeDataSet.Metadata,
                _EasyUASubscriber.SubscribeDataSet.MqttFromFileStorage,
                _EasyUASubscriber.SubscribeDataSet.MqttJsonTcp,
                _EasyUASubscriber.SubscribeDataSet.MqttTcpSaveCopy,
                _EasyUASubscriber.SubscribeDataSet.MqttUadpTcp,
                _EasyUASubscriber.SubscribeDataSet.PublishedDataSet,
                _EasyUASubscriber.SubscribeDataSet.PublisherId,
                _EasyUASubscriber.SubscribeDataSet.ResolveFromFile,
                _EasyUASubscriber.SubscribeDataSet.Secure,
                _EasyUASubscriber.SubscribeDataSetField.Main1,
                _EasyUASubscriber.UnsubscribeDataSet.Main1,
                _IUAReadOnlyPubSubConfiguration.GetMethods.PublishedDataSets,
                _IUAReadOnlyPubSubConfiguration.GetMethods.PubSubComponents,
                // ReSharper restore RedundantCommaInArrayInitializer
            };

            var actionList = new List<Action>(actionArray);

            var originalSharedParameters = (EasyUASubscriberSharedParameters)EasyUASubscriber.SharedParameters.Clone();
            do
            {
                Console.WriteLine();
                if (!ConsoleDialog.SelectAndPerformAction("Select action to perform", "Return", actionList))
                    break;

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

                if (EasyUASubscriber.SharedParameters != originalSharedParameters)
                {
                    using (ConsoleUtilities.WithForegroundColor(ConsoleColor.Yellow))
                        Console.WriteLine(
                            "This example has changed some global parameters that can influence how other examples work. " +
                            "For this reason, the application will now exit. Start it again to continue.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
            while (true);
        }
    }
}
