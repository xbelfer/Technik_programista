using NavigationRouting.Pages;
namespace NavigationRouting
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute("pages/details", typeof(DetailPage));
			Routing.RegisterRoute("pages/parameterdetails", typeof(ParameterDetailPage));
			Routing.RegisterRoute("pages/cardetails", typeof(CarDetailPage));
		}
	}
}
