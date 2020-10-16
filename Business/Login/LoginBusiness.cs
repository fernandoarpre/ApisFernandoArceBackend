using Microsoft.Extensions.Options;
using Common.DataObjects;
using Common.Requests;
using Common.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Common.Util;
using Data.Repository.Login;

namespace Business.Login
{
    public class LoginBusiness : ILoginBusiness
    {
        private readonly AppSettings _appSettings;
        private ILoginRepository _loginRepository; 

        public LoginBusiness(IOptions<AppSettings> settings, ILoginRepository loginRepository)
        {
            _appSettings = settings.Value;
            _loginRepository = loginRepository;
        }
        public LoginResponse Autenticar(LoginRequest login)
        {
            var user = _loginRepository.getUserByEmail(login.Email);
            if (user == null)
                return null;
            
            if (!user.Password.Equals(login.Password))
                return null;
            
            return setResponseValues(user);
        }

        private LoginResponse setResponseValues(Common.DataObjects.Users user)
        {
            return new LoginResponse(user,GenerateToken(user));
        }

        private string GenerateToken(Common.DataObjects.Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("idUser", user.idUser.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
