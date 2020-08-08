using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInfo.Models
{
    public class MembershipType
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal SignUpFee { get; set; }

        public int Duration { get; set; }
        public decimal DiscountRate { get; set; }

        public static readonly int Unknown = 0;
        public static readonly int PayAsYouGo = 1;
    }
}