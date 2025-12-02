using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp4.Models;
using WpfApp4.Services;

namespace WpfApp4.ViewModels
{
    public class BooksCardViewModel : ObservableObject
    {
        private DataService dataService;
        public bool Success;
        private Book _returnBook;
        public Book ReturnBook
        {
            get => _returnBook;
            set => SetProperty(ref _returnBook, value);
        }
        public ObservableCollection<Member> AvailableMembers { get; set; }
        private Member _selectedMember;
        public Member SelectedMember
        {
            get => _selectedMember;
            set
            {
                SetProperty(ref _selectedMember, value);
                ReturnBook.BorrowerId = value.Id;
            }
        }
        public RelayCommand OKCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public event Action RequestClose;
        public BooksCardViewModel(Book target, DataService ds)
        {
            dataService = ds;
            AvailableMembers = new ObservableCollection<Member>(ds.Members);
            ReturnBook = new Book() { Id = target.Id, Author = target.Author, Title = target.Title, BorrowerId=target.BorrowerId};
            if (target.BorrowerId != null)
                SelectedMember = AvailableMembers.Where(x => x.Id == target.BorrowerId).First();
            CancelCommand = new RelayCommand(() =>
            {
                Success = false;
                RequestClose?.Invoke();
            });
            OKCommand = new RelayCommand(() =>
            {
                Success = true;
                RequestClose?.Invoke();
            });
        }
    }
}