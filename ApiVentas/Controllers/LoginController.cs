using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVentas.Providers;
using Business.Login;
using Common.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginBusiness _login;

        public LoginController(ILoginBusiness login)
        {
            _login = login;
        }
        [HttpPost("Autenticar")]
        public IActionResult Login (LoginRequest  login)
        {
            var res = _login.Autenticar(login);
            if (res == null)
                return BadRequest(new { msg = "Usuario y/o contraseña incorrecta" });

            return Ok(res);
        }

        [Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult("12345");
        }
    }
}
