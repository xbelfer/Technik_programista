using System.Collections.ObjectModel;
using _12_SQLite_App.Models;

namespace _12_SQLite_App
{
    public partial class MainPage : ContentPage
    {
        Repository repo;

        public MainPage()
        {
            InitializeComponent();
            repo = new Repository();
            List<Person> persons = repo.GetAllPeople();
            cvPerson.ItemsSource = persons;
        }

        private void AddPerson_Clicked(object sender, EventArgs e)
        {
            repo.AddNewPerson(txtName.Text);
			List<Person> persons = repo.GetAllPeople();
			cvPerson.ItemsSource = persons;
		}
    }
}