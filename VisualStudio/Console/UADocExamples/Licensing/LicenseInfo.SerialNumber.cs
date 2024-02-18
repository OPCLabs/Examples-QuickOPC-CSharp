// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable LocalizableElement
#region Example
// Shows how to obtain the serial number of the active license, and determine whether it is a stock demo or trial license.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.EasyOpc.UA;

namespace UADocExamples.Licensing
{
    partial class LicenseInfo
    {
        public static void SerialNumber()
        {
            // Instantiate the client object.
            var client = new EasyUAClient();

            // Obtain the serial number from the license info.
            long serialNumber = (uint)client.LicenseInfo["Multipurpose.SerialNumber"];

            // Display the serial number.
            Console.WriteLine("SerialNumber: {0}", serialNumber);

            // Determine whether we are running as demo or trial.
            if ((1111110000 <= serialNumber) && (serialNumber <= 1111119999))
                Console.WriteLine("This is a stock demo or trial license.");
            else
                Console.WriteLine("This is not a stock demo or trial license.");
        }
    }
}
#endregion
