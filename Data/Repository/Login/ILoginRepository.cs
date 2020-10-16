using Common.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Login
{
    public interface ILoginRepository
    {
        Common.DataObjects.Users getUserByEmail(string email);
        Common.DataObjects.Users getUserById(int id);
    }
}
