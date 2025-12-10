using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LibraryManagement.Models
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
        private DateTime? _dueTo;
        public DateTime? DueTo
        {
            get => _dueTo;
            set => SetProperty(ref _dueTo, value);
        }
        private ObservableCollection<Tag> _tags;
        public ObservableCollection<Tag> Tags
        {
            get => _tags;
            set => SetProperty(ref _tags, value);
        } 
        public Book() 
        {
            Tags = new ObservableCollection<Tag>();
        }
        public Book(Book target)
        {
            this.Id = target.Id;
            this.Title = target.Title;
            this.Author = target.Author;
            this.BorrowerId = target.BorrowerId;
            this.DueTo = target.DueTo;
            this.Tags = target.Tags;
        }
        public override string ToString() => $"Id: {Id}, Title: {Title}, Author: {Author}, Borrowed by: {BorrowerId}";
    }
}