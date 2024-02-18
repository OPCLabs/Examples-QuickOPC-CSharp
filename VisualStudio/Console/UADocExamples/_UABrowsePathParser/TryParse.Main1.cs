// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable InlineOutVariableDeclaration
#region Example
// Attempts to parse an absolute OPC-UA browse path and displays its starting node and elements.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.BaseLib;
using OpcLabs.EasyOpc.UA.Navigation;
using OpcLabs.EasyOpc.UA.Navigation.Parsing;

namespace UADocExamples._UABrowsePathParser
{
    class TryParse
    {
        public static void Main1()
        {
            var browsePathParser = new UABrowsePathParser();

            IStringParsingError stringParsingError = browsePathParser.TryParse(
                "[ObjectsFolder]/Data/Static/UserScalar", 
                out UABrowsePath browsePath);

            // Display results
            if (!(stringParsingError is null))
            {
                Console.WriteLine("*** Error: {0}", stringParsingError);
                return;
            }

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
