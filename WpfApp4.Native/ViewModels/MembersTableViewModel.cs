using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp4.Models;
using WpfApp4.Services;
using WpfApp4.Views;

namespace WpfApp4.ViewModels
{
    internal class MembersTableViewModel : ObservableObject
    {
        private DataService _dataService;
        public string OnDisplay => "Members";
        private Member _selectedMember;
        public Member SelectedMember
        {
            get => _selectedMember;
            set
            {
                if (SetProperty(ref _selectedMember, value))
                {
                    EditCommand.NotifyCanExecuteChanged();
                    RemoveCommand.NotifyCanExecuteChanged();
                }
            }
        }
        private ObservableCollection<Member> _memberList;
        public ObservableCollection<Member> MemberList
        {
            get => _memberList;
            set => SetProperty(ref _memberList, value);
        }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        private void Add()
        {
            Member newMember = new Member();
            var a = new MembersCardView(newMember);
            var success = a.ShowDialog();
            if (success == true)
            {
                MemberList.Add(a.ReturnMember);
            }
        }
        private bool CanEdit()
        {
            return (SelectedMember != null);
        }
        private void Edit()
        {
            var a = new MembersCardView(SelectedMember);
            var success = a.ShowDialog();
            if (success == true)
            {
                SelectedMember.Id = a.ReturnMember.Id;
                SelectedMember.FirstName = a.ReturnMember.FirstName;
                SelectedMember.LastName = a.ReturnMember.LastName;
            }
        }
        private void Remove()
        {
            MessageBoxResult result = MessageBox.Show($"Delete {SelectedMember}?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                MemberList.Remove(SelectedMember);
            }
        }
        public MembersTableViewModel(DataService ds)
        {
            this._dataService = ds;
            MemberList = _dataService.Members;
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit, CanEdit);
            RemoveCommand = new RelayCommand(Remove, CanEdit);
        }
    }
}