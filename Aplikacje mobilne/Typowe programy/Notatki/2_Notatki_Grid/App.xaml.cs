﻿namespace _2_Notatki_Grid;

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
        Width = 400,
        Height = 800,
        X = 1000,
        Y = 50
    };
}
