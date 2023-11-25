using System.Collections.ObjectModel;
using ClientApi.Model;
namespace ClientApi.Pages;

public partial class PartsPage : ContentPage
{
	public static ObservableCollection<Part> Parts = new ObservableCollection<Part>();
    private bool isBusy = false;

	public PartsPage()
	{
		InitializeComponent();

        //Po��czenie CollectionView z ObservableCollection
        cvParts.ItemsSource = Parts;

        /* Uruchomienie metody LoadData w odr�bnym Task-u.
         * Poniewa� metoda LoadData jest asynchroniczna wi�c musieliby�my j� oczeka� 
         * (await), a mo�na to zrobi� jedynie w metodzie asynchronicznej (async). 
         * Konstruktora PartsPage() nie mo�emy zdefiniowa� jako metody asynchronicznej, 
         * a wi�c metod� LoadData uruchamiamy w odr�bnym Task-u
         */
		Task.Run(LoadData);

        /* Wymiana wiadomo�ci mi�dzy stronami aplikacji.
         * W klasie UpdatePartPage jest rozg�aszana wiadomo��, kt�ra jest przechwytywana
         * w tym miejscu - rejestracja jako subskrybent tej wiadomo�ci.
         * Jednym z argument�w metody Subscribe jest metoda anonimowa (strza�kowa)
         * kt�ra definiuje co nale�y wykona� gdy wiadomo�� "UpdateList" przyjdzie.
         * W tym przypadku jest wywo�ywana metoda LoadData kt�ra prze�adowywuje
         * list� cz�ci w Parts (ObservableCollection) a tym samym listy widoku.
         */
        MessagingCenter.Subscribe<UpdatePartPage>(this, "UpdateList", (sender) =>
        {
            Task.Run(LoadData);
        });
	}

    /* Metod kt�ra pobiera cz�ci z servera za pomoc� API i wpisuje do listy
     * Parts (ObservableCollection) kt�ra jest powi�zana z widokiem CollectionView
     */
    public async Task LoadData()
    {
        if (isBusy)
            return;
        isBusy = true;
        try
        {
            isBusy = true;

            var partsCollection = await PartsManager.GetAll();

            /* Poniewa� metoda LoadData jest uruchamian w odr�bnym w�tku (Task)
             * to po pobraniu danych z servera za pomoc� API nale�y ju� uaktualni�
             * list� Parts kt�ra jest powi�zana z widokiem listy na g��wnym w�tku.
             * Dlatego operacje na li�cie Parts s� wykonywane na g��wnym w�tku
             * (MainThread)
             */
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
            isBusy = false;
        }
    }

    /* Nadpisanie metody OnAppearing kt�r� dziedziczymy z klasy bazowej ContentPage
     * kt�ra jest wywo�ywana za ka�dym razem gdy strona staje si� widoczna.
     * W tym przypadku chcemy za ka�dym razem deaktywowa� zaznaczenie elementu listy
     * na widoku, poniewa� przy powrocie ze strony podrz�dnej (wywo�ywanej Shell.Current.GoToAsync)
     * zaznaczenie pozostawa�o aktywne.
     */
    protected override void OnAppearing()
    {
        base.OnAppearing();
        cvParts.SelectedItem = null;
    }

    private async void OnClicked_AddPart(object sender, EventArgs e)
    {
        /* W taki spos�b wywo�ujemy stron� podrz�dn� (w tym przypadku dodaj�c� cz��)
         * Z takich podstron wracamy (pozycj� menu - strza�ka wstecz - na stronie podrz�dnej)
         * lub wywo�aniem instrukcji na stronie podrz�dnej:
         * await Shell.Current.GoToAsync("..");
         * Aby wywo�anie strony podrz�dnej dzia�a�o musimy j� zarejestrowa� w pliku
         * AppShell.xaml.cs -> Routing.RegisterRoute("addPart", typeof(AddPartPage));
         * gdzie addPart - to nazwa kt�r� si� pos�ugujemy, a AddPartPage - to nazwa
         * podstrony do kt�rej jeste�my kierowani.
         */
        await Shell.Current.GoToAsync("addPart");
    }

    private async void partSelected_Changed(object sender, SelectionChangedEventArgs e)
    {
        /* Pytamy o warunek (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
         * poniewa� gdy dekatywujemy zaznaczenie instrukcj� cvParts.SelectedItem = null;
         * wywo�ywane jest zda�enie partSelected_Changed z niezaznaczonym elementem!!!
         */
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            /*Wyselekcjonowanie PartID klikni�tego elementu*/
            string partID = (e.CurrentSelection.FirstOrDefault() as Part).PartID;

            /* Wywo�uj�c stron� podrz�dn� mo�emy przekaza� argument do strony podrz�dnej
             * kt�ry przechwytujemy w codeBehinde podstrony za pomoc� atrybutu
             * [QueryProperty] - zobacz w UpdatePartPage.xaml.cs
             * Mamy tu do czynienia z par� klucz- warto�� . Klucz - "partId"
             * Warto�� - partID(warto�� ID klikni�tego elementu)
             */
            await Shell.Current.GoToAsync($"updatePart?partId={partID}");
        }
    }
}