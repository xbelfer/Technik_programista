using NavigationRouting.Model;

namespace NavigationRouting
{
	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();
		}


		private async void DetailPage_ButtonCliced(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("pages/details");
        }

		private async void CarDetailPage_ButtonCliced(object sender, EventArgs e)
		{
			if(sender is Button)
				await DisplayAlert("Button", "OK", "OK");

			if(sender is Image)
			{
				var img = (Image)sender;
				await DisplayAlert("Image", img.Source.ToString(), "OK");
				
			}

			Car car = new Car("Opel", "Astra", 120000, 16000);
			var navParameter = new Dictionary<string, object> 
			{
				{"Car",car }
			};
			await Shell.Current.GoToAsync("pages/cardetails", navParameter);
		}

		private async void ParameterDetailPage_ButtonCliced(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("pages/parameterdetails?Parameter=987");
		}
	}

}
