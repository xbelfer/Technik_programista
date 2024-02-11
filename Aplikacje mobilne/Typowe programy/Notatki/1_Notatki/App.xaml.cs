namespace _1_Notatki;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new AppShell();
	}
    protected override Window CreateWindow(IActivationState activationState) =>
    new Window(new AppShell())
    {
        Width = 300,
        Height = 600,
        X = 1200,
        Y = 100
    };
}
