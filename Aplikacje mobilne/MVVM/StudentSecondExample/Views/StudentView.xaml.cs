using StudentSecondExample.ViewModels;

namespace StudentSecondExample.Views;

public partial class StudentView : ContentPage
{
	public StudentView(StudentViewModel svm)
	{
		InitializeComponent();
		BindingContext = svm;
	}
}