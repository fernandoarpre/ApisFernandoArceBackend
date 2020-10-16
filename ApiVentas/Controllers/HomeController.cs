using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVentas.Providers;
using Business.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeBusiness _homeBusiness;

        public HomeController(IHomeBusiness homeBusiness) {
            _homeBusiness = homeBusiness;
        }


        [Authorize]
        [HttpGet("GetDashboard")]
        public JsonResult GetDashboard(){
            return new JsonResult(_homeBusiness.GetDashboard());
        }

        [Authorize]
        [HttpGet("GetCharts/{idCustomer}")]
        public JsonResult GetCharts(int idCustomer)
        {
            return new JsonResult(_homeBusiness.GetChart(idCustomer));
        }
    }
}
