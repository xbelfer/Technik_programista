namespace SyntezaMowy
{
	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();
			pobierzGlosy();
		}

		private Locale[] glosy;
		private int indeksWybranegoGlosu = -1;
		private async void pobierzGlosy()
		{
			IEnumerable<Locale> _glosy = await TextToSpeech.GetLocalesAsync();
			glosy = _glosy.ToArray();
			lvGlosy.ItemsSource = glosy.Select(g => g.Name);

			if(glosy.Length > 0)
			{
				indeksWybranegoGlosu = 0;
				lvGlosy.SelectedItem = glosy.ElementAt(0).Name;
				btnCzytaj.IsEnabled = true;
			}
			else
			{
				btnCzytaj.IsEnabled = false;
			}
			
		}

		private void lvGlosy_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			indeksWybranegoGlosu = e.SelectedItemIndex;
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			SpeechOptions so = new SpeechOptions();
			so.Volume = (float)sGlosnosc.Value;
			so.Pitch = (float)sTon.Value;
			so.Locale = glosy.ElementAt(indeksWybranegoGlosu);
			string tekst = edText.Text;
			await TextToSpeech.Default.SpeakAsync(tekst, so);
		}
	}

}
