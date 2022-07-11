using EvangelionERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvangelionERP.Data.Repositorys
{
    public class LoginService
    {
        private readonly Context Context;
        private readonly LoginRepository LoginRepository;

        public LoginService([FromServices] Context context)
        {
            Context = context;
            LoginRepository = new LoginRepository(context);
        }

        #region Add
        public UserModel AddLogin(UserModel user)
        {
            try
            {
                return LoginRepository.AddUser(user);
            }   
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Edit
        public UserModel EditLogin(UserModel user)
        {
            try
            {
                return LoginRepository.EditUser(user); ;
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Delete
        public UserModel DeleteLogin(int cod)
        {
            try
            {
                return LoginRepository.DeleteUser(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Searchs
        public List<UserModel> GetLogins()
        {
            try
            {
                return LoginRepository.GetUsers();
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public UserModel GetLogin(int cod)
        {
            try
            {
                return LoginRepository.GetUser(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion
    }
}
