using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public class BookRepository
    {
        private List<Book> books;
        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book() {Id=0, Author="a", Title="a a", BorrowerId=0, DueTo= new DateTime(2025, 12, 3)},
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
