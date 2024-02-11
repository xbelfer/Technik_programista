namespace _8_Nawigacja_Stos.Pages;

using _8_Nawigacja_Stos.Model;

[QueryProperty(nameof(BrandCar),"carBrand")]
[QueryProperty(nameof(IdCar), "idCar")]
public partial class CarDetails : ContentPage
{
	string brandCar;
	int idCar;

	public int IdCar
	{
		get => idCar;
		set
		{
			idCar = value;
			OnPropertyChanged();
		}
	}

	public void OnPropertyChanged()
	{
		Car selectedCar = Cars.carsList.Where(car => car.Id == IdCar).First();

		lbMarka.Text = selectedCar.Brand;
		photoCar.Source = selectedCar.Image;
		lbModel.Text = selectedCar.Model;
	}

	public string BrandCar
	{
		get { return brandCar; }
		set { 
			brandCar = value;
		}
	}
	public CarDetails()
	{
		InitializeComponent();
	}
}