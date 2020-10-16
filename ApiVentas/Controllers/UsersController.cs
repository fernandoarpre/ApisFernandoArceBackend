using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVentas.Providers;
using Business.Users;
using Common.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersBusiness _usersBusiness;
        public UsersController(IUsersBusiness usersBusiness)
        {
            _usersBusiness = usersBusiness;
        }
        [Authorize]
        [HttpPut]
        public async Task<JsonResult> SaveSale(UsersRequest user)
        {
            return new JsonResult(await _usersBusiness.SaveUser(user));
        }

        [Authorize]
        [HttpDelete("{idUser}")]
        public async Task<JsonResult> DeleteUser(int idUser)
        {
            return new JsonResult(await _usersBusiness.DeleteUser(idUser));
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetUsers()
        {
            return new JsonResult(_usersBusiness.GetUsers());
        }
    }
}
