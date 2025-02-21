using System.Text.RegularExpressions;

namespace MauiMaskedEntryDemo;

/// <summary>
/// Main page of the MauiMaskedEntryDemo.
/// </summary>
public partial class MainPage : ContentPage
{
	[GeneratedRegex(@"^[\d]{0,10}$")]
	private partial Regex NumberRegex();

	[GeneratedRegex(@"^([a-zA-Z]{0,2}|[a-zA-Z]{3}[\d]{0,3})$")]
	private partial Regex LicensePlateRegex();

	string myNumber = string.Empty;

	/// <summary>
	/// Property to demonstrate masked number input.
	/// </summary>
	public string MyNumber
	{
		get => myNumber;
		set
		{
			if (myNumber != value)
			{
				var oldValue = myNumber;
				myNumber = value;
				OnPropertyChanged(nameof(MyNumber));
				if (!string.IsNullOrEmpty(MyNumber) && !NumberRegex().IsMatch(MyNumber))
				{
					this.Dispatcher.Dispatch(() =>
					{
						MyNumber = oldValue;
					});
				}
			}
		}
	}

	string myLicensePlate = string.Empty;

	/// <summary>
	/// Property to demonstrate masked license plate input.
	/// </summary>
	public string MyLicensePlate
	{
		get => myLicensePlate;
		set
		{
			if (myLicensePlate != value)
			{
				var oldValue = myLicensePlate;
				myLicensePlate = value;
				OnPropertyChanged(nameof(MyLicensePlate));
				if (!string.IsNullOrEmpty(MyLicensePlate) && !LicensePlateRegex().IsMatch(MyLicensePlate))
				{
					this.Dispatcher.Dispatch(() =>
					{
						MyLicensePlate = oldValue;
					});
				}
			}
		}
	}

	/// <summary>
	/// Initialize the main page.
	/// </summary>
	public MainPage()
	{
		InitializeComponent();
	}

	/// <summary>
	/// React to changing Day/Night mode.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	void OnDayNight(object sender, EventArgs e)
	{
		if (Application.Current is Application app)
		{
			app.UserAppTheme = app.RequestedTheme != AppTheme.Dark ? AppTheme.Dark : AppTheme.Light;
		}

	}
}
