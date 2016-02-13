using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DapperDemoAPI.Models;

namespace DapperDemoAPI.DAL
{
	public class CustomerRespository : ICustomerRespository
	{
		private readonly IDbConnection _db;

		public CustomerRespository()
		{
			_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
		}

		public List<Customer> GetCustomers(int amount, string sort)
		{
			return this._db.Query<Customer>("SELECT TOP " + amount + " [CustomerID],[CustomerFirstName],[CustomerLastName],[IsActive] FROM [Customer] ORDER BY CustomerID " + sort).ToList();
		}

		public Customer GetSingleCustomer(int customerId)
		{
			return _db.Query<Customer>("SELECT[CustomerID],[CustomerFirstName],[CustomerLastName],[IsActive] FROM [Customer] WHERE CustomerID =@CustomerID", new { CustomerID = customerId }).SingleOrDefault();
		}

		public bool InsertCustomer(Customer ourCustomer)
		{
			int rowsAffected = this._db.Execute(@"INSERT Customer([CustomerFirstName],[CustomerLastName],[IsActive]) values (@CustomerFirstName, @CustomerLastName, @IsActive)",
				new { CustomerFirstName = ourCustomer.CustomerFirstName, CustomerLastName = ourCustomer.CustomerLastName, IsActive = true });

			if (rowsAffected > 0)
			{
				return true;
			}

			return false;
		}

		public bool DeleteCustomer(int customerId)
		{
			int rowsAffected = this._db.Execute(@"DELETE FROM [Customer] WHERE CustomerID = @CustomerID",
				new { CustomerID = customerId });

			if (rowsAffected > 0)
			{
				return true;
			}

			return false;
		}

		public bool UpdateCustomer(Customer ourCustomer)
		{
			int rowsAffected = this._db.Execute(
						"UPDATE [Customer] SET [CustomerFirstName] = @CustomerFirstName ,[CustomerLastName] = @CustomerLastName, [IsActive] = @IsActive WHERE CustomerID = " +
						ourCustomer.CustomerID, ourCustomer);

			if (rowsAffected > 0)
			{
				return true;
			}

			return false;
		}
	}
}