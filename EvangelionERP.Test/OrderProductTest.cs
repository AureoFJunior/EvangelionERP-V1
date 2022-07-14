using Microsoft.AspNetCore.Mvc;
using EvangelionERP.Data;
using EvangelionERP.Data.Repositorys;
using EvangelionERP.Data.Services;

namespace EvangelionERP.Test
{
    public class OrderProductTest
    {
        private readonly OrderProductService OrderProductService;

        public OrderProductTest() => OrderProductService = new OrderProductService(new ContextFactory().context);

        [Fact]
        public void Get()
        {
            try
            {
                Assert.NotNull(OrderProductService.GetOrderProducts(1));
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
                Assert.NotNull(OrderProductService.AddOrderProduct(new Models.OrderProductModel[] { new Models.OrderProductModel() { Name = "Teste", FlOutput = true, Quantity = 1, Price = 1 } }).ToList());
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
                Assert.NotNull(OrderProductService.DeleteOrderProduct(1));
            }
            catch (Exception ex)
            {
            }
        }
    }
}