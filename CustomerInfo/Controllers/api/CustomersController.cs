using AutoMapper;
using CustomerInfo.Dtos;
using CustomerInfo.Models;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web.Http;

namespace CustomerInfo.Controllers.api
{
    public class CustomersController : ApiController
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
        //GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customerlist = _context.Customers
                       .Include(c => c.MembershipType);

            if(!string.IsNullOrEmpty(query))
            {
                 customerlist = customerlist.Where(c => c.Name.Contains(query));
            }

            var customerDTOS = customerlist
                        .ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDTOS);

        }
        //GET /api/customers/1
        public CustomerDto GetCustomer(int Id)
        {
            
            var customerlist = _context.Customers.SingleOrDefault(a=>a.Id == Id);
            if (customerlist == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer,CustomerDto>(customerlist);
        }

        //POST /api/customers/
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return customerDto;
        }
        [HttpPut]
        public CustomerDto UpdateCustomer(int Id, CustomerDto customerDto)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var CustomerDb = _context.Customers.SingleOrDefault(a => a.Id == Id);

            if (CustomerDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto, CustomerDb);
            _context.SaveChanges();

            return customerDto;


        }
        
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int Id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(a => a.Id == Id);

            if (customerInDB == null)
                return NotFound();

            _context.Customers.Remove(customerInDB); 
            _context.SaveChanges();

            return Ok();

        }
    }
}
