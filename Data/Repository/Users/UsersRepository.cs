using Common.Requests;
using Common.Responses;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApiVentasContext _context;

        public UsersRepository(ApiVentasContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteUser(int idUser)
        {
            try
            {
                var user = _context.Users.Where(a => a.idUser == idUser).FirstOrDefault();
                _context.Entry(user).State = EntityState.Deleted;
                if (await _context.SaveChangesAsync() != 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public BaseResponse<List<UsersResponse>> getUsers()
        {
            BaseResponse<List<UsersResponse>> response = new BaseResponse<List<UsersResponse>>();
            response.response = _context.Users.Select(r => new UsersResponse
            {
                idUser = r.idUser,
                Email = r.Email,
                Password = r.Password
            }).ToList();
            return response;
        }

        public async Task<bool> SaveUser(UsersRequest user)
        {
            try
            {
                if (!String.IsNullOrEmpty(user.idUser.ToString()))
                    _context.Users.Update(user);
                else
                    await _context.Users.AddAsync(user);


                if (await _context.SaveChangesAsync() != 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
