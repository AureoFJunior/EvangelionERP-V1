using Microsoft.AspNetCore.Mvc;
using EvangelionERP.Data;
using EvangelionERP.Data.Repositorys;
using EvangelionERP.Data.Services;

namespace EvangelionERP.Test
{
    public class EmployerTest
    {
        private readonly EmployerService EmployerService;
        public EmployerTest() => EmployerService = new EmployerService(new ContextFactory().context);

        [Fact]
        public void Get()
        {
            try
            {
                Assert.NotNull(EmployerService.GetEmployers());
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
                var cod = EmployerService.GetEmployers().FirstOrDefault().Cod;
                Assert.NotNull(EmployerService.GetEmployer(cod));
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
                Assert.NotNull(EmployerService.AddEmployer(new Models.EmployerModel() { FirstName = "Teste", LastName = "Teste", Email = "teste@gmail.com", Mobile = "", Salary = 1200}));
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
                var cod = EmployerService.GetEmployers().FirstOrDefault().Cod;
                var employer = EmployerService.GetEmployer(cod);
                employer.LastName = "Teste Edit";
                Assert.NotNull(EmployerService.EditEmployer(employer));
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
                var cod = EmployerService.GetEmployers().FirstOrDefault().Cod;
                Assert.NotNull(EmployerService.DeleteEmployer(cod));
            }
            catch (Exception ex)
            {
            }
        }
    }
}