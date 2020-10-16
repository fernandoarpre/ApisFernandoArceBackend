using Common.Requests;
using Common.Responses;
using Data.Repository.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Customer
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerBusiness(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public BaseResponse<List<CustomerResponse>> GetCustomers()
        {
            return _customerRepository.getCustomers();
        }
        public async Task<BaseResponse<bool>> SaveCustomer(CustomerRequest customer)
        {
            BaseResponse<bool> res = new BaseResponse<bool>();
            res.response = await _customerRepository.SaveCustomer(customer);
            res.msg = "Se guardó el cliente con exito!";
            if (!res.response)
                res.msg = "Error al intentar guardar el cliente";

            return res;
        }

        public async Task<BaseResponse<bool>> DeleteCustomer(int idCustomer)
        {
            BaseResponse<bool> res = new BaseResponse<bool>();
            bool validate = _customerRepository.ValidateSaleCustomer(idCustomer);
            if (validate){
                res.msg = "No se puede elimnar el cliente, tiene ventas asociadas";
                res.response = false;
                return res;
            }
            
            res.response = await _customerRepository.DeleteCustomer(idCustomer);
            res.msg = "Se eliminó el cliente con exito!";
            return res;
        }
    }
}
