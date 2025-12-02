using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp4.Services;

namespace WpfApp4.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly BooksTableViewModel _booksTableViewModel;
        private readonly MembersTableViewModel _membersTableViewModel;
        private ObservableObject _selectedViewModel;
        private DataService _dataService;
        public ObservableObject SelectedViewModel
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
        }
        public ObservableCollection<ObservableObject> AvailableViewModels { get; set; } = new();
        public MainWindowViewModel()
        {
            _dataService = new DataService();
            _booksTableViewModel = new BooksTableViewModel(_dataService);
            _membersTableViewModel = new MembersTableViewModel(_dataService);
            AvailableViewModels.Add(_booksTableViewModel);
            AvailableViewModels.Add(_membersTableViewModel);
            SelectedViewModel = AvailableViewModels.First();
        }
    }
}