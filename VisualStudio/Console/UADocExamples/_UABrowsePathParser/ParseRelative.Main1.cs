// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

#region Example
// Parses a relative OPC-UA browse path and displays its elements.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.EasyOpc.UA.Navigation;
using OpcLabs.EasyOpc.UA.Navigation.Parsing;

namespace UADocExamples._UABrowsePathParser
{
    class ParseRelative
    {
        public static void Main1()
        {
            var browsePathParser = new UABrowsePathParser();
            UABrowsePathElementCollection browsePathElements;
            try
            {
                browsePathElements = browsePathParser.ParseRelative("/Data.Dynamic.Scalar.CycleComplete");
            }
            catch (UABrowsePathFormatException browsePathFormatException)
            {
                Console.WriteLine("*** Failure: {0}", browsePathFormatException.GetBaseException().Message);
                return;
            }

            // Display results
            foreach (UABrowsePathElement browsePathElement in browsePathElements)
                Console.WriteLine(browsePathElement);

            // Example output:
            // /Data
            // .Dynamic
            // .Scalar
            // .CycleComplete        
        }
    }
}
#endregion
