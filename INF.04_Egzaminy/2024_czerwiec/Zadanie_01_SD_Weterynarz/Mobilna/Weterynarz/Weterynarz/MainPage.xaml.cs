namespace Weterynarz
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			listAnimals.ItemsSource = new List<string>() { "Pies", "Kot", "Świnka morska"};
		}

		private void AgeChanged_Slider(object sender, ValueChangedEventArgs e)
		{
			lbAge.Text = Math.Ceiling(sliderAge.Value).ToString();
		}

		private void Animals_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			String animal = e.SelectedItem as String;


			if (animal == "Pies")
				sliderAge.Maximum = 18;
			else if (animal == "Kot")
				sliderAge.Maximum = 20;
			else if(animal == "Świnka morska")
				sliderAge.Maximum = 9;
		}

		private async void Save_ButtonClicked(object sender, EventArgs e)
		{
			string msg = $"{entryName.Text}, {listAnimals.SelectedItem.ToString()}, " +
				$"{Math.Ceiling(sliderAge.Value)}, {entryCel.Text}, {dpTime.Time}";

			await DisplayAlert("Zapisana wizyta", msg, "OK");

		}
	}

}
