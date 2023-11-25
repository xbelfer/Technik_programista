namespace ClientApi.Pages;
using ClientApi.Model;

public partial class AddPartPage : ContentPage
{
	public AddPartPage()
	{
		InitializeComponent();
	}

    private async void AddNewPart_Clicked(object sender, EventArgs e)
    {
		if (!string.IsNullOrEmpty(partName.Text)
			&& !string.IsNullOrEmpty(partSupplier.Text)
			&& !string.IsNullOrEmpty(partType.Text))
		{
			/*Dodanie na server nowego obiektu za pomoc� metody obs�uguj�cej API*/
			Part newPart = await PartsManager.Add(partName.Text, partSupplier.Text, partType.Text);
			
			/*Sprawdzenie czy element zosta� dodany na serwer*/
			if (newPart != null)
			{
				PartsPage.Parts.Add(newPart);
			}
		}

		/*Powr�t na stron� nadrz�dn� - stron� kt�ra j� wywo�a�a */
		await Shell.Current.GoToAsync("..");
    }
}