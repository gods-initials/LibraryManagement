using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp4.Views;
using WpfApp4.Models;
using WpfApp4.Services;

namespace WpfApp4.ViewModels
{
    internal class BooksTableViewModel : ObservableObject
    {
        private DataService _dataService;
        public string OnDisplay => "Books";
        private Book _selectedBook;
        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                if (SetProperty(ref _selectedBook, value))
                {
                    EditCommand.NotifyCanExecuteChanged();
                    RemoveCommand.NotifyCanExecuteChanged();
                } 
            }
        }
        private ObservableCollection<Book> _bookList;
        public ObservableCollection<Book> BookList
        {
            get => _bookList;
            set => SetProperty(ref _bookList, value);
        }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        private void Add()
        {
            Book newBook = new Book();
            var a = new BooksCardView(newBook, _dataService);
            var success = a.ShowDialog();
            if (success == true)
            {
                BookList.Add(a.ReturnBook);
            }
        }
        private bool CanEdit()
        {
            return (SelectedBook!=null);
        }
        private void Edit()
        {
            var a = new BooksCardView(SelectedBook, _dataService);
            var success = a.ShowDialog();
            if (success == true)
            {
                SelectedBook.Id = a.ReturnBook.Id;
                SelectedBook.Author = a.ReturnBook.Author;
                SelectedBook.Title = a.ReturnBook.Title;
                SelectedBook.BorrowerId = a.ReturnBook.BorrowerId;
            }
        }
        private void Remove()
        {
            MessageBoxResult result = MessageBox.Show($"Delete {SelectedBook}?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if ( result == MessageBoxResult.Yes)
            {
                BookList.Remove(SelectedBook);
            }
        }
        public BooksTableViewModel(DataService ds)
        {
            _dataService = ds;
            BookList = _dataService.Books;
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit, CanEdit);
            RemoveCommand = new RelayCommand(Remove, CanEdit);
        }
    }
}