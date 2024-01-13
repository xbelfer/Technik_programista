namespace GraphicsView
{
    public partial class MainPage : ContentPage
    {
        int i = 0;
        public MainPage()
        {
            InitializeComponent();
        }

		private void ClickElipse(object sender, TouchEventArgs e)
		{
            ++i;
            lbElipse.Text = $"Clicked Elipse {i}";
        }
    }

}
