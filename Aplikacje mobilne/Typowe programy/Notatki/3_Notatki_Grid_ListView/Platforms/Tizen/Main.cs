using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace _3_Notatki_Grid_ListView;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
