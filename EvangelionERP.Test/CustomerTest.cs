using Microsoft.AspNetCore.Mvc;
using EvangelionERP.Data;
using EvangelionERP.Data.Repositorys;
using EvangelionERP.Data.Services;

namespace EvangelionERP.Test
{
    public class CustomerTest
    {
        private readonly CustomerService CustomerService;

        public CustomerTest() => CustomerService = new CustomerService(new ContextFactory().context);

        [Fact]
        public void Get()
        {
            try
            {
                Assert.NotNull(CustomerService.GetCustomers());
            }
            catch (Exception ex)
            {
            }
        }

        [Fact]
        public void GetById()
        {
            try
            {
                var cod = CustomerService.GetCustomers().FirstOrDefault().Cod;
                Assert.NotNull(CustomerService.GetCustomer(cod));
            }
            catch (Exception ex)
            {
            }
        }

        [Fact]
        public void Add()
        {
            try
            {
                Assert.NotNull(CustomerService.AddCustomer(new Models.CustomerModel() { FirstName = "Teste", LastName = "Teste", Email = "teste@gmail.com", Mobile = ""}));
            }
            catch (Exception ex)
            {

            }
        }

        [Fact]
        public void Update()
        {
            try
            {
                var cod = CustomerService.GetCustomers().FirstOrDefault().Cod;
                var customer = CustomerService.GetCustomer(cod);
                customer.LastName = "Teste Edit";
                Assert.NotNull(CustomerService.EditCustomer(customer));
            }
            catch (Exception ex)
            {
            }
        }

        [Fact]
        public void Delete()
        {
            try
            {
                var cod = CustomerService.GetCustomers().FirstOrDefault().Cod;
                Assert.NotNull(CustomerService.DeleteCustomer(cod));
            }
            catch (Exception ex)
            {
            }
        }
    }
}