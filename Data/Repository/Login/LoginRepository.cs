using Common.DataObjects;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository.Login
{
    public class LoginRepository: ILoginRepository
    {
        private ApiVentasContext _context;
        public LoginRepository(ApiVentasContext context)
        {
            _context = context;
        }

        public Common.DataObjects.Users getUserByEmail(string email)
        {
           return _context.Users.Where(r => r.Email.Equals(email)).FirstOrDefault();   
        }

        public Common.DataObjects.Users getUserById(int id)
        {
           return _context.Users.Where(r => r.idUser == id).FirstOrDefault();   
        }
    }
}
