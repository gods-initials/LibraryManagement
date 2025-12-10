using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public class TagRepository
    {
        private List<Tag> tags;
        private Dictionary<int, List<Tag>> booksTags;
        public TagRepository()
        {
            tags = new List<Tag>()
            {
                new Tag() {Id=0, TagName="fiction"},
                new Tag() {Id=1, TagName="r-18"},
                new Tag() {Id=2, TagName="magic"},
            };
            booksTags = new Dictionary<int, List<Tag>>()
            {
                [0] = new List<Tag>() { tags[0], tags[1] },
                [1] = new List<Tag>() { tags[1], tags[2], tags[0] },
                [3] = new List<Tag>() { tags[0], },
            };
        }
        public List<Tag> GetAll()
        {
            return tags;
        }
        public Dictionary<int, List<Tag>> GetAllTagsBooks()
        {
            return booksTags;
        }
    }
}
