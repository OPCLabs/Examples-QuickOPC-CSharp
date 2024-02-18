<Query Kind="Statements">
  <NuGetReference>OpcLabs.QuickOpc</NuGetReference>
  <NuGetReference>OpcLabs.QuickOpc.Forms</NuGetReference>
  <Namespace>OpcLabs.EasyOpc.UA</Namespace>
  <Namespace>OpcLabs.EasyOpc.UA.Forms.Browsing</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

var dataDialog = new UADataDialog()
{
  EndpointDescriptor = "opc.tcp://opcua.demo-this.com:51210/UA/SampleServer"
};

if (dataDialog.ShowDialog() == DialogResult.OK)
dataDialog.NodeElement.Dump(1);
