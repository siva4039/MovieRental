using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignupFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte unknown = 0;
        public static readonly byte PayAsYouGo = 1;
        public static readonly byte Monthly = 1;
        public static readonly byte Quartarly = 1;
        public static readonly byte Yearly = 1;
    }
}