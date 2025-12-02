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
using WpfApp4.Models;
using WpfApp4.ViewModels;

namespace WpfApp4.Views
{
    /// <summary>
    /// Interaction logic for MembersCardView.xaml
    /// </summary>
    public partial class MembersCardView : Window
    {
        public Member ReturnMember;
        public MembersCardView(Member target)
        {
            InitializeComponent();
            var vm = new MembersCardViewModel(target);
            DataContext = vm;
            vm.RequestClose += () =>
            {
                DialogResult = vm.Success;
                ReturnMember = vm.ReturnMember;
                Close();
            };
        }
    }
}