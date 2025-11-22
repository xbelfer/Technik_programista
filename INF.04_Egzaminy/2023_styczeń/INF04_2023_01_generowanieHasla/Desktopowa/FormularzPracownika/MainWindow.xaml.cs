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

namespace FormularzPracownika
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			/* Można też tak zainicjować elementy ComboBox 
			comboStanowisko.ItemsSource = new List<string>()
			{
				"Kierownik",
				"Starszy programista",
				"Młodszy programista",
				"Tester"
			};
			*/
			haslo = "";
		}

		private void Zatwierdz_ButtonClicked(object sender, RoutedEventArgs e)
		{
			string msg = "Dane pracownika: ";
			msg += $"{tbImie.Text} ";
			msg += $"{tbNazwisko.Text} ";
			if(comboStanowisko.SelectedIndex >= 0)
				msg += $"{comboStanowisko.Text} ";
			msg += " Hasło: ";
			msg += $"{haslo}";
			MessageBox.Show(msg);
		}

		private string haslo;
		private void GenerujHaslo_ButtonClicked(object sender, RoutedEventArgs e)
		{
			string maleLitery = "qwertyuiopasdfghjklzxcvbnm";
			string duzeLitery = "QWERTYUIOPASDFGHJKLZXCVBNM";
			string cyfry = "0123456789";
			string specjalne = "!@#$%^&*()_+-=";
			
			Random rd = new Random();
			haslo = "";

			if( string.IsNullOrEmpty(tbIleZnakow.Text))
			{
				MessageBox.Show(haslo);
				return;
			}

			int iloscZnakow = Convert.ToInt32(tbIleZnakow.Text);
			if (iloscZnakow <= 0)
			{
				MessageBox.Show(haslo);
				return;
			}

			if (cbMaleWielkieLitery.IsChecked == true)
			{
				haslo += duzeLitery[rd.Next(0, duzeLitery.Length)];
			}

			if (haslo.Length >= iloscZnakow)
			{
				MessageBox.Show(haslo);
				return;
			}

			if (cbCyfry.IsChecked == true)
			{
				haslo += cyfry[rd.Next(0, cyfry.Length)];
			}

			if (haslo.Length >= iloscZnakow)
			{
				MessageBox.Show(haslo);
				return;
			}

			if(cbZnakiSpecjalne.IsChecked == true)
			{
				haslo += specjalne[rd.Next(0,specjalne.Length)];
			}

			for (int i = haslo.Length; i < iloscZnakow; i++)
			{
				haslo += maleLitery[rd.Next(0,maleLitery.Length)];
			}

			MessageBox.Show(haslo);
		}
	}
}