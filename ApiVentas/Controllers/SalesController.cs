using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVentas.Providers;
using Business.Sales;
using Common.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesBusiness _salesBusiness;
        public SalesController(ISalesBusiness salesBusiness)
        {
            _salesBusiness = salesBusiness;
        }
        [Authorize]
        [HttpPut]
        public async Task<JsonResult> SaveSale(SalesRequest sale)
        {
            return new JsonResult(await _salesBusiness.SaveSale(sale));
        }

        [Authorize]
        [HttpDelete("{idSale}")]
        public async Task<JsonResult> DeleteSale(int idSale)
        {
            return new JsonResult(await _salesBusiness.DeleteSale(idSale));
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetSales()
        {
            return new JsonResult(_salesBusiness.GetSales());
        }

    }
}
