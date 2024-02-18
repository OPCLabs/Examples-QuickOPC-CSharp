﻿// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable InconsistentNaming
// ReSharper disable LocalizableElement
#region Example
// Shows how to register a license located in an embedded managed resource, verifying its existence upfront.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using System.Reflection;
using OpcLabs.BaseLib.ComponentModel;
using OpcLabs.BaseLib.Portable;
using OpcLabs.EasyOpc.UA;

namespace UADocExamples.Licensing
{
    partial class _LicensingManagement
    {
        public static void RegisterManagedResourceWithExistenceCheck()
        {
            // Register a license that is we embed as a managed resource in this program.

            // The first two arguments should always be "QuickOPC" and "Multipurpose".
            // The third argument determines the assembly where the license resides.
            // The fourth argument is the namespace-qualified name of the managed resource, or a pattern identifying it.
            // We could use precise "UADocExamples.Licensing.Key-DemoOrTrial-WebForm-1999003494-20180611.bin" instead.
            try
            {
                LicensingManagement.Instance.RegisterManagedResourceWithExistenceCheck("QuickOPC", "Multipurpose",
                    Assembly.GetExecutingAssembly(), "*.Key-*.*");
            }
            // This exception will be thrown if the specified managed resource does not exist or is not accessible.
            // Note, however, that the validity of the license is not checked at this point.
            // You can experiment with this code path by modifying the resource name in the call above.
            catch (CustomException customException)
            {
                Console.WriteLine($"*** Failure: {customException.Message}");
                return;
            }

            // Instantiate the client object, obtain the serial number from the license info, and display the serial number.
            var client = new EasyUAClient();
            long serialNumber = (uint)client.LicenseInfo["Multipurpose.SerialNumber"];
            Console.WriteLine("SerialNumber: {0}", serialNumber);

            // The license we ship for this purpose is a trial license with low runtime limit, so it won't be of much use.
            // But you get the point...
        }
    }
}
#endregion
