using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp4.Models;

namespace WpfApp4.ViewModels
{
    internal class MembersCardViewModel : ObservableObject
    {
        private Member _returnMember;
        public bool Success;
        public RelayCommand OKCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public event Action RequestClose;
        public Member ReturnMember
        {
            get => _returnMember;
            set => SetProperty(ref _returnMember, value);
        }
        public MembersCardViewModel(Member target)
        {
            ReturnMember = new Member() { Id=target.Id, FirstName=target.FirstName, LastName=target.LastName };
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
