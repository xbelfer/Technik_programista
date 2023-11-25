using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApiMvvm.Model;
using CommunityToolkit.Mvvm.Input;


namespace ClientApiMvvm.ViewModel
{
    [QueryProperty(nameof(SelectedItem), "selectedPart")]
    partial class UpdatePartViewModel: ObservableObject
    {
        Part selectedItem;
        public Part SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        void OnPropertyChanged()
        {
            PartId = SelectedItem.PartID;
            PartName = SelectedItem.PartName;
            PartType = SelectedItem.PartType;
            PartSupplier = SelectedItem.SupplierString;
        }

        [ObservableProperty]
        private string partId;
        [ObservableProperty]
        private string partName;
        [ObservableProperty]
        private string partSupplier;
        [ObservableProperty]
        private string partType;

        [RelayCommand]
        private async void Save()
        {
            bool answer = await Application.Current.MainPage.DisplayAlert($"Ta operacja jest nie odwracalna", "Czy napewno chcesz zmodyfikować ten element?", "Yes", "No");
            if (answer)
            {
                Part updatePart = new Part
                {
                    PartID = PartId,
                    PartName = PartName,
                    PartType = PartType,
                    Suppliers = PartSupplier.Split(',').ToList()
                };
                bool response = await PartsManager.Update(updatePart);
                if (response)
                {
                    MessagingCenter.Send<UpdatePartViewModel>(this, "UpdateList");
                }
                await Application.Current.MainPage.DisplayAlert("Alert", "Element został zmieniony", "OK");
            }

            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async void Delete()
        {
            bool answer = await Application.Current.MainPage.DisplayAlert($"Ta operacja jest nie odwracalna", "Czy napewno chcesz skasować ten element?", "Yes", "No");
            if (answer)
            { 
                bool response = await PartsManager.Delete(PartId);
                if (response)
                {
                    MessagingCenter.Send<UpdatePartViewModel>(this, "UpdateList");
                }
                await Application.Current.MainPage.DisplayAlert("Alert", "Element został usunięty", "OK");
            }

            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
