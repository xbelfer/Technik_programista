using Microsoft.Win32;
using System.IO;
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

namespace SzyfrCezaraApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		// Prywatne pole przechowujące instancję logiki szyfrowania
		private readonly KlasaSzyfrCezara _logikaSzyfru;
		public MainWindow()
		{
			InitializeComponent();
			_logikaSzyfru = new KlasaSzyfrCezara();
		}

		// 1. Obsługa przycisku "Zaszyfruj" (ZaszyfrujButton_Click)
		// Cel: Pobranie tekstu i klucza, szyfrowanie i wyświetlenie wyniku.
		private void ZaszyfrujButton_Click(object sender, RoutedEventArgs e)
		{
			// Krok 1: Pobranie tekstu jawnego
			string tekstJawny = TekstJawnyTextBox.Text;

			// Krok 2: Pobranie i walidacja klucza
			int kluczSzyfrowania = PobierzKluczZWalidacja(KluczTextBox.Text);

			// Krok 3: Wywołanie metody szyfrującej
			string zaszyfrowanyTekst = _logikaSzyfru.SzyfrujCezarem(tekstJawny, kluczSzyfrowania);

			// Krok 4: Wyświetlenie wyniku w kontrolce TekstZaszyfrowanyTextBlock
			TekstZaszyfrowanyTextBlock.Text = zaszyfrowanyTekst;
		}


		private int PobierzKluczZWalidacja(string kluczTekst)
		{
			if (int.TryParse(kluczTekst, out int klucz))
			{
				return klucz;
			}
			// Zgodnie z założeniem: Jeżeli w polu klucza nie została wpisana wartość liczbowa,
			// należy zastosować wartość klucza 0.
			return 0;
		}

		// 2. Obsługa przycisku "Zapisz szyfr w pliku" (ZapiszButton_Click)
		// Cel: Otwarcie systemowego okna dialogowego i zapis zaszyfrowanego tekstu.
		private void ZapiszButton_Click(object sender, RoutedEventArgs e)
		{
			string tekstDoZapisu = TekstZaszyfrowanyTextBlock.Text;

			if (string.IsNullOrEmpty(tekstDoZapisu))
			{
				MessageBox.Show("Brak tekstu do zapisu. Najpierw zaszyfruj tekst.", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			// Utworzenie systemowego okna dialogowego do zapisu pliku
			SaveFileDialog dialogZapisz = new SaveFileDialog();

			// Ustawienie domyślnych filtrów i nazwy pliku
			dialogZapisz.FileName = "zaszyfrowany_tekst"; // Domyślna nazwa pliku
			dialogZapisz.DefaultExt = ".txt"; // Domyślne rozszerzenie
			dialogZapisz.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";

			// Wyświetlenie okna dialogowego
			if (dialogZapisz.ShowDialog() == true)
			{
				try
				{
					// Zapis zaszyfrowanego tekstu do wybranego pliku
					File.WriteAllText(dialogZapisz.FileName, tekstDoZapisu);
					MessageBox.Show($"Zaszyfrowany tekst zapisano pomyślnie w pliku:\n{dialogZapisz.FileName}", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				catch (IOException ex)
				{
					MessageBox.Show($"Wystąpił błąd podczas zapisu pliku: {ex.Message}", "Błąd zapisu", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}
	}
}