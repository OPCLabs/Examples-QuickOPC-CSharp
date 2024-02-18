
// This example shows how to load a list of OPC "Classic" items from an XML file and subscribe to them.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using OpcLabs.BaseLib.Runtime.InteropServices;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.OperationModel;

namespace SubscribeFromXml
{
    class Program
    {
        static void Main()
        {
            ComManagement.Instance.AssureSecurityInitialization();

            Console.WriteLine("Loading items from XML file...");
            var xmlSerializer = new XmlSerializer(typeof(DAItemGroupArguments[]));
            var xmlReader = XmlReader.Create("OpcItems.xml", new XmlReaderSettings {IgnoreWhitespace = true});
            var argArray = (DAItemGroupArguments[]) (xmlSerializer.Deserialize(xmlReader));

            if (!(argArray is null))
            {
                Console.WriteLine();
                Console.WriteLine("Arguments loaded:");
                foreach (DAItemGroupArguments itemGroupArguments in argArray)
                    Console.WriteLine($"  {itemGroupArguments}");

                Console.WriteLine();
                Console.WriteLine("Subscribing for 30 seconds...");
                EasyDAClient.SharedInstance.SubscribeMultipleItems(argArray,
                    (_, eventArgs) => Console.WriteLine(
                        $"[{eventArgs.Arguments.State}] {eventArgs.Arguments.ItemDescriptor.ItemId}: {eventArgs.Vtq}"));
                Thread.Sleep(30 * 1000);

                Console.WriteLine();
                Console.WriteLine("Unsubscribing...");
                EasyDAClient.SharedInstance.UnsubscribeAllItems();
            }

            Console.WriteLine();
            Console.WriteLine("Finished.");
        }
    }
}
