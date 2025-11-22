namespace GraKostkiMob
{
	public partial class MainPage : ContentPage
	{
		private int wynikGry;
		public MainPage()
		{
			InitializeComponent();
			wynikGry = 0;
		}

		private void RzutKosciami_ButtonClicked(object sender, EventArgs e)
		{
			List<int> wylosowaneLiczby = RzutKostkami(5);

			kostka1.Source = $"k{wylosowaneLiczby[0]}.jpg";
			kostka2.Source = $"k{wylosowaneLiczby[1]}.jpg";
			kostka3.Source = $"k{wylosowaneLiczby[2]}.jpg";
			kostka4.Source = $"k{wylosowaneLiczby[3]}.jpg";
			kostka5.Source = $"k{wylosowaneLiczby[4]}.jpg";

			int wynikPojedynczegoLosowania = PoliczPunkty(wylosowaneLiczby);
			lbPojedynczeLosowanie.Text = $"Wynik tego losowania: {wynikPojedynczegoLosowania}";
			wynikGry += wynikPojedynczegoLosowania;
			lbWynikGry.Text = $"Wynnik gry: {wynikGry}";

		}

		private void ResetujWynik_ButtonClicked(object sender, EventArgs e)
		{
			kostka1.Source = "question.jpg";
			kostka2.Source = "question.jpg";
			kostka3.Source = "question.jpg";
			kostka4.Source = "question.jpg";
			kostka5.Source = "question.jpg";

			int wynikPojedynczegoLosowania = 0;
			lbPojedynczeLosowanie.Text = $"Wynik tego losowania: {wynikPojedynczegoLosowania}";
			wynikGry = 0;
			lbWynikGry.Text = $"Wynnik gry: {wynikGry}";
		}

		private List<int> RzutKostkami(int iloscKostek)
		{
			List<int> wylosowaneLiczby = new List<int>();
			Random r = new Random();

			for (int i = 0; i < iloscKostek; i++)
			{
				wylosowaneLiczby.Add(r.Next(1, 7));
			}
			return wylosowaneLiczby;
		}

		private int PoliczPunkty(List<int> wylosowaneLiczby)
		{
			int sumaPunktow = 0;
			//Tablica pomocnicza w której zlicza się ilość wystąpień danej liczby
			//Rozmiar 7 ponieważ: pomijany będzie index 0, a wykorzystywany index 6
			int[] wielokrotnosci = new int[7];

			//Pętla która zlicza ilość wystąpień danej liczby oczek
			foreach (int x in wylosowaneLiczby)
			{
				++wielokrotnosci[x];
			}
			//Pętla która zlicza sumę oczek jeżeli dana liczba oczek wystąpiła więcej niż raz
			for (int i = 1; i < 7; i++)
			{
				if (wielokrotnosci[i] > 1)
					sumaPunktow += (i * wielokrotnosci[i]);
			}

			return sumaPunktow;
		}
	}

}
