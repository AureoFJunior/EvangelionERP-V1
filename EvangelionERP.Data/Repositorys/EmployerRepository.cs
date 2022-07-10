using EvangelionERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvangelionERP.Data.Repositorys
{
    public class EmployerRepository : BaseRepository<EmployerModel>
    {
        private readonly Context Context;
        public EmployerRepository([FromServices] Context context) : base(context) => Context = context;

        #region Add
        public EmployerModel AddEmployer(EmployerModel employer)
        {
            try
            {
                return Add(employer);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Edit
        public EmployerModel EditEmployer(EmployerModel employer)
        {
            try
            {
                return Edit(employer);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Delete
        public EmployerModel DeleteEmployer(int cod)
        {
            try
            {
                return Delete(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Searchs
        public List<EmployerModel> GetEmployers()
        {
            try
            {
                return GetAll();
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public EmployerModel GetEmployer(int cod)
        {
            try
            {
                return GetById(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion
    }
}
