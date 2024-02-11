using System.Diagnostics;

namespace CyklZycia2
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new AppShell();
		}

		protected override void OnStart()
		{
			Debug.WriteLine("1. OnStart event occured");
		}
		protected override void OnSleep()
		{
			Debug.WriteLine("2. OnSleep event occured");
		}
		protected override void OnResume()
		{
			Debug.WriteLine("3. OnResume event occured");
		}
		
	}
}
