using Common.DataObjects;
using Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Customer
{
    public interface ICustomerRepository
    {
        Task<bool> SaveCustomer(Customers customer);
        Task<bool> DeleteCustomer(int idCustomer);
        BaseResponse<List<CustomerResponse>> getCustomers();

        CustomerResponse getCustomerById(int id);
        bool ValidateSaleCustomer(int idCustomer);
    }
}
