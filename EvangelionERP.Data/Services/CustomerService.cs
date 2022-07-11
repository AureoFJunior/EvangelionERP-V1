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
    public class CustomerService
    {
        private readonly Context Context;
        private readonly CustomerRepository CustomerRepository;

        public CustomerService([FromServices] Context context)
        {
            Context = context;
            CustomerRepository = new CustomerRepository(context);
        }

        #region Add
        public CustomerModel AddCustomer(CustomerModel ecustomer)
        {
            try
            {
                return CustomerRepository.AddCustomer(ecustomer);
            }   
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Edit
        public CustomerModel EditCustomer(CustomerModel ecustomer)
        {
            try
            {
                return CustomerRepository.EditCustomer(ecustomer); ;
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Delete
        public CustomerModel DeleteCustomer(int cod)
        {
            try
            {
                return CustomerRepository.DeleteCustomer(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Searchs
        public List<CustomerModel> GetCustomers()
        {
            try
            {
                return CustomerRepository.GetCustomers();
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public CustomerModel GetCustomer(int cod)
        {
            try
            {
                return CustomerRepository.GetCustomer(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion
    }
}
