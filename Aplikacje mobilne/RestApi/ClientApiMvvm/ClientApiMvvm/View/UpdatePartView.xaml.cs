namespace ClientApiMvvm.View;
using ClientApiMvvm.ViewModel;

public partial class UpdatePartView : ContentPage
{
	public UpdatePartView()
	{
		InitializeComponent();
		BindingContext = new UpdatePartViewModel();
	}
}