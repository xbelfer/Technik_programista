using Egzamin_inf04.Model;
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

namespace Egzamin_inf04
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public List<Song> Songs {  get; set; }
		private int indexOfAlbum = 0;
		public MainWindow()
		{
			InitializeComponent();
			Songs = new List<Song>();
			LoadSongsFromFile("Data.txt");
			DisplaySong();
		}

		private void LoadSongsFromFile(string filename)
		{
			try
			{
				FileStream fs = new FileStream("Data.txt", FileMode.Open, FileAccess.Read);
				StreamReader sr = new StreamReader(fs);
				string line = null;
				while ((line = sr.ReadLine()) != null)
				{
					Song tmp = new Song();
					tmp.Artist = line;
					line = sr.ReadLine();
					tmp.Album = line;
					line = sr.ReadLine();
					tmp.SongsNumber = Convert.ToInt32(line);
					line = sr.ReadLine();
					tmp.YearOfEdition = Convert.ToInt32(line);
					line = sr.ReadLine();
					tmp.DownloadNumber = Convert.ToInt32(line);
					line = sr.ReadLine();

					Songs.Add(tmp);
				}
				sr.Close();
				fs.Close();
			}
			catch(Exception ex)
			{

			}
		}

		private void DisplaySong()
		{
			Song song = Songs[indexOfAlbum];
			lbArtist.Content = song.Artist;
			lbAlbum.Content = song.Album;
			lbNumber.Content = song.SongsNumber + " utworów ";
			lbYear.Content = song.YearOfEdition;
			lbNumDownload.Content = song.DownloadNumber;
		}

		private void DownloadAlbum_Clicked(object sender, RoutedEventArgs e)
		{
			Songs[indexOfAlbum].DownloadNumber++;
			DisplaySong();
		}

		private void LeftArrow_Clicked2(object sender, RoutedEventArgs e)
		{
			--indexOfAlbum;
			if (indexOfAlbum < 0)
			{
				indexOfAlbum = Songs.Count - 1;
			}
			DisplaySong();
		}

		private void RightArrow_Clicked2(object sender, RoutedEventArgs e)
		{
			++indexOfAlbum;
			if (indexOfAlbum >= Songs.Count)
			{
				indexOfAlbum = 0;
			}
			DisplaySong();
		}
	}
}