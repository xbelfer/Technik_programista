using System.Collections.ObjectModel;

namespace _3_Notatki_Grid_ListView;

public partial class MainPage : ContentPage
{
	public ObservableCollection<string> Tasks { set; get; } = new ObservableCollection<string>();

	public MainPage()
	{
		InitializeComponent();
		
		Tasks.Add("Sprzątanie domu");
		Tasks.Add("Gotowanie");

        
    }

    private void DodajNotatke_Cliked(object sender, EventArgs e)
    {

    }
}

