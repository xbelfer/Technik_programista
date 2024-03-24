namespace NavigationRouting.Pages;


[QueryProperty(nameof(Param),"Parameter")]
public partial class ParameterDetailPage : ContentPage
{
	int param;
	public int Param {  
		get => param;
		set
		{
			param = value;
			OnPropertyChanged(nameof(Param));
		}
	}
	public ParameterDetailPage()
	{
		InitializeComponent();
		BindingContext = this;
	}
}