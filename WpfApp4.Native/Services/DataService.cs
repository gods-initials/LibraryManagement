using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.Models;

namespace WpfApp4.Services
{
    public class DataService
    {
        private BookRepository bookRepository;
        private MemberRepository memberRepository;
        public ObservableCollection<Member> Members;
        public ObservableCollection<Book> Books;
        public DataService()
        {
            bookRepository = new BookRepository();
            memberRepository = new MemberRepository();
            Books = new ObservableCollection<Book>(bookRepository.GetAll());
            Members = new ObservableCollection<Member>(memberRepository.GetAll());
        }
    }
}
