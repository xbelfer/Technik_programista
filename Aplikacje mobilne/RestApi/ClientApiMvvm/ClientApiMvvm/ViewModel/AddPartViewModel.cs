using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApiMvvm.Model;

namespace ClientApiMvvm.ViewModel
{
    partial class AddPartViewModel: ObservableObject
    {
        [ObservableProperty]
        private string partName;
        [ObservableProperty]
        private string partSupplier;
        [ObservableProperty]
        private string partType;

        [RelayCommand]
        private async void AddNewPart()
        {
            if (!string.IsNullOrEmpty(PartName)
                    && !string.IsNullOrEmpty(PartSupplier)
                    && !string.IsNullOrEmpty(PartType))
            {
                /*Dodanie na server nowego obiektu za pomocą metody obsługującej API*/
                Part newPart = await PartsManager.Add(PartName, PartSupplier, PartType);

                /*Sprawdzenie czy element został dodany na serwer*/
                if (newPart != null)
                {
                    MessagingCenter.Send<AddPartViewModel>(this, "UpdateList");
                }
            }

            /*Powrót na stronę nadrzędną - stronę która ją wywołała */
            await Shell.Current.GoToAsync("..");
        }
    }
}
