using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp4.Models;

namespace WpfApp4.Services
{
    internal class MemberRepository
    {
        private List<Member> members;
        public MemberRepository()
        {
            members = new List<Member>()
            {
                new Member() {Id=1, FirstName="negr", LastName="boba"},
                new Member() {Id=2, FirstName="lexa", LastName="boba"},
                new Member() {Id=0, FirstName="biba", LastName="boba"},
            };
        }
        public List<Member> GetAll()
        {
            return members;
        }
    }
}
