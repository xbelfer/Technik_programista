namespace _2_Notatki_Grid;

public partial class MainPage : ContentPage
{


	public MainPage()
	{
		InitializeComponent();
        notatki.Text = "Zrobić zakupy na weekend";
        notatki.Text += "\nNaprawić błędy w kodzie";
        notatki.Text += "\nOdebrać samochód z warsztatu";
    }

    private void DodajNotatke_Cliked(object sender, EventArgs e)
    {
        string nt = inp.Text.Trim();
        notatki.Text += "\n" + nt;
        inp.Text = String.Empty;
    }
}

