
using System.Diagnostics;

namespace CyklZycia1
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new AppShell();
		}

		protected override Window CreateWindow(IActivationState? activationState)
		{
			Window window =  base.CreateWindow(activationState);

			window.Created += (s,e) => 
			{
				Debug.WriteLine("1. Zdarzenie Created");
			};

			window.Activated += (s, e) =>
			{
				Debug.WriteLine("2. Zdarzenie Activated");
			};

			window.Deactivated += (s, e) =>
			{
				Debug.WriteLine("3. Zdarzenie Deactivated");
			};

			window.Stopped += (s, e) =>
			{
				Debug.WriteLine("4. Zarzenie Stopped");
			};

			window.Resumed += (s, e) =>
			{
				Debug.WriteLine("5. Zdarzenie Reasumed");
			};

			window.Destroying += (s, e) =>
			{
				Debug.WriteLine("6. Zdarzenie Destroying");
			};


			return window;
		}

	}
}
