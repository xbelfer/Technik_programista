namespace Geolokalizacja
{
	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();
		}

		private string opisPolozenia(Location polozenie)
		{
			double odlegloscOdTorunia = polozenie.CalculateDistance(new Location(53.0163331, 18,5911742), DistanceUnits.Kilometers);

			return $"Współrzędne geograficzne\n\tSzerokość: {polozenie.Latitude}" +
				$"\n\tDługość: {polozenie.Longitude}\n\tWysokość: {polozenie.Altitude}" +
				$"\n\tDokładność: {polozenie.Accuracy}\n\tAzymut: {polozenie.Course}" +
				$"\n\tOdległość od Torunia: {odlegloscOdTorunia}";
		}

		private bool czyPolozenieAktualnieOdczytywane = false;
		private CancellationTokenSource tokenOdczytuPolozenia;

		public async Task<Location> PobierzPolozenie(bool uzyjZapamietangoPolozenia = false)
		{
			try
			{
				czyPolozenieAktualnieOdczytywane = true;
				Location polozenie;
				if(!uzyjZapamietangoPolozenia)
				{
					GeolocationRequest zadanie = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
					tokenOdczytuPolozenia = new CancellationTokenSource();
					polozenie = await Geolocation.Default.GetLocationAsync(zadanie, tokenOdczytuPolozenia.Token);
				}
				else
				{
					polozenie = await Geolocation.Default.GetLastKnownLocationAsync();
				}
				if (polozenie == null)
					throw new Exception("Niemożliwe odczytanie lokalizacji");
				else
					return polozenie;
			}
			catch(FeatureNotSupportedException ex)
			{
				throw new Exception("Nie można odczytać lokalizacji na tym urządzeniu",ex);
			}
			catch (FeatureNotEnabledException ex)
			{
				throw new Exception("Odczyt lokalizacji nie jest dostępny", ex);
			}
			catch (PermissionException ex)
			{
				throw new Exception("Aplikacja nie ma uprawnień do odczytu lokalizacji", ex);
			}
			catch (Exception ex)
			{
				throw new Exception("Błąd w odczycie lokalizacji", ex);
			}
			finally
			{
				czyPolozenieAktualnieOdczytywane = false;
			}
		}

		public void AnulujZadaniePobraniaLokalizacji()
		{
			if (czyPolozenieAktualnieOdczytywane && tokenOdczytuPolozenia != null
				&& tokenOdczytuPolozenia.IsCancellationRequested == false)

				tokenOdczytuPolozenia.Cancel();
		}

		private async void pokazPolozenie()
		{
			btnOdswiezPolozenie.IsEnabled = false;
			Location lokalizacja = await PobierzPolozenie();
			lbPolozenie.Text = opisPolozenia(lokalizacja);
			btnOdswiezPolozenie.IsEnabled = true;
			btnOtworzMape.IsEnabled = true;
		}
		private async void mapButton_Clicked(object sender, EventArgs e)
		{
			btnOtworzMape.IsEnabled = false;
			Location polozenie = await PobierzPolozenie();
			await polozenie.OpenMapsAsync();
			btnOtworzMape.IsEnabled = true;
		}

		private void locationButton_Clicked(object sender, EventArgs e)
		{
			pokazPolozenie();
		}
	}

}
