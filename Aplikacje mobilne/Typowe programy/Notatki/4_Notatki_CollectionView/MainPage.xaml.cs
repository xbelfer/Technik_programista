using System.Collections.ObjectModel;

namespace _4_Notatki_CollectionView;

public partial class MainPage : ContentPage
{
	ObservableCollection<string> tasks = new ObservableCollection<string>();
	//List<string> tasks = new List<string>(); - zwykłe kolekcje nie uwidaczniają zmian na CollectionView
	public MainPage()
	{
		InitializeComponent();
		tasks.Add("Zmywanie");
		tasks.Add("Gotowanie");
		cv.ItemsSource = tasks;

	}

    private void DodajNotatke_Cliked(object sender, EventArgs e)
    {
		if(inp.Text.Length > 0)
		{
			tasks.Add(inp.Text);
		}
    }
}

