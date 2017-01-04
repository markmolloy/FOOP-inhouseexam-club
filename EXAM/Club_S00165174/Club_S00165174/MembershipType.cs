using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club_S00165174
{
    class MembershipType
    {
        public string Type { get; set; }

        public override string ToString()
        {
            return this.Type;
        }

        public MembershipType(string type)
        {
            this.Type = type;
        }
    }
}
