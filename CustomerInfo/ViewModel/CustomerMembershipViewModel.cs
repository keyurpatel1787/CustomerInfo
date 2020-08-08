using CustomerInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInfo.ViewModel
{
    public class CustomerMembershipViewModel
    {

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}