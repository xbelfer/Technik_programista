using Microsoft.Extensions.Logging;
using StudentSecondExample.ViewModels;
using StudentSecondExample.Views;

namespace StudentSecondExample
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif
			builder.Services.AddSingleton<StudentViewModel>();
			builder.Services.AddSingleton<StudentListViewModel>();
			builder.Services.AddSingleton<StudentView>();
			builder.Services.AddSingleton<StudentListView>();
			return builder.Build();
		}
	}
}
