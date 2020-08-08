namespace CustomerInfo.Migrations
{
    using CustomerInfo.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomerInfo.Models.MyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CustomerInfo.Models.MyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.MembershipTypes.AddOrUpdate(x => x.Id,
                new MembershipType() { Id = 1, Name = "Pay as you Go", SignUpFee = 100, Duration = 6, DiscountRate = 10 },
                new MembershipType() { Id = 2, Name = "Premium", SignUpFee = 500, Duration = 12, DiscountRate = 50 }
                );
        }
    }
}
