namespace ClientApi.Pages;

using ClientApi.Model;
using System.Diagnostics;

/* Atrybut [QueryProperty] kt�ry ��czy parametr wywo�ania podstrony "partId" z 
 * w�a�ciwo�ci� klasy IdPart (klasy UpdatePartPage). Dzi�ki temu zapisowi w trakcie
 * tworzenia nowego obiektu klasy UpdatePartPage (w wyniku wywo�ania tej podstrony)
 * warto�� kt�ra jest zapisana pod kluczem "partId" zapytania wywo�uj�cego t� podstron�
 * zapisuje si� we w�a�ciwo�ci IdPart - i otrzymujemy id przekazanego elementu.
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
			/*Wywo�anie metody OnPropertyChanged - reakcja za zmian� warto�ci IdPart*/
			Task.Run(OnPropertyChanged);
		}
	}

	/* Metoda OnPropertyChanged wype�nia elementy formularza warto�ciami w�a�ciwosci
	 * obiektu Part klikni�tego na li�cie cz�ci. Otrzymali�my jego id i zapisali�my
	 * w IdPart wi�c pobieramy za pomoc� API ca�y obiekt o tym Id i wype�niamy jego
	 * warto�ciami formularz
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
	 * U�yte zosta�o okno dialogowe wi�cej informacji:
	 * https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pop-ups?view=net-maui-8.0
	 * U�yte zosta� mechanizm rozg�aszania wiadomo�ci, wi�cej informacji
	 * https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/messagingcenter?view=net-maui-8.0
	 */
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert($"Ta operacja jest nie odwracalna", "Czy napewno chcesz zmodyfikowa� ten element?", "Yes", "No");
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
				/*Rozg�oszenie wiadomo�ci przechwytywanej przez subskrybent�w 
				 Wiadomo�� informuj�ca o konieczno�ci prze�adowania listy
				 wy�wietlaj�cej cz�ci, po modyfikacji danych na serwerze
				*/
                MessagingCenter.Send<UpdatePartPage>(this, "UpdateList");
            }
            await DisplayAlert("Alert", "Element zosta� zmieniony", "OK");
        }

		/*Powr�t do strony nadrz�dnej*/
        await Shell.Current.GoToAsync("..");

    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert($"Ta operacja jest nie odwracalna", "Czy napewno chcesz skasowa� ten element?", "Yes", "No");
        if(answer)
		{
			bool response = await PartsManager.Delete(IdPart);
			if(response)
			{
                /*Rozg�oszenie wiadomo�ci przechwytywanej przez subskrybent�w */
                MessagingCenter.Send<UpdatePartPage>(this, "UpdateList");
			}
            await DisplayAlert("Alert", "Element zosta� usuni�ty", "OK");
        }

        /*Powr�t do strony nadrz�dnej*/
        await Shell.Current.GoToAsync("..");
    }

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
        /*Powr�t do strony nadrz�dnej*/
        await Shell.Current.GoToAsync("..");
    }
}