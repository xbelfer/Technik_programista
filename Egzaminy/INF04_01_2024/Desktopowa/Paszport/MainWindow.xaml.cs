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

namespace Paszport
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

		private void TextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			imgZdjecie.Source = new BitmapImage(new Uri($"img/{tbNumer.Text}-zdjecie.jpg", UriKind.Relative));
			imgOdcisk.Source = new BitmapImage(new Uri($"img/{tbNumer.Text}-odcisk.jpg", UriKind.Relative));
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if(tbImie.Text != "" && tbNazwisko.Text != "")
			{
				string kolorOczu = "";
				if (rbNiebieskie.IsChecked == true)
					kolorOczu = "niebieskie";
				if (rbPiwne.IsChecked == true)
					kolorOczu = "piwne";
				if (rbZielone.IsChecked == true)
					kolorOczu = "zielone";

				string info = $"{tbImie.Text} {tbNazwisko.Text} kolor oczu {kolorOczu}";
				MessageBox.Show(info, "Dane", MessageBoxButton.OK);

			}
			else
			{
				MessageBox.Show("Wprowadź dane", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}
	}
}