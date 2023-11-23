using StudentFirstExample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentFirstExample.ViewModels
{
    internal class StudentViewModel : INotifyPropertyChanged
    {

        public StudentViewModel() 
        {
            ZapiszDaneCommand = new Command(ZapiszDane);
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        string imie = "Noname";
        string nazwisko="Noname";
        string klasa="Noname";
        double srednia=0;

        string outTxt="";

        public string Imie
        {
            get { return imie; }
            set { imie = value; OnPropertyChanged(nameof(Imie)); }
        }
        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; OnPropertyChanged(nameof(Nazwisko)); }
        }
        public string Klasa
        {
            get { return klasa; }
            set { klasa = value; OnPropertyChanged(nameof(Klasa)); }
        }
        public double Srednia
        {
            get { return srednia; }
            set { srednia = value; OnPropertyChanged(nameof(Srednia)); }
        }

        public string OutTxt
        {
            get { return outTxt; }
            set { outTxt = value; OnPropertyChanged(nameof(OutTxt)); }
        }

        
        public Command ZapiszDaneCommand { get; set; }

        private void ZapiszDane(object o)
        {
            string param = (string)o;

            Student student = new Student(Imie, Nazwisko, Klasa, Srednia);

            OutTxt = student.PobierzDane();
            OutTxt += "\n" + param;
        }
    }
}
