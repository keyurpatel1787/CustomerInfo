using CustomerInfo.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using CustomerInfo.ViewModel;

namespace CustomerInfo.Controllers
{
    public class CustomersController : Controller
    {

        private MyDBContext _context;

        public CustomersController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(r => r.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Detail(int Id)
        {
            var cust = _context.Customers.Include(r => r.MembershipType).SingleOrDefault(r => r.Id == Id);

            if (cust == null)
                return HttpNotFound();

            return View(cust);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var newviewmodel = new CustomerMembershipViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View(newviewmodel);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var newcustomermodel = new CustomerMembershipViewModel
                    {
                        Customer = customer,
                        MembershipTypes = _context.MembershipTypes.ToList()
                    };
                    return View("New", newcustomermodel);
                }
                else
                {

                    if (customer.Id > 0)
                    {
                        var cust = _context.Customers.SingleOrDefault(r => r.Id == customer.Id);

                        cust.Name = customer.Name;
                        cust.Address = customer.Address;
                        cust.City = customer.City;
                        cust.Birthdate = customer.Birthdate;
                        cust.MembershipTypeId = customer.MembershipTypeId;

                    }
                    else
                    {
                        _context.Customers.Add(customer);

                    }
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Edit(int Id)
        {
            var cust = _context.Customers.SingleOrDefault(r => r.Id == Id);

            if (cust == null)
                return HttpNotFound();

            var newcustmodel = new CustomerMembershipViewModel
            {
                Customer = cust,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("New", newcustmodel);

        }

    }
}