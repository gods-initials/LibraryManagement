using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp4.Models
{
    public class Member : ObservableObject
    {
		private int _id;
		public int Id
		{
			get { return _id; }
			set { SetProperty(ref _id, value); }
        }
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }
        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }
        public override string ToString() => $"{Id} {FirstName} {LastName}";
    }
}
