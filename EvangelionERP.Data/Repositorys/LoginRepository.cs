using EvangelionERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvangelionERP.Data.Repositorys
{
    public class LoginRepository : BaseRepository<UserModel>
    {
        private readonly Context Context;
        public LoginRepository([FromServices] Context context) : base(context) => Context = context;

        #region Add
        public UserModel AddUser(UserModel user)
        {
            try
            {
                return Add(user);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Edit
        public UserModel EditUser(UserModel user)
        {
            try
            {
                return Edit(user);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Delete
        public UserModel DeleteUser(int cod)
        {
            try
            {
                return Delete(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Searchs
        public List<UserModel> GetUsers()
        {
            try
            {
                return GetAll();
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public UserModel GetUser(int cod)
        {
            try
            {
                return GetById(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public UserModel GetLogin(string username, string password)
        {
            try
            {
                return Context.UserModel.Where(x => x.UserName == username && x.Password == password).FirstOrDefault(); ;
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion
    }
}
