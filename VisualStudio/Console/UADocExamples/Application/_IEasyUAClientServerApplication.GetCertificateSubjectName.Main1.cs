// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable LocalizableElement
// ReSharper disable PossibleNullReferenceException
#region Example
// Shows how to get the subject name of application certificates.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.EasyOpc.UA.Application;
using OpcLabs.EasyOpc.UA.Application.Extensions;

namespace UADocExamples.Application._IEasyUAClientServerApplication
{
    class GetCertificateSubjectName
    {
        public static void Main1()
        {
            // Obtain the application interface.
            EasyUAApplication application = EasyUAApplication.Instance;

            // Get the subject name of application certificates.
            string certificateSubjectName = application.GetCertificateSubjectName();

            // Display results
            Console.WriteLine("Certificate subject name: {0}", certificateSubjectName);
        }
    }
}
#endregion
