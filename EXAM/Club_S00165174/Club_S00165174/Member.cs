using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club_S00165174
{
    class Member
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int YearJoined { get; set; }
        public MembershipType MemberType { get; set; }
        public override string ToString()
        {
            return this.Name;
        }

        public Member(string name, string phone, string address, int year, MembershipType mtype)
        {
            this.Name = name;
            this.Phone = phone;
            this.Address = address;
            this.YearJoined = year;
            this.MemberType = mtype;
        }

    }
}
