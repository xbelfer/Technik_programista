namespace WlasciwosciCzcionki
{
	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();
			indexCytat = 0;
		}

		private int indexCytat;
		private void ZmianaCytatu_ButtonClicked(object sender, EventArgs e)
		{
			string[] cytaty = { "Dzień dobry", "Good morning", "Buenos dias" };
			++indexCytat;

			if(indexCytat >= cytaty.Length)
			{
				indexCytat = 0;
			}

			lbCytat.Text = cytaty[indexCytat];
		}

		private void SliderRozmiar_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			int rozmiar = (int)Math.Floor(sliderRozmiar.Value);

			lbRozmiar.Text = $"Rozmiar: {rozmiar}";
			lbCytat.FontSize = rozmiar;
		}
	}

}
