using S7PROSIMLib;

namespace IIoTS_Lab2;

public partial class MainPage : ContentPage
{
	S7ProSim sim = new();
	bool[] status = { false, false, false };
	SettingsPage settings = new();

	public MainPage()
	{
		sim.Connect();
		sim.BeginScanNotify();
		sim.SetScanMode(ScanModeConstants.ContinuousScan);

		InitializeComponent();

		_ = RunInBackground(TimeSpan.FromMilliseconds(100), () => StatusChecker());
	}

	private static async Task RunInBackground(TimeSpan timeSpan, Action action)
	{
		var periodicTimer = new PeriodicTimer(timeSpan);
		while (await periodicTimer.WaitForNextTickAsync())
		{
			action();
		}
	}

	private void StatusChecker()
	{
		label_CPUState.Text = sim.GetState();
		object pData = new();
		sim.ReadOutputPoint(settings.AlarmAddress[0], settings.AlarmAddress[1], PointDataTypeConstants.S7_Bit, ref pData);
		bool b = Convert.ToBoolean(pData);
		if (b)
		{
			ResetAlarmButton.BackgroundColor = Colors.Red;
		}
		else
		{
			ResetAlarmButton.BackgroundColor = Color.FromArgb("#512BD4");
		}
	}

	private void ResetAlarmButton_OnClicked(object sender, EventArgs e)
	{
		sim.WriteInputPoint(settings.ResetAddress[0], settings.ResetAddress[1], true);
		Thread.Sleep(1000);
		sim.WriteInputPoint(settings.ResetAddress[0], settings.ResetAddress[1], false);
	}

	private void IconPressureStatus_Clicked(object sender, EventArgs e)
	{
		if (status[0])
		{
			sim.WriteInputPoint(settings.PressureAddress[0], settings.PressureAddress[1], false);
			IconPressureStatus.Source = "green_circle_svgrepo_com.png";
			status[0] = false;
		}
		else
		{
			sim.WriteInputPoint(settings.PressureAddress[0], settings.PressureAddress[1], true);
			IconPressureStatus.Source = "red_circle_svgrepo_com.png";
			status[0] = true;
		}
	}

	private void IconTemperatureStatus_Clicked(object sender, EventArgs e)
	{
		if (status[1])
		{
			sim.WriteInputPoint(settings.TemperatureAddress[0], settings.TemperatureAddress[1], false);
			IconTemperatureStatus.Source = "green_circle_svgrepo_com.png";
			status[1] = false;
		}
		else
		{
			sim.WriteInputPoint(settings.TemperatureAddress[0], settings.TemperatureAddress[1], true);
			IconTemperatureStatus.Source = "red_circle_svgrepo_com.png";
			status[1] = true;
		}
	}

	private void IconFuelStatus_Clicked(object sender, EventArgs e)
	{
		if (status[2])
		{
			sim.WriteInputPoint(settings.FuelAddress[0], settings.FuelAddress[1], false);
			IconFuelStatus.Source = "green_circle_svgrepo_com.png";
			status[2] = false;
		}
		else
		{
			sim.WriteInputPoint(settings.FuelAddress[0], settings.FuelAddress[1], true);
			IconFuelStatus.Source = "red_circle_svgrepo_com.png";
			status[2] = true;
		}
	}

	private async void SettingsPageButton_Clicked(object sender, EventArgs e)
	{
		settings = new();
		await Navigation.PushAsync(settings);
	}
}

