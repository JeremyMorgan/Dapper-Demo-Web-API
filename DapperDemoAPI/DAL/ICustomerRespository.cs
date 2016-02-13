using System.Collections.Generic;
using DapperDemoAPI.Models;

namespace DapperDemoAPI.DAL
{
	internal interface ICustomerRespository
	{
		List<Customer> GetCustomers(int amount, string sort);

		Customer GetSingleCustomer(int customerId);

		bool InsertCustomer(Customer ourCustomer);

		bool DeleteCustomer(int customerId);

		bool UpdateCustomer(Customer ourCustomer);
	}
}
