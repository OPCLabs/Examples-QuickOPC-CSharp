// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

#region Example
// Parses an absolute OPC-UA browse path and displays its starting node and elements.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.EasyOpc.UA.Navigation;
using OpcLabs.EasyOpc.UA.Navigation.Parsing;

namespace UADocExamples._UABrowsePathParser
{
    class Parse
    {
        public static void Main1()
        {
            var browsePathParser = new UABrowsePathParser();
            UABrowsePath browsePath;
            try
            {
                browsePath = browsePathParser.Parse("[ObjectsFolder]/Data/Static/UserScalar");
            }
            catch (UABrowsePathFormatException browsePathFormatException)
            {
                Console.WriteLine("*** Failure: {0}", browsePathFormatException.GetBaseException().Message);
                return;
            }

            // Display results
            Console.WriteLine("StartingNodeId: {0}", browsePath.StartingNodeId);

            foreach (UABrowsePathElement browsePathElement in browsePath.Elements)
                Console.WriteLine(browsePathElement);

            // Example output:
            // StartingNodeId: ObjectsFolder
            // /Data
            // /Static
            // /UserScalar
        }
    }
}
#endregion
