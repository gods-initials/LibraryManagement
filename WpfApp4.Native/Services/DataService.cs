using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagement.Services
{
    public class DataService
    {
        private BookRepository bookRepository;
        private MemberRepository memberRepository;
        private TagRepository tagRepository;
        private Dictionary<int, List<Tag>> booksTags;
        public ObservableCollection<Member> Members;
        public ObservableCollection<Book> Books;
        public ObservableCollection<Tag> Tags;
        public DataService()
        {
            bookRepository = new BookRepository();
            memberRepository = new MemberRepository();
            tagRepository = new TagRepository();
            Books = new ObservableCollection<Book>(bookRepository.GetAll());
            Tags = new ObservableCollection<Tag>(tagRepository.GetAll());
            booksTags = tagRepository.GetAllTagsBooks();
            JoinBooksTags();
            Members = new ObservableCollection<Member>(memberRepository.GetAll());
        }
        public ObservableCollection<Book> GetBorrowedBooks(int memberId)
        {
            return new ObservableCollection<Book>(Books.Where(x => x.BorrowerId == memberId));
        }
        private void JoinBooksTags()
        {
            foreach (var book in Books)
            {
                if (booksTags.ContainsKey(book.Id))
                {
                    foreach (var tag in booksTags[book.Id])
                    {
                        book.Tags.Add(tag);
                    }
                }
            }
        }
    }
}
