using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibraryManagement.Models;
using LibraryManagement.Services;

namespace LibraryManagement.ViewModels
{
    internal class MembersCardViewModel : ObservableObject
    {
        private DataService dataService;
        private Member _returnMember;
        public bool Success;
        public RelayCommand OKCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public event Action RequestClose;
        //private ObservableCollection<Book> _borrowedBooks;
        public ObservableCollection<Book> BorrowedBooks { get; set; }
            /*
        {
            get => _borrowedBooks;
            set => SetProperty(ref _borrowedBooks, value);
        }
            */
        public Member ReturnMember
        {
            get => _returnMember;
            set => SetProperty(ref _returnMember, value);
        }
        public MembersCardViewModel(Member target, DataService ds)
        {
            dataService = ds;
            ReturnMember = new Member() { Id=target.Id, FirstName=target.FirstName, LastName=target.LastName };
            BorrowedBooks = ds.GetBorrowedBooks(ReturnMember.Id);
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
