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

        //Po³¹czenie CollectionView z ObservableCollection
        cvParts.ItemsSource = Parts;

        /* Uruchomienie metody LoadData w odrêbnym Task-u.
         * Poniewa¿ metoda LoadData jest asynchroniczna wiêc musielibyœmy j¹ oczekaæ 
         * (await), a mo¿na to zrobiæ jedynie w metodzie asynchronicznej (async). 
         * Konstruktora PartsPage() nie mo¿emy zdefiniowaæ jako metody asynchronicznej, 
         * a wiêc metodê LoadData uruchamiamy w odrêbnym Task-u
         */
		Task.Run(LoadData);

        /* Wymiana wiadomoœci miêdzy stronami aplikacji.
         * W klasie UpdatePartPage jest rozg³aszana wiadomoœæ, która jest przechwytywana
         * w tym miejscu - rejestracja jako subskrybent tej wiadomoœci.
         * Jednym z argumentów metody Subscribe jest metoda anonimowa (strza³kowa)
         * która definiuje co nale¿y wykonaæ gdy wiadomoœæ "UpdateList" przyjdzie.
         * W tym przypadku jest wywo³ywana metoda LoadData która prze³adowywuje
         * listê czêœci w Parts (ObservableCollection) a tym samym listy widoku.
         */
        MessagingCenter.Subscribe<UpdatePartPage>(this, "UpdateList", (sender) =>
        {
            Task.Run(LoadData);
        });
	}

    /* Metod która pobiera czêœci z servera za pomoc¹ API i wpisuje do listy
     * Parts (ObservableCollection) która jest powi¹zana z widokiem CollectionView
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

            /* Poniewa¿ metoda LoadData jest uruchamian w odrêbnym w¹tku (Task)
             * to po pobraniu danych z servera za pomoc¹ API nale¿y ju¿ uaktualniæ
             * listê Parts która jest powi¹zana z widokiem listy na g³ównym w¹tku.
             * Dlatego operacje na liœcie Parts s¹ wykonywane na g³ównym w¹tku
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

    /* Nadpisanie metody OnAppearing któr¹ dziedziczymy z klasy bazowej ContentPage
     * która jest wywo³ywana za ka¿dym razem gdy strona staje siê widoczna.
     * W tym przypadku chcemy za ka¿dym razem deaktywowaæ zaznaczenie elementu listy
     * na widoku, poniewa¿ przy powrocie ze strony podrzêdnej (wywo³ywanej Shell.Current.GoToAsync)
     * zaznaczenie pozostawa³o aktywne.
     */
    protected override void OnAppearing()
    {
        base.OnAppearing();
        cvParts.SelectedItem = null;
    }

    private async void OnClicked_AddPart(object sender, EventArgs e)
    {
        /* W taki sposób wywo³ujemy stronê podrzêdn¹ (w tym przypadku dodaj¹c¹ czêœæ)
         * Z takich podstron wracamy (pozycj¹ menu - strza³ka wstecz - na stronie podrzêdnej)
         * lub wywo³aniem instrukcji na stronie podrzêdnej:
         * await Shell.Current.GoToAsync("..");
         * Aby wywo³anie strony podrzêdnej dzia³a³o musimy j¹ zarejestrowaæ w pliku
         * AppShell.xaml.cs -> Routing.RegisterRoute("addPart", typeof(AddPartPage));
         * gdzie addPart - to nazwa któr¹ siê pos³ugujemy, a AddPartPage - to nazwa
         * podstrony do której jesteœmy kierowani.
         */
        await Shell.Current.GoToAsync("addPart");
    }

    private async void partSelected_Changed(object sender, SelectionChangedEventArgs e)
    {
        /* Pytamy o warunek (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
         * poniewa¿ gdy dekatywujemy zaznaczenie instrukcj¹ cvParts.SelectedItem = null;
         * wywo³ywane jest zda¿enie partSelected_Changed z niezaznaczonym elementem!!!
         */
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            /*Wyselekcjonowanie PartID klikniêtego elementu*/
            string partID = (e.CurrentSelection.FirstOrDefault() as Part).PartID;

            /* Wywo³uj¹c stronê podrzêdn¹ mo¿emy przekazaæ argument do strony podrzêdnej
             * który przechwytujemy w codeBehinde podstrony za pomoc¹ atrybutu
             * [QueryProperty] - zobacz w UpdatePartPage.xaml.cs
             * Mamy tu do czynienia z par¹ klucz- wartoœæ . Klucz - "partId"
             * Wartoœæ - partID(wartoœæ ID klikniêtego elementu)
             */
            await Shell.Current.GoToAsync($"updatePart?partId={partID}");
        }
    }
}