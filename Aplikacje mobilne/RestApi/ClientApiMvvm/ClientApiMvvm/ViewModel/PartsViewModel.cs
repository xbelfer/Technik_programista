using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ClientApiMvvm.Model;

namespace ClientApiMvvm.ViewModel
{
    public partial class PartsViewModel : ObservableObject
    {
        ObservableCollection<Part> parts;

        private bool isBusy;

        public ObservableCollection<Part> Parts
        {
            get { return parts; }
            set { parts = value; }
        }

        public PartsViewModel()
        {
            parts = new ObservableCollection<Part>();
            Task.Run(LoadData);

            MessagingCenter.Subscribe<UpdatePartViewModel>(this, "UpdateList", (sender) =>
            {
                Task.Run(LoadData);
            });
            MessagingCenter.Subscribe<AddPartViewModel>(this, "UpdateList", (sender) =>
            {
                Task.Run(LoadData);
            });
        }

        private async void LoadData()
        {
            if (isBusy)
                return;
            isBusy = true;
            try
            {
                isBusy = true;

                var partsCollection = await PartsManager.GetAll();

                /* Ponieważ metoda LoadData jest uruchamian w odrębnym wątku (Task)
                 * to po pobraniu danych z servera za pomocą API należy już uaktualnić
                 * listę Parts która jest powiązana z widokiem listy na głównym wątku.
                 * Dlatego operacje na liście Parts są wykonywane na głównym wątku
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

        [ObservableProperty]
        private Part selectedItem;
        [RelayCommand]
        private async Task SelectionChanged()
        {
            if (SelectedItem == null)
                return;
            var param = new Dictionary<string, object>()
            {
                {"selectedPart", SelectedItem}
            };

            await Shell.Current.GoToAsync("updatePart",param);

            MainThread.BeginInvokeOnMainThread(() =>
            {
                SelectedItem = null;
            });
        }
        [RelayCommand]
        private async Task AddNewPart()
        {
            await Shell.Current.GoToAsync("addPart");
        }
    }
}
