using NavigationRouting.Model;

namespace NavigationRouting.Pages;

[QueryProperty(nameof(CarDetail),"Car")]
public partial class CarDetailPage : ContentPage
{
	Car carDetail;

	public Car CarDetail
	{
		get => carDetail;
		set
		{
			carDetail = value;
			OnPropertyChanged();
		}
	}
	public CarDetailPage()
	{
		InitializeComponent();
		BindingContext = this;
	}
}