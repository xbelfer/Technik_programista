using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace _8_Nawigacja_Stos.Pages;

using _8_Nawigacja_Stos.Model;
using static System.Net.Mime.MediaTypeNames;

public partial class Form : ContentPage
{
	public Form()
	{
		InitializeComponent();
	}


    private void OnBtnClicked_AddNewCar(object sender, EventArgs e)
    {
        if(entryId.Text != "" && entryBrand.Text != "" && entryModel.Text != ""
            && entryColor.Text != "" && entryYear.Text != "" && entryMileage.Text != ""
            && entryPrice.Text != "" && entryImage.Text != "")
        {
            int id = Convert.ToInt32(entryId.Text);
            string brand = entryBrand.Text;
            string model = entryModel.Text;
            string color = entryColor.Text;
            int year = Convert.ToInt32(entryYear.Text);
            int mileage = Convert.ToInt32(entryMileage.Text);
            double price = Convert.ToDouble(entryPrice.Text);
            string image = entryImage.Text;

            Cars.carsList.Add(new Car(id,brand,model,color,year,mileage,price,image));
        }

		string path = FileSystem.Current.AppDataDirectory;
		string fullPath = Path.Combine(path, "cars.xml");
		FileStream fs = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.Write);
		StreamWriter sw = new StreamWriter(fs);
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Car>));
		xmlSerializer.Serialize(sw, Cars.carsList);
		sw.Close();

    }
}