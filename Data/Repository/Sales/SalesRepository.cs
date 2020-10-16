using Common.Requests;
using Common.Responses;
using Data.Context;
using Data.Repository.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Sales
{
    public class SalesRepository : ISalesRepository
    {
        private readonly ApiVentasContext _context;
        private readonly ICustomerRepository _customerRepository;

        public SalesRepository(ApiVentasContext context, ICustomerRepository customerRepository)
        {
            _context = context;
            _customerRepository = customerRepository;
        }
        public async Task<bool> DeleteSale(int idSale)
        {
            try
            {
                var saleDelete = _context.Sales.Where(a => a.idSale == idSale).FirstOrDefault();

                _context.Entry(saleDelete).State = EntityState.Deleted;
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

        public BaseResponse<List<SalesResponse>> getSales()
        {
            BaseResponse<List<SalesResponse>> response = new BaseResponse<List<SalesResponse>>();
            response.response = _context.Sales.Select(r => new SalesResponse
            {
                idCustomer = r.idCustomer,
                Customer = _customerRepository.getCustomerById(r.idCustomer),
                idSale = r.idSale,
                Period = r.Period,
                Quantity = r.Quantity,
                Value = r.Value
            }).ToList();
            return response;
        }

        public async Task<bool> SaveSale(SalesRequest sale)
        {
            try
            {
                if (!String.IsNullOrEmpty(sale.idSale.ToString()))
                    _context.Sales.Update(sale);
                else
                    await _context.Sales.AddAsync(sale);


                if (await _context.SaveChangesAsync() != 0)
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}
