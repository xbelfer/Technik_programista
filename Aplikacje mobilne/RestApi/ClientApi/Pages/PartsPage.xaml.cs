using System.Collections.ObjectModel;
using ClientApi.Model;
namespace ClientApi.Pages;

public partial class PartsPage : ContentPage
{
	public static ObservableCollection<Part> Parts = new ObservableCollection<Part>();
    private bool IsBusy = false;

	public PartsPage()
	{
		InitializeComponent();
        cvParts.ItemsSource = Parts;
		Task.Run(LoadData);
	}

    public async Task LoadData()
    {
        if (IsBusy)
            return;
        IsBusy = true;
        try
        {
            IsBusy = true;

            var partsCollection = await PartsManager.GetAll();

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Parts.Clear();

                foreach (Part part in partsCollection)
                {
                    Parts.Add(part);
                }
            });
        }
        finally
        {
            IsBusy = false;
        }
    }

    private async void OnClicked_AddPart(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("addPart");
    }
}