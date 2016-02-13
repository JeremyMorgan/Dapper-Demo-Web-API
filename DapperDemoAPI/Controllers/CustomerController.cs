using System.Collections.Generic;
using System.Web.Http;
using DapperDemoAPI.DAL;
using DapperDemoAPI.Models;

namespace DapperDemoAPI.Controllers
{
    public class CustomerController : ApiController
    {
	    private CustomerRespository _ourCustomerRespository;

	    public CustomerController()
	    {
			_ourCustomerRespository = new CustomerRespository();
		}

		// GET: /Customer
		[Route("Customers")]
		[HttpGet]
		public List<Customer> Get()
		{
			return _ourCustomerRespository.GetCustomers(10, "ASC");
		}

		// GET: /Customer/10/ASC
		[Route("Customers/{amount}/{sort}")]
		[HttpGet]
		public List<Customer> Get(int amount, string sort)
		{
			return _ourCustomerRespository.GetCustomers(amount, sort);
		}

		// GET: /Customer/5
		[Route("Customers/{id}")]
		[HttpGet]
		public Customer Get(int id)
		{
			return _ourCustomerRespository.GetSingleCustomer(id);
		}

		// POST: /Customer
		[Route("Customers")]
		[HttpPost]
		public bool Post([FromBody]Customer ourCustomer)
		{
			//return true;
			return _ourCustomerRespository.InsertCustomer(ourCustomer);
		}

		// PUT: api/Customer/5
		[Route("Customers")]
		[HttpPut]
		public bool Put([FromBody]Customer ourCustomer)
		{
			return _ourCustomerRespository.UpdateCustomer(ourCustomer);
		}

		// DELETE: api/Customer/5
		[Route("Customers/{id}")]
		[HttpDelete]
		public bool Delete(int id)
		{
			return _ourCustomerRespository.DeleteCustomer(id);
		}
    }
}
