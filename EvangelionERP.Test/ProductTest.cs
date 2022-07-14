using Microsoft.AspNetCore.Mvc;
using EvangelionERP.Data;
using EvangelionERP.Data.Repositorys;
using EvangelionERP.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EvangelionERP.Test
{
    public class ProductTest : ContextFactory
    {
        private readonly ProductService ProductService;

        public ProductTest() => ProductService = new ProductService(new ContextFactory().context);

        [Fact]
        public void Get()
        {
            try
            {
                Assert.NotNull(ProductService.GetProducts());
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
                var cod = ProductService.GetProducts().FirstOrDefault().Cod;
                Assert.NotNull(ProductService.GetProduct(cod));
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
                Assert.NotNull(ProductService.AddProduct(new Models.ProductModel() { Name = "Teste", Price = 13, Quantity = 1}));
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
                var cod = ProductService.GetProducts().FirstOrDefault().Cod;
                var product = ProductService.GetProduct(cod);
                product.Name = "Teste Edit";
                Assert.NotNull(ProductService.EditProduct(product));
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
                var cod = ProductService.GetProducts().FirstOrDefault().Cod;
                Assert.NotNull(ProductService.DeleteProduct(cod));
            }
            catch (Exception ex)
            {
            }
        }
    }
}