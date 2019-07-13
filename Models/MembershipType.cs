using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoProject.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }

        public byte DurationInMoths { get; set; }

        public byte DiscountRate { get; set; }

        public string Name { get; set; }

        //These are the value we initalised the Membership table in a migration
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}