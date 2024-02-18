// ReSharper disable ConvertIfStatementToNullCoalescingExpression

//
// Find all latest examples here: https://opclabs.doc-that.com/files/onlinedocs/OPCLabs-OpcStudio/Latest/examples.html .

using OpcLabs.EasyOpc.DataAccess;

namespace QualityStrings
{
	public partial class Form1
	{

	    // ReSharper disable once NotNullMemberIsNotInitialized
		internal Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			//define the quality codes that we want to run thru our function as a test
			int[] qualityTests = {0, 10, 50, 64, 100, 128, 150, 192, 210};

			//now test each of the quality codes defined above
			foreach (int qualityTest in qualityTests)
			{
				ListBox1.Items.Add(new DAQuality(qualityTest).ToString());
			}
		}

	    private static Form1 _defaultInstance;

	    public static Form1 DefaultInstance
	    {
		    get
		    {
			    if (_defaultInstance is null)
				    _defaultInstance = new Form1();

			    return _defaultInstance;
		    }
	    }
	}
}
