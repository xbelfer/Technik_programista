namespace Animations
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await image.FadeTo(0);
            await Task.Delay(1000);
			await image.FadeTo(1);

			await image.ScaleTo(0, easing: Easing.SpringIn);
			await Task.Delay(1000);
			await image.ScaleTo(1, easing: Easing.SpringOut);

            await image.RotateTo(180, 500, Easing.CubicInOut);
			await Task.Delay(1000);
			await image.RotateTo(360, 500, Easing.CubicInOut);
			await Task.Delay(1000);
			image.Rotation = 0;

			await image.TranslateTo(0, -50, 250, Easing.CubicInOut);
			await Task.Delay(1000);
			await image.TranslateTo(0, 0, 250, Easing.CubicInOut);
			await Task.Delay(1000);
			

			await Task.WhenAny(
                image.RotateTo(360, 500, Easing.CubicInOut),
                image.TranslateTo(0, -50, 250, Easing.CubicInOut)
            );
			await image.TranslateTo(0, 0, 250, Easing.CubicInOut);
			image.Rotation = 0;

			await CounterBtn.RotateTo(180, 500, Easing.CubicInOut);
			await Task.Delay(1000);
			await CounterBtn.RotateTo(360, 500, Easing.CubicInOut);
			await Task.Delay(1000);
			CounterBtn.Rotation = 0;
		}
    }

}
