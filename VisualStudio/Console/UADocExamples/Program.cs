// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

using OpcLabs.BaseLib.Console;
using System;
using System.Collections.Generic;

namespace UADocExamples
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Action action;
            do
            {
                Console.WriteLine();
                action = ConsoleDialog.SelectItem("Select example group", "Return", new Dictionary<Action, string>
                {
                    {UAExamplesMenu.Main1, "Main"}, 
                    {AlarmsAndConditions.AlarmsAndConditionsExamplesMenu.Main1, "Alarms and Conditions"}, 
                    {Application.ApplicationExamplesMenu.Main1, "Application"}, 
                    {ComplexData.ComplexDataExamplesMenu.Main1, "Complex Data"},
                    {FileProviders.FileProvidersExamplesMenu.Main1, "File Providers"},
                    {FileTransfer.FileTransferExamplesMenu.Main1, "File Transfer"},
                    {Gds.GdsExamplesMenu.Main1, "GDS"},
                    {Interaction.InteractionExamplesMenu.Main1, "Interaction"},
                    {Licensing.LicensingExamplesMenu.Main1, "Licensing"},
                    {PubSub.PubSubExamplesMenu.Main1, "PubSub"},
                    {Specialized.SpecializedExamplesMenu.Main1, "Specialized"}
                });
                action?.Invoke();
            }
            while (!(action is null));
        }
    }
}
