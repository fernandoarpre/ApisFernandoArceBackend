using Common.Requests;
using Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Users
{
    public interface IUsersBusiness
    {
        BaseResponse<List<UsersResponse>> GetUsers();
        Task<BaseResponse<bool>> DeleteUser(int idUser);
        Task<BaseResponse<bool>> SaveUser(UsersRequest user);
    }
}
