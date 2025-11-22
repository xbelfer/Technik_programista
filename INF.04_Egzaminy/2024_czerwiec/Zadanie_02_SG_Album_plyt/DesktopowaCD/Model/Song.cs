using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egzamin_inf04.Model
{
	public class Song
	{
		public string Artist { get; set; }
		public string Album { get; set; }
		public int SongsNumber { get; set; }
		public int YearOfEdition { get; set; }
		public int DownloadNumber { get; set; }

		public Song() { }
		public Song(string Artist, string Album, int SongsNumber, int YearOfEdition, int DownloadNumber)
		{
			this.Artist = Artist;
			this.Album = Album;
			this.SongsNumber = SongsNumber;
			this.YearOfEdition = YearOfEdition;
			this.DownloadNumber = DownloadNumber;

		}
	}



}
