using Business.Email;
using Common.Requests;
using Common.Responses;
using Common.Util;
using Data.Repository.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Users
{
    public class UsersBusiness : IUsersBusiness
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IEmailService _emailService;
        public UsersBusiness(IUsersRepository usersRepository, IEmailService emailService)
        {
            _usersRepository = usersRepository;
            _emailService = emailService;
        }

        public BaseResponse<List<UsersResponse>> GetUsers()
        {
            return _usersRepository.getUsers();
        }
        public async Task<BaseResponse<bool>> DeleteUser(int idUser)
        {
            BaseResponse<bool> res = new BaseResponse<bool>();
            
            if (idUser == UserSession.getUserId())
            {
                res.msg = "No se puede elimnar, es el usuario actual";
                res.response = false;
                return res;
            }

            res.response = await _usersRepository.DeleteUser(idUser);
            res.msg = "Se eliminó el usuario con exito!";
           
            return res;
        }

        public async Task<BaseResponse<bool>> SaveUser(UsersRequest user)
        {
            var idUser = user.idUser;
            BaseResponse<bool> res = new BaseResponse<bool>();
            res.response = await _usersRepository.SaveUser(user);
            res.msg = "Se guardó el usuario con exito!";
            if (!res.response)
                res.msg = "Error al intentar guardar el usuario";
            else{
                if (!String.IsNullOrEmpty(idUser.ToString()))
                    _emailService.Send(user.Email, "Actualizacion en su cuenta", "Se realizó un cambio en su cuenta de la aplicacion PruebaApis");
                else
                    _emailService.Send(user.Email, "Creacion de  cuenta", "Se ha creado una cuenta para la aplicacion PruebaApis");
            }
               
            
            
            return res;
        }

      
    }
}
