<Query Kind="Expression">
  <NuGetReference>OpcLabs.QuickOpc</NuGetReference>
  <Namespace>OpcLabs.EasyOpc.UA</Namespace>
  <Namespace>OpcLabs.EasyOpc.UA.Reactive</Namespace>
</Query>
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

UADataChangeNotificationObservable.Create<int>(
	"opc.tcp://opcua.demo-this.com:51210/UA/SampleServer",
	"nsu=http://test.org/UA/Data/;i=11017",
	100)