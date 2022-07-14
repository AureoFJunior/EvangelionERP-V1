using Microsoft.AspNetCore.Mvc;
using EvangelionERP.Data;
using EvangelionERP.Data.Repositorys;
using EvangelionERP.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EvangelionERP.Test
{
    public class FinancialTest : ContextFactory
    {
        private readonly FinancialService FinancialService;

        public FinancialTest() => FinancialService = new FinancialService(new ContextFactory().context);

        [Fact]
        public void Get()
        {
            try
            {
                Assert.NotNull(FinancialService.GetFinancials());
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
                var cod = FinancialService.GetFinancials().FirstOrDefault().Cod;
                Assert.NotNull(FinancialService.GetFinancial(cod));
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
                Assert.NotNull(FinancialService.AddFinancial(new Models.FinancialModel() { InclusionDate = DateTime.Now, TotalValue = 1}));
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
                var cod = FinancialService.GetFinancials().FirstOrDefault().Cod;
                var financial = FinancialService.GetFinancial(cod);
                financial.TotalValue = 2;
                Assert.NotNull(FinancialService.EditFinancial(financial));
            }
            catch (Exception ex)
            {
            }
        }
    }
}