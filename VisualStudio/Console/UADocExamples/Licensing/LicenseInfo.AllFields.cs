// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable LocalizableElement
#region Example
// Shows how to display all fields of the available license(s).
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using System.Collections.Generic;
using OpcLabs.BaseLib.Collections.Specialized;
using OpcLabs.EasyOpc.UA;

namespace UADocExamples.Licensing
{
    partial class LicenseInfo
    {
        public static void AllFields()
        {
            // Instantiate the client object.
            var client = new EasyUAClient();

            // Obtain the license info.
            StringObjectDictionary licenseInfo = client.LicenseInfo;

            // Display all elements.
            foreach (KeyValuePair<string, object> pair in licenseInfo)
                Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}
#endregion
