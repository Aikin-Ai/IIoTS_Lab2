namespace IIoTS_Lab2;

public partial class SettingsPage : ContentPage
{
	public int[] PressureAddress
	{
		get
		{
			string str = PressureAddressEditor.Text;
			int[] arr = {0, 0};
			arr[0] = Int32.Parse(str[0].ToString());
			arr[1] = Int32.Parse(str[2].ToString());
			return arr;
		}
	}
	public int[] TemperatureAddress
	{
		get
		{
			string str = TemperatureAddressEditor.Text;
			int[] arr = {0, 0};
			arr[0] = Int32.Parse(str[0].ToString());
			arr[1] = Int32.Parse(str[2].ToString());
			return arr;
		}
	}
	public int[] FuelAddress
	{
		get
		{
			string str = FuelAddressEditor.Text;
			int[] arr = {0, 0};
			arr[0] = Int32.Parse(str[0].ToString());
			arr[1] = Int32.Parse(str[2].ToString());
			return arr;
		}
	}
	public int[] ResetAddress
	{
		get
		{
			string str = ResetAddressEditor.Text;
			int[] arr = {0, 0};
			arr[0] = Int32.Parse(str[0].ToString());
			arr[1] = Int32.Parse(str[2].ToString());
			return arr;
		}
	}
	public int[] AlarmAddress
	{
		get
		{
			string str = AlarmAddressEditor.Text;
			int[] arr = {0, 0};
			arr[0] = Int32.Parse(str[0].ToString());
			arr[1] = Int32.Parse(str[2].ToString());
			return arr;
		}
	}
	public SettingsPage()
	{
		InitializeComponent();
	}
}