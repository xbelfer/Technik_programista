namespace Przesylka
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void SprawdzCene_ButtonClicked(object sender, EventArgs e)
		{
			
			if (rbPaczka.IsChecked == true)
			{
				imgObrazPrzesylki.Source = "paczka.png";
				lbCenaPrzesylki.Text = "Cena: 10 zł";
			}
			else if (rbPocztowka.IsChecked == true)
			{
				imgObrazPrzesylki.Source = "pocztowka.png";
				lbCenaPrzesylki.Text = "Cena: 1 zł";
			}
			else if (rbList.IsChecked == true)
			{
				imgObrazPrzesylki.Source = "list.png";
				lbCenaPrzesylki.Text = "Cena: 1,5 zł";
			}
			
		}

		private void Zatwierdz_ButtonClicked(object sender, EventArgs e)
		{
			if(string.IsNullOrEmpty(tbKodPocztowy.Text))
			{
				DisplayAlert("Error", "Nieprawidłowa liczba cyfr w kodzie pocztowym", "OK");
				return;
			}
			string kodPocztowy = tbKodPocztowy.Text.Trim();

			if (kodPocztowy.Length != 5)
			{

				DisplayAlert("Error", "Nieprawidłowa liczba cyfr w kodzie pocztowym", "OK");
			}
			else if (!SprawdzCzyCyfry(kodPocztowy))
			{
				DisplayAlert("Error", "Kod pocztowy powinien się składać z samych cyfr", "OK");
			}
			else
			{
				DisplayAlert("Info", "Dane przesyłki zostały wprowadzone", "OK");
			}
		}

		private bool SprawdzCzyCyfry(string txtCyfry)
		{
			for (int i = 0; i < txtCyfry.Length; i++)
			{
				if (!char.IsDigit(txtCyfry[i]))
					return false;
			}
			return true;
		}
	}

}
