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
			/*Dodanie na server nowego obiektu za pomoc¹ metody obs³uguj¹cej API*/
			Part newPart = await PartsManager.Add(partName.Text, partSupplier.Text, partType.Text);
			
			/*Sprawdzenie czy element zosta³ dodany na serwer*/
			if (newPart != null)
			{
				PartsPage.Parts.Add(newPart);
			}
		}

		/*Powrót na stronê nadrzêdn¹ - stronê która j¹ wywo³a³a */
		await Shell.Current.GoToAsync("..");
    }
}