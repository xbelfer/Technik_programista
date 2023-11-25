namespace ClientApi.Pages;

using ClientApi.Model;
using System.Diagnostics;

/* Atrybut [QueryProperty] który ³¹czy parametr wywo³ania podstrony "partId" z 
 * w³aœciwoœci¹ klasy IdPart (klasy UpdatePartPage). Dziêki temu zapisowi w trakcie
 * tworzenia nowego obiektu klasy UpdatePartPage (w wyniku wywo³ania tej podstrony)
 * wartoœæ która jest zapisana pod kluczem "partId" zapytania wywo³uj¹cego t¹ podstronê
 * zapisuje siê we w³aœciwoœci IdPart - i otrzymujemy id przekazanego elementu.
 */
[QueryProperty(nameof(IdPart),"partId")]
public partial class UpdatePartPage : ContentPage
{
	string idPart;

	public string IdPart
	{
		get { return idPart; }
		set
		{
			idPart = value;
			/*Wywo³anie metody OnPropertyChanged - reakcja za zmianê wartoœci IdPart*/
			Task.Run(OnPropertyChanged);
		}
	}

	/* Metoda OnPropertyChanged wype³nia elementy formularza wartoœciami w³aœciwosci
	 * obiektu Part klikniêtego na liœcie czêœci. Otrzymaliœmy jego id i zapisaliœmy
	 * w IdPart wiêc pobieramy za pomoc¹ API ca³y obiekt o tym Id i wype³niamy jego
	 * wartoœciami formularz
	 */
	public async Task OnPropertyChanged()
	{
		Part loadPart = await PartsManager.GetPart(IdPart);

		/*Sytuacja taka sama jak opisana w PartsPage.xaml.cs */
		MainThread.BeginInvokeOnMainThread(() =>
		{
			part_id.Text = loadPart.PartID;
			partName.Text = loadPart.PartName;
			partType.Text = loadPart.PartType;
			partSupplier.Text = loadPart.SupplierString;
		});
	}
	public UpdatePartPage()
	{
		InitializeComponent();
	}

    /*
	 * U¿yte zosta³o okno dialogowe wiêcej informacji:
	 * https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pop-ups?view=net-maui-8.0
	 * U¿yte zosta³ mechanizm rozg³aszania wiadomoœci, wiêcej informacji
	 * https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/messagingcenter?view=net-maui-8.0
	 */
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert($"Ta operacja jest nie odwracalna", "Czy napewno chcesz zmodyfikowaæ ten element?", "Yes", "No");
        if (answer)
        {
			Part updatePart = new Part
			{
				PartID = part_id.Text,
				PartName = partName.Text,
				PartType = partType.Text,
				Suppliers = partSupplier.Text.Split(',').ToList()
			};
            bool response = await PartsManager.Update(updatePart);
            if (response)
            {
				/*Rozg³oszenie wiadomoœci przechwytywanej przez subskrybentów 
				 Wiadomoœæ informuj¹ca o koniecznoœci prze³adowania listy
				 wyœwietlaj¹cej czêœci, po modyfikacji danych na serwerze
				*/
                MessagingCenter.Send<UpdatePartPage>(this, "UpdateList");
            }
            await DisplayAlert("Alert", "Element zosta³ zmieniony", "OK");
        }

		/*Powrót do strony nadrzêdnej*/
        await Shell.Current.GoToAsync("..");

    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert($"Ta operacja jest nie odwracalna", "Czy napewno chcesz skasowaæ ten element?", "Yes", "No");
        if(answer)
		{
			bool response = await PartsManager.Delete(IdPart);
			if(response)
			{
                /*Rozg³oszenie wiadomoœci przechwytywanej przez subskrybentów */
                MessagingCenter.Send<UpdatePartPage>(this, "UpdateList");
			}
            await DisplayAlert("Alert", "Element zosta³ usuniêty", "OK");
        }

        /*Powrót do strony nadrzêdnej*/
        await Shell.Current.GoToAsync("..");
    }

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
        /*Powrót do strony nadrzêdnej*/
        await Shell.Current.GoToAsync("..");
    }
}