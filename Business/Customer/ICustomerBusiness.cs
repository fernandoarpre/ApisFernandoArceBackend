using Common.Requests;
using Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Customer
{
    public interface ICustomerBusiness
    {
        Task<BaseResponse<bool>> SaveCustomer(CustomerRequest customer);
        Task<BaseResponse<bool>> DeleteCustomer(int idCustomer);
        BaseResponse<List<CustomerResponse>> GetCustomers();
    }
}
