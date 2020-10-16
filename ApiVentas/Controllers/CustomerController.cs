using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVentas.Providers;
using Business.Customer;
using Common.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBusiness _customerBusiness;
        public CustomerController(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }
        [Authorize]
        [HttpPut]
        public async Task<JsonResult> SaveCustomer([FromBody]CustomerRequest customer)
        {
            return new JsonResult(await _customerBusiness.SaveCustomer(customer));
        }
        [Authorize]
        [HttpDelete("{idCustomer}")]
        public async Task<JsonResult> DeleteCustomer(int idCustomer)
        {
            return new JsonResult(await _customerBusiness.DeleteCustomer(idCustomer));
        }
        [Authorize]
        [HttpGet("getById")]
        public JsonResult GetCustomerById(CustomerRequest customer)
        {
            return new JsonResult("");
        }
        [Authorize]
        [HttpGet]
        public JsonResult GetCustomers()
        {
            return new JsonResult(_customerBusiness.GetCustomers());
        }

        
    }
}
