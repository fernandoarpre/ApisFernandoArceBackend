using Common.DataObjects;
using Common.Responses;
using Common.Util;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApiVentasContext _context;

        public CustomerRepository(ApiVentasContext context)
        {
            _context = context;
        }

		public async Task<bool> SaveCustomer(Customers customer)
		{
            try { 
				if (!String.IsNullOrEmpty(customer.idCustomer.ToString()))
					_context.Customers.Update(customer);
				else 
					await _context.Customers.AddAsync(customer);
			

				if (await _context.SaveChangesAsync() != 0)
					return true;
				else
					return false;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public async Task<bool> DeleteCustomer(int idCustomer)
		{
            try { 
				var custo =  _context.Customers.Where(a => a.idCustomer == idCustomer).FirstOrDefault();
				_context.Entry(custo).State = EntityState.Deleted;
				if (await _context.SaveChangesAsync() != 0)
					return true;
				else
					return false;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

        public bool ValidateSaleCustomer(int idCustomer)
        {
            try{
                var sales = _context.Sales.Where(a => a.idCustomer == idCustomer).FirstOrDefault();
                if (sales != null)
                    return true;
                else
                    return false;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public BaseResponse<List<CustomerResponse>> getCustomers()
        {
			BaseResponse<List<CustomerResponse>> response = new BaseResponse<List<CustomerResponse>>();
			response.response = _context.Customers.Select(r => new CustomerResponse {
					 idCustomer = r.idCustomer,
					 DocumentId = r.DocumentId,
					 FirstName = r.FirstName,
					 LastName = r.LastName,
					 Address = r.Address,
					 City = r.City,
					 Cellphone = r.Cellphone
			}).ToList();
			return response;
			
        }

		public CustomerResponse getCustomerById(int id)
		{
			return _context.Customers.Where(r => r.idCustomer == id).Select(r => new CustomerResponse {
				idCustomer = r.idCustomer,
				DocumentId = r.DocumentId,
				FirstName = r.FirstName,
				LastName = r.LastName,
				Address = r.Address,
				City = r.City,
				Cellphone = r.Cellphone
			}).FirstOrDefault();
		}

	}
}
