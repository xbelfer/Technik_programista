using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonsolaCD
{
	internal class Program
	{
		public List<Song> Songs { get; set; }
		private int indexOfAlbum = 0;

		public Program()
		{
			Songs = LoadSongsFromFile("Data.txt");
		}
		static void Main(string[] args)
		{
			Program pr = new Program();
			foreach(Song song in pr.Songs)
			{
				Console.WriteLine(song.GetDataSong());
			}
			Console.ReadKey();
		}

		/****************************************************************
		 * nazwa metody:		LoadSongsFromFile
		 * opis metody:			Metoda czyta plik o ścieżce podanej jako argument i dane z pliku
		 *						wczytuje do listy o elementach typu Song którą zwraca.
		 * parametry:			filePath typu string będący ścieżką dostępu do pliku
		 * zwracany typ i opis: List<Song> lista o elementach typu Song wypełniona danymi z pliku
		 * autor:				 000000000000
		 *****************************************************************/
		private List<Song> LoadSongsFromFile(string filePath)
		{
			List <Song> ret = new List<Song>();
			try
			{
				FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
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

					ret.Add(tmp);
				}

				sr.Close();
				fs.Close();
			}
			catch (Exception ex)
			{

			}

			return ret;
		}
	}
}
