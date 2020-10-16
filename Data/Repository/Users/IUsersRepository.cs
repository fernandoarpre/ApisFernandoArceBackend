using Common.Requests;
using Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Users
{
    public interface IUsersRepository
    {
        BaseResponse<List<UsersResponse>> getUsers();
        Task<bool> DeleteUser(int idUser);
        Task<bool> SaveUser(UsersRequest user);
    }
}
