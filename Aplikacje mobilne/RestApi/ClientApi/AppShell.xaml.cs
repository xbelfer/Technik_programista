namespace ClientApi;
using ClientApi.Pages;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("addPart", typeof(AddPartPage));
        Routing.RegisterRoute("updatePart", typeof(UpdatePartPage));
    }
}
