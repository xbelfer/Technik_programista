using StudentSecondExample.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSecondExample.ViewModels
{
	public class StudentListViewModel
	{
		public ObservableCollection<Student> StudentList { get; set; }

		public StudentListViewModel()
		{
			StudentList = new ObservableCollection<Student>() {
				new Student("Jan", "Kowalski", "3pre",4.3),
				new Student("Tomasz", "Nowak", "3pre",4.75)
			};
		}
	}
}
