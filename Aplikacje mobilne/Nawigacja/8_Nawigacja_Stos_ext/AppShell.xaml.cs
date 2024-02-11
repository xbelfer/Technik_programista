namespace _8_Nawigacja_Stos;
using _8_Nawigacja_Stos.Pages;
public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("carDetails", typeof(CarDetails));
	}
}
