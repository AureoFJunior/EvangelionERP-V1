using EvangelionERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvangelionERP.Data.Repositorys
{
    public class CustomerRepository : BaseRepository<CustomerModel>
    {
        private readonly Context Context;
        public CustomerRepository([FromServices] Context context) : base(context) => Context = context;

        #region Add
        public CustomerModel AddCustomer(CustomerModel customer)
        {
            try
            {
                return Add(customer);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Edit
        public CustomerModel EditCustomer(CustomerModel customer)
        {
            try
            {
                return Edit(customer);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Delete
        public CustomerModel DeleteCustomer(int cod)
        {
            try
            {
                return Delete(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Searchs
        public List<CustomerModel> GetCustomers()
        {
            try
            {
                return GetAll();
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public CustomerModel GetCustomer(int cod)
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
