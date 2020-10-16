using Common.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Responses
{
    public class LoginResponse
    {
        public int? IdUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public LoginResponse (Users user, string token)
        {
            IdUser = user.idUser;
            Email = user.Email;
            Token = token;
        }
    }
}
