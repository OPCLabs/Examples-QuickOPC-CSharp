<Query Kind="Expression">
  <NuGetReference>OpcLabs.QuickOpc</NuGetReference>
  <Namespace>OpcLabs.EasyOpc.UA</Namespace>
</Query>

new EasyUAClient()
	//.BrowseDataNodes("http://opcua.demo-this.com:51211/UA/SampleServer")
	.BrowseDataNodes("opc.tcp://opcua.demo-this.com:51210/UA/SampleServer")
