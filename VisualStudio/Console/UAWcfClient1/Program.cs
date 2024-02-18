// UAWcfClient1: Using a Web service provided by the UAWcfService1 project (under Web folder), gets and displays a value of
// an OPC UA variable.
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System;

namespace UAWcfClient1
{
    class Program
    {
        static void Main()
        {
            var client = new Service1Client();

            // Use the 'client' variable to call operations on the service.
            // The following call may throw an exception in case of an error. Production-quality code should catch and
            // handle the exceptions appropriately.
            string data = client.GetData();
            Console.WriteLine(data);
            Console.ReadLine();

            // Always close the client.
            client.Close();
        }
    }
}
