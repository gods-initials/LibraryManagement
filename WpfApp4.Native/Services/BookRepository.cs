using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.Models;

namespace WpfApp4.Services
{
    public class BookRepository
    {
        private List<Book> books;
        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book() {Id=0, Author="a", Title="a a", BorrowerId=0},
                new Book() {Id=1, Author="b", Title="b b"},
                new Book() {Id=2, Author="c", Title="c c"},
                new Book() {Id=3, Author="d", Title="d d"},
            };
        }
        public List<Book> GetAll()
        {
            return books;
        }
    }
}
