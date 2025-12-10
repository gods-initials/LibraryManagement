using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LibraryManagement.ViewModels;
using LibraryManagement.Models;
using LibraryManagement.Services;

namespace LibraryManagement.Views
{
    /// <summary>
    /// Interaction logic for BooksCardView.xaml
    /// </summary>
    public partial class BooksCardView : Window
    {
        public Book ReturnBook;
        public BooksCardView(Book targetBook, DataService ds)
        {
            InitializeComponent();
            var vm = new BooksCardViewModel(targetBook, ds);
            DataContext = vm;
            vm.RequestClose += () =>
            {
                DialogResult = vm.Success;
                ReturnBook = vm.ReturnBook;
                Close();
            };
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}