
// See also:
// https://docs.microsoft.com/en-us/dotnet/framework/windows-services/how-to-add-installers-to-your-service-application
//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using System.ComponentModel;

namespace UAWindowsService1
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
