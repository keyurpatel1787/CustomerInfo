using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomerInfo.Models
{
    public class MyDBContext:DbContext
    {
       
        public DbSet<Customer> Customers { get; set; }
       
        public DbSet<MembershipType> MembershipTypes { get; set; }

       
    }
}