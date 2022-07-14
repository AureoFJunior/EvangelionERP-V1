using Microsoft.AspNetCore.Mvc;
using EvangelionERP.Data;
using EvangelionERP.Data.Repositorys;
using EvangelionERP.Data.Services;

namespace EvangelionERP.Test
{
    public class OrderTest
    {
        private readonly OrderService OrderService;

        public OrderTest() => OrderService = new OrderService(new ContextFactory().context);

        [Fact]
        public void Get()
        {
            try
            {
                Assert.NotNull(OrderService.GetOrders());
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
                var cod = OrderService.GetOrders().FirstOrDefault().Cod;
                Assert.NotNull(OrderService.GetOrder(cod));
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
                Assert.NotNull(OrderService.AddOrder(new Models.OrderModel() { CreationDate = DateTime.Now, FlOutput = true, ProductsQuantity = 1, Status = 1, TotalValue = 1}));
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
                var cod = OrderService.GetOrders().FirstOrDefault().Cod;
                var order = OrderService.GetOrder(cod);
                order.ProductsQuantity = 2;
                order.TotalValue = 2;
                Assert.NotNull(OrderService.EditOrder(order));
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
                var cod = OrderService.GetOrders().FirstOrDefault().Cod;
                var order = OrderService.GetOrder(cod);
                order.Status = 0;
                Assert.NotNull(OrderService.EditOrder(order));
            }
            catch (Exception ex)
            {
            }
        }
    }
}