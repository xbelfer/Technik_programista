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

            Task.Run(async () => {
				List<Person> people = await repo.GetAllPeople();
				cvPerson.ItemsSource = people;
            });
            
        }

        private async void AddPerson_Clicked(object sender, EventArgs e)
        {
            await repo.AddNewPerson(txtName.Text);
			List<Person> people = await repo.GetAllPeople();
			cvPerson.ItemsSource = people;
		}
    }
}