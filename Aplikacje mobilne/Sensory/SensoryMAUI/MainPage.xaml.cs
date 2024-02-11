using System.Data;

namespace SensoryMAUI
{
	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();
			DeviceDisplay.Current.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;
			showInfoAboutDevice();
			actualizateInfoAboutStateOfBattery(null,
				new BatteryInfoChangedEventArgs(
					Battery.Default.ChargeLevel,
					Battery.Default.State,
					Battery.Default.PowerSource));
		}
		private void showInfoAboutDevice()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			sb.AppendLine("Informacje o urządzeniu:");
			sb.AppendLine($"Model: {DeviceInfo.Current.Model}");
			sb.AppendLine($"Producent: {DeviceInfo.Current.Manufacturer}");
			sb.AppendLine($"Nazwa: {DeviceInfo.Name}");
			sb.AppendLine($"Wersja systemu: {DeviceInfo.VersionString}");
			sb.AppendLine($"Idiom: {DeviceInfo.Current.Idiom}");
			sb.AppendLine($"Platforma: {DeviceInfo.Current.Platform}");
			sb.AppendLine($"Typ urządzenia: {((DeviceInfo.Current.DeviceType == DeviceType.Virtual) ?
							"wirtualne" : "rzeczywiste")}");

			lbDevice.Text = sb.ToString();
		}

		private void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
		{
			showInfoAboutDisplay();
		}
		private void ContentPage_Loaded(object sender, EventArgs e)
		{
			showInfoAboutDisplay();
		}

		private void showInfoAboutDisplay()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			sb.AppendLine("Informacje o wyświetlaczu:");
			sb.AppendLine($"Rozdzielczość: {DeviceDisplay.Current.MainDisplayInfo.Width} " +
				$"* {DeviceDisplay.Current.MainDisplayInfo.Height} px");
			sb.AppendLine($"Gęstość: {DeviceDisplay.Current.MainDisplayInfo.Density}");
			sb.AppendLine($"Orientacja: {DeviceDisplay.Current.MainDisplayInfo.Orientation}");
			sb.AppendLine($"Obrót: {DeviceDisplay.Current.MainDisplayInfo.Rotation}");
			sb.AppendLine($"Częstość odświeżania: {DeviceDisplay.Current.MainDisplayInfo.RefreshRate} Hz");

			lbScreen.Text = sb.ToString();
		}
#region Bateria
		private bool isObservedChangingStateOfBattery;

		private void batterySwitch_Toggled(object sender, ToggledEventArgs e)
		{
			if (!isObservedChangingStateOfBattery)
			{
				Battery.Default.BatteryInfoChanged += actualizateInfoAboutStateOfBattery;
			}
			else
			{
				Battery.Default.BatteryInfoChanged -= actualizateInfoAboutStateOfBattery;
			}
			isObservedChangingStateOfBattery = !isObservedChangingStateOfBattery;
		}

		private void actualizateInfoAboutStateOfBattery(object sender, BatteryInfoChangedEventArgs e)
		{
			lbStateOfBattery.Text = e.State switch
			{
				BatteryState.Charging => "Ładowanie",
				BatteryState.Discharging => "Rozładowywanie (ładowarka nie jest podłączona)",
				BatteryState.Full => "Pełna",
				BatteryState.NotCharging => "Brak ładowania(ładowarka może być podłączona",
				BatteryState.NotPresent => "Bateria nie jest obecna",
				BatteryState.Unknown => "Stan baterii nie jest znany",
				_ => "Nierozpoznany stan"
			};

			lbLevelOfBattery.Text = $"Bateria jest naładowana w {e.ChargeLevel * 100} %";
			pbBaterryLevel.Progress = e.ChargeLevel;
		}

		#endregion
		#region Akcelerometr
		private void accelerometrSwitch_Toggled(object sender, ToggledEventArgs e)
		{
			if (Accelerometer.Default.IsSupported)
			{
				if (!Accelerometer.Default.IsMonitoring)
				{
					Accelerometer.Default.ReadingChanged += showReadingAcceleration;
					Accelerometer.Default.ShakeDetected += detectShake;
					Accelerometer.Default.Start(SensorSpeed.UI);
				}
				else
				{
					Accelerometer.Stop();
					Accelerometer.Default.ReadingChanged -= showReadingAcceleration;
					Accelerometer.Default.ShakeDetected -= detectShake;
				}
			}
		}
		private DateTime czasOstatniegoPotrzasniecia; 
		private void detectShake(object? sender, EventArgs e)
		{
			lbPotrzasanie.Text = $"Wykryto potrząsanie urządzeniem";
			czasOstatniegoPotrzasniecia = DateTime.Now;
			switchStateFlashlight();
			signalVibration();
		}

		private void showReadingAcceleration(object? sender, AccelerometerChangedEventArgs e)
		{
			lbAkcelerometr.Text = $"Wektor przyśpieszenia:\n\tX = {e.Reading.Acceleration.X}" +
				$"\n\tY = {e.Reading.Acceleration.Y}\n\tZ = {e.Reading.Acceleration.Z}" +
				$"\nDługość wektora: {9.81 * e.Reading.Acceleration.Length()}";
			pbPrzyspieszenie.Progress = e.Reading.Acceleration.Length() / 10;
			if (DateTime.Now > czasOstatniegoPotrzasniecia.AddSeconds(3))
				lbPotrzasanie.Text = "---";
		}

		#endregion
		#region Latarka_i_wibracje
		private bool flashlightOn = false;
		private async void switchStateFlashlight()
		{
			try
			{
				flashlightOn = !flashlightOn;
				if (flashlightOn)
					await Flashlight.Default.TurnOnAsync();
				else
					await Flashlight.Default.TurnOffAsync();
			}
			catch(FeatureNotSupportedException)
			{
				await DisplayAlert(Title, "Urządzenie nie ma latarki", "OK");
			}
			catch(PermissionException)
			{
				await DisplayAlert(Title, "Aplikacja nie ma uprawnień do latarki", "OK");
			}
			catch(Exception)
			{
				await DisplayAlert(Title, "Wł/Wył latarki nie możliwe", "OK");
			}
		}
		private void flashLightButton_Clicked(object sender, EventArgs e)
		{
			switchStateFlashlight();
		}
		private void signalVibration()
		{
			Vibration.Default.Vibrate(TimeSpan.FromSeconds(0.3));
		}
		#endregion
		#region Barometr
		private void barometrSwitch_Toggled(object sender, ToggledEventArgs e)
		{
			if (Barometer.Default.IsSupported)
			{
				if (!Barometer.Default.IsMonitoring)
				{
					Barometer.Default.ReadingChanged += Barometer_ReadingChanged;
					Barometer.Default.Start(SensorSpeed.UI);
				}
				else
				{
					Barometer.Stop();
					Barometer.Default.ReadingChanged -= Barometer_ReadingChanged;
				}
			}
			else
				lbBarometr.Text = "Urządzenie nie posiada barometru";
		}

		private void Barometer_ReadingChanged(object? sender, BarometerChangedEventArgs e)
		{
			lbBarometr.Text = $"Barometr: {e.Reading}";
			pbCisnienie.Progress = e.Reading.PressureInHectopascals / 2000;
		}
		#endregion
		#region Kompas
		private void compasSwitch_Toggled(object sender, ToggledEventArgs e)
		{
			if(Compass.Default.IsSupported)
			{
				if(!Compass.Default.IsMonitoring)
				{
					Compass.Default.ReadingChanged += Compass_ReadingChanged;
					Compass.Default.Start(SensorSpeed.UI);
				}
				else
				{
					Compass.Stop();
					Compass.Default.ReadingChanged -= Compass_ReadingChanged;
				}
			}
			else
			{
				lbKompas.Text = "Urządzenie nie posiada kompasu";
			}
		}

		private void Compass_ReadingChanged(object? sender, CompassChangedEventArgs e)
		{
			lbKompas.Text = $"Compass: {e.Reading.HeadingMagneticNorth}";
		}
		#endregion
		#region Orientacja
		private void orientacjaSwitch_Toggled(object sender, ToggledEventArgs e)
		{
			if (OrientationSensor.Default.IsSupported)
			{
				if (!OrientationSensor.Default.IsMonitoring)
				{
					OrientationSensor.Default.ReadingChanged += Orientation_ReadingChanged;
					OrientationSensor.Default.Start(SensorSpeed.UI);
				}
				else
				{
					OrientationSensor.Default.Stop();
					OrientationSensor.Default.ReadingChanged -= Orientation_ReadingChanged;
				}
			}
			else
				lbOrientacja.Text = "Urządzenie nie posiada czujnika magnetycznego";
		}

		private void Orientation_ReadingChanged(object? sender, OrientationSensorChangedEventArgs e)
		{
			lbOrientacja.Text = $"Oreintacja:\n\tX = {e.Reading.Orientation.X}\n\t" +
				$"Y = {e.Reading.Orientation.Y}\n\tZ = {e.Reading.Orientation.Z}\n\t" +
				$"W = {e.Reading.Orientation.W}";
		}
		#endregion
	}
}
