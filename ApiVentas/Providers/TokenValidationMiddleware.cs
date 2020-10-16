using Common.Util;
using Data.Repository.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVentas.Providers
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        public TokenValidationMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }
        public async Task Invoke(HttpContext context, ILoginRepository loginRepository)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
                ValidateToken(context,token, loginRepository);

            await _next(context);
        }

        private void ValidateToken(HttpContext context, string token, ILoginRepository loginRepository)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var SecrectKey = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(SecrectKey),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwt = (JwtSecurityToken)validatedToken;
                AddClaimsToContext(context, loginRepository, jwt);
            }
            catch { }
            
        }
        private void AddClaimsToContext(HttpContext context, ILoginRepository loginRepository, JwtSecurityToken jwt)
        {
            var userId = int.Parse(jwt.Claims.First(x => x.Type == "idUser").Value);
            context.Items["User"] = loginRepository.getUserById(userId);
            UserSession.setUserId(userId);
        }
    }
}
