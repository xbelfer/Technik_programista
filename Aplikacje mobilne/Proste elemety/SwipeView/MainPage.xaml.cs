using System.Collections.ObjectModel;

namespace SwipeView
{
	public partial class MainPage : ContentPage
	{

		public ObservableCollection<string> tasks = new ObservableCollection<string>();
		public MainPage()
		{
			InitializeComponent();
			tasks.Add("Sprzątanie");
			cvTasks.ItemsSource = tasks;
		}


		private void AddTask_ButtonCliked(object sender, EventArgs e)
		{
			if (newTask.Text != "")
			{
				tasks.Add(newTask.Text);
				newTask.Text = string.Empty;
			}
		}

		private void Delete_Invoked(object sender, EventArgs e)
		{
			var x = sender as SwipeItem;

			string delTask = x.BindingContext as string;

			if (delTask != string.Empty)
			{
				tasks.Remove(delTask);
			}

		}
	}

}
