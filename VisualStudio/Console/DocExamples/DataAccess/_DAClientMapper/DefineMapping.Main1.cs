// $Header: $
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable UnusedAutoPropertyAccessor.Local
#region Example
// This example for OPC DA type-less mapping shows how to define a mapping and perform a read operation.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;
using OpcLabs.BaseLib.ComponentModel.Linking;
using OpcLabs.EasyOpc.DataAccess;
using OpcLabs.EasyOpc.DataAccess.LiveMapping;

namespace DocExamples.DataAccess._DAClientMapper
{
    partial class DefineMapping
    {
        class MyClass2
        {
            public object Value { get; set; }
        }

        public static void Main1()
        {
            #region Example-DefineAndRead
            // Instantiate the client mapper object.
            var mapper = new DAClientMapper();

            var target = new MyClass2();

            // Define a type-less mapping.

            mapper.DefineMapping(
                 new DAClientItemSource("OPCLabs.KitServer.2", "Simulation.Register_I4", DADataSource.Cache),
                 new DAClientItemMapping(typeof(Int32)),
                 new ObjectMemberLinkingTarget(target.GetType(), target, "Value"));

            // Perform a read operation.
            mapper.Read();
            #endregion

            // Display the result.
            Console.WriteLine(target.Value);
        }
    }
}
#endregion
