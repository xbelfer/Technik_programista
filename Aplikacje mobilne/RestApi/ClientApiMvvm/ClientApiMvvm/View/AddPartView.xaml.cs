namespace ClientApiMvvm.View;
using ClientApiMvvm.ViewModel;

public partial class AddPartView : ContentPage
{
	public AddPartView()
	{
		InitializeComponent();
		BindingContext = new AddPartViewModel();
	}
}