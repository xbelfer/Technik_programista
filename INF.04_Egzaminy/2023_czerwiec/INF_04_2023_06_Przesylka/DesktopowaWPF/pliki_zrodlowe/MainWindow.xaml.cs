using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Przesylka
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void SprawdzCene_ButtonClicked(object sender, RoutedEventArgs e)
		{
			if (rbPaczka.IsChecked == true)
			{
				imgObrazPrzesylki.Source = new BitmapImage(new Uri("paczka.png", UriKind.Relative));
				lbCenaPrzesylki.Content = "Cena: 10 zł";
			}
			else if (rbPocztowka.IsChecked == true)
			{
				imgObrazPrzesylki.Source = new BitmapImage(new Uri("pocztowka.png", UriKind.Relative));
				lbCenaPrzesylki.Content = "Cena: 1 zł";
			}
			else if (rbList.IsChecked == true)
			{
				imgObrazPrzesylki.Source = new BitmapImage(new Uri("list.png", UriKind.Relative));
				lbCenaPrzesylki.Content = "Cena: 1,5 zł";
			}
		}

		private void Zatwierdz_ButtonClicked(object sender, RoutedEventArgs e)
		{
			string kodPocztowy = tbKodPocztowy.Text.Trim();

			if (kodPocztowy.Length != 5)
			{
				MessageBox.Show("Nieprawidłowa liczba cyfr w kodzie pocztowym");
			}
			else if (!SprawdzCzyCyfry(kodPocztowy))
			{
				MessageBox.Show("Kod pocztowy powinien się składać z samych cyfr");
			}
			else
			{
				MessageBox.Show("Dane przesyłki zostały wprowadzone");
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