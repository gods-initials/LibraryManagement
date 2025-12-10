using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibraryManagement.Models;
using LibraryManagement.Services;

namespace LibraryManagement.ViewModels
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
                if (SetProperty(ref _selectedMember, value))
                {
                    if (value==null)
                        ReturnBook.BorrowerId = null;
                    else
                        ReturnBook.BorrowerId = value.Id;
                }
                ReturnCommand?.NotifyCanExecuteChanged();
            }
        }
        public string TagsString { get; set; }
        public RelayCommand OKCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ReturnCommand { get; set; }
        public event Action RequestClose;
        public void Return()
        {
            SelectedMember = null;
            ReturnBook.DueTo = null;
        }
        public bool CanReturn()
        {
            return SelectedMember != null;
        }
        private string GetTagsString()
        {
            var sb = new StringBuilder();
            foreach (Tag tag in ReturnBook.Tags)
            {
                sb.Append(tag.TagName);
                sb.Append("; ");
            }
            return sb.ToString();

        }
        public BooksCardViewModel(Book target, DataService ds)
        {
            dataService = ds;
            AvailableMembers = new ObservableCollection<Member>(ds.Members);
            ReturnBook = new Book(target);
            TagsString = GetTagsString();
            if (target.BorrowerId != null)
                SelectedMember = AvailableMembers.Where(x => x.Id == target.BorrowerId).First();
            CancelCommand = new RelayCommand(() =>
            {
                Success = false;
                RequestClose?.Invoke();
            });
            OKCommand = new RelayCommand(() =>
            {
                if (ReturnBook.BorrowerId != null && ReturnBook.DueTo==null)
                {
                    MessageBox.Show("return when?");
                }
                else
                {
                    Success = true;
                    RequestClose?.Invoke();
                }
            });
            ReturnCommand = new RelayCommand(Return, CanReturn);
        }
    }
}