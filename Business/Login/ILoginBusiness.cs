using Common.Requests;
using Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Login
{
    public interface ILoginBusiness
    {
        LoginResponse Autenticar(LoginRequest login);
    }
}
