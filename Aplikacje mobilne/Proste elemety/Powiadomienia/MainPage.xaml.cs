using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;
using Plugin.LocalNotification.EventArgs;

namespace Powiadomienia
{
	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();
			LocalNotificationCenter.Current.NotificationActionTapped += Current_NotificationActionTapped;
		}

		private void Current_NotificationActionTapped(NotificationActionEventArgs e)
		{
			if (e.IsDismissed)
			{
				txt.Text="Cancel:"+e.Request.Description;
			}
			else if (e.IsTapped)
			{
				txt.Text = e.Request.Description;
			}
		}

		private void OnCounterClicked(object sender, EventArgs e)
		{
			var request = new NotificationRequest
			{
				NotificationId = 1337,
				Title = "Testowe powiadomienia",
				Subtitle = "Podtytuł powiadomienia",
				Description = "Opis powiadomienia",
				BadgeNumber = 42,
				Schedule = new NotificationRequestSchedule
				{
					NotifyTime = DateTime.Now.AddSeconds(5),
					NotifyRepeatInterval = TimeSpan.FromDays(1),
				},
				Android = new Plugin.LocalNotification.AndroidOption.AndroidOptions
				{
					Color = new AndroidColor(100),
					VibrationPattern = [500,1000],
				}
			};

			LocalNotificationCenter.Current.Show(request);
		}

		private void SecondClicked(object sender, EventArgs e)
		{
			var request = new NotificationRequest
			{
				NotificationId = 1333,
				Title = "Zadanie 1",
				Subtitle = "Podtytuł powiadomienia",
				Description = "Sprzątanie",
				BadgeNumber = 1,
				Schedule = new NotificationRequestSchedule
				{
					NotifyTime = new DateTime(2024,6,2,20,44,0),
					NotifyRepeatInterval = TimeSpan.FromDays(1),
				},
			};

			LocalNotificationCenter.Current.Show(request);
		}
	}

}
