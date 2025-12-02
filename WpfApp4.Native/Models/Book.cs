using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp4.Models
{
    public class Book : ObservableObject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        private string _author;
        public string Author
        {
            get => _author;
            set => SetProperty(ref _author, value);
        }
        private int? _borrowerId = null;
        public int? BorrowerId
        {
            get => _borrowerId;
            set => SetProperty(ref _borrowerId, value);
        }
        public override string ToString() => $"Id: {Id}, Title: {Title}, Author: {Author}, Borrowed by: {BorrowerId}";
    }
}