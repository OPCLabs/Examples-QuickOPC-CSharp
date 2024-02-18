﻿// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable ArrangeModifiersOrder
// ReSharper disable CheckNamespace
// ReSharper disable AssignNullToNotNullAttribute
#region Example
// Shows how to copy an OPC UA file, using the file provider model.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.BaseLib.Extensions.FileProviders;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.Extensions;
using OpcLabs.EasyOpc.UA.FileTransfer;

namespace UADocExamples.FileProviders._WritableFileInfo
{
    class CopyTo
    {
        public static void Main1()
        {
            // Unified Automation .NET based demo server (UaNETServer/UaServerNET.exe)
            var endpointDescriptor = new UAEndpointDescriptor("opc.tcp://localhost:48030")
                .WithUserNameIdentity("john", "master");

            // A node that represents an OPC UA file system (a root directory).
            UANodeDescriptor fileSystemNodeDescriptor = "nsu=http://www.unifiedautomation.com/DemoServer/ ;s=Demo.Files.FileSystem";

            // Create a random number generator - will be used for file/directory names.
            var random = new Random();

            // Instantiate the file transfer client object
            var fileTransferClient = new EasyUAFileTransferClient();

            Console.WriteLine("Getting writable file provider...");
            IWritableFileProvider writableFileProvider =
                fileTransferClient.GetWritableFileProvider(endpointDescriptor, fileSystemNodeDescriptor);
            // From this point onwards, the code is independent of the concrete realization of the file provider, and would
            // be identical e.g. for files in the physical file system, if the corresponding file provider was used.

            // Create a file, and a directory. Then, copy the file into the directory.
            try
            {
                string fileName = "MyFile-" + random.Next();
                Console.WriteLine($"Creating file, '{fileName}'...");
                IWritableFileInfo writableFileInfo = writableFileProvider.GetWritableFileInfo(fileName);
                writableFileInfo.WriteAllBytes(Array.Empty<byte>());

                string directoryName = "MyDirectory-" + random.Next();
                Console.WriteLine($"Creating directory, '{directoryName}'...");
                IWritableDirectoryContents writableDirectoryContents = writableFileProvider.GetWritableDirectoryContents(directoryName);
                writableDirectoryContents.Create();

                Console.WriteLine("Copying the file...");
                writableFileInfo.CopyTo(FormattableString.Invariant($"{directoryName}/{fileName}"));
            }
            // Methods in the file provider model throw IOException and other exceptions, but not UAException.
            catch (Exception exception)
            {
                Console.WriteLine($"*** Failure: {exception.GetBaseException().Message}");
                return;
            }

            Console.WriteLine("Finished...");
        }
    }
}
#endregion
