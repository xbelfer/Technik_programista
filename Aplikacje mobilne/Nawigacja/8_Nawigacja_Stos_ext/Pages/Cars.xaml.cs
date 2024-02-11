using _8_Nawigacja_Stos.Model;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace _8_Nawigacja_Stos.Pages;

public partial class Cars : ContentPage
{
    public static ObservableCollection<Car> carsList = new ObservableCollection<Car>();
	public Cars()
	{
		InitializeComponent();

        //carsList.Add(new Car(1, "Opel", "Astra", "Czerwony", 2012, 180000, 16000, "https://img.chceauto.pl/opel/astra/opel-astra-hatchback-5-drzwiowy-1585-7726_v1.jpg"));
        //carsList.Add(new Car(2, "Ford", "Mondeo", "Srebrny", 2018, 120000, 56000, "https://img.chceauto.pl/ford/mondeo/ford-mondeo-sedan-2826-21863_v1.jpg"));
        LoadFromFile();
        cvCars.ItemsSource = carsList;
    }

    private void LoadFromFile()
    {
        string path = FileSystem.Current.AppDataDirectory;
        string fullPath = Path.Combine(path, "cars.xml");

        if (File.Exists(fullPath))
        {
            FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Car>));
            Cars.carsList = (ObservableCollection<Car>) xmlSerializer.Deserialize(sr);
            sr.Close();
        }
    }
    private async void OnSelectionChanged_cvCars(object sender, SelectionChangedEventArgs e)
    {
        //int idCar = ((Car)sender).Id;
        int idCar = (e.CurrentSelection.FirstOrDefault() as Car).Id;
        await Shell.Current.GoToAsync($"carDetails?idCar={idCar}");
    }

    /*
    private async void OpelBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("carDetails?carBrand=Opel");
    }

    */

}