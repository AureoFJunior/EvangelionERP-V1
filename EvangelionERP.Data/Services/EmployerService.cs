using EvangelionERP.Data.Repositorys;
using EvangelionERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvangelionERP.Data.Services
{
    public class EmployerService
    {
        private readonly Context Context;
        private readonly EmployerRepository EmployerRepository;

        public EmployerService([FromServices] Context context)
        {
            Context = context;
            EmployerRepository = new EmployerRepository(context);
        }

        #region Add
        public EmployerModel AddEmployer(EmployerModel employer)
        {
            try
            {
                return EmployerRepository.AddEmployer(employer);
            }   
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Edit
        public EmployerModel EditEmployer(EmployerModel employer)
        {
            try
            {
                return EmployerRepository.EditEmployer(employer); ;
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Delete
        public EmployerModel DeleteEmployer(int cod)
        {
            try
            {
                return EmployerRepository.DeleteEmployer(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Searchs
        public List<EmployerModel> GetEmployers()
        {
            try
            {
                return EmployerRepository.GetEmployers();
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public EmployerModel GetEmployer(int cod)
        {
            try
            {
                return EmployerRepository.GetEmployer(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion
    }
}
