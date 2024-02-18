using StudentSecondExample.ViewModels;

namespace StudentSecondExample.Views;

public partial class StudentListView : ContentPage
{
	public StudentListView(StudentListViewModel svm)
	{
		InitializeComponent();
		BindingContext = svm;
	}
}