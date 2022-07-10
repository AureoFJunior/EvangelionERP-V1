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
    public class OrderProductService
    {
        private readonly Context Context;
        private readonly OrderProductRepository OrderProductRepository;
        private readonly OrderRepository OrderRepository;
        private readonly ProductRepository ProductRepository;

        public OrderProductService([FromServices] Context context)
        {
            Context = context;
            OrderProductRepository = new OrderProductRepository(context);
            OrderRepository = new OrderRepository(context);
            ProductRepository = new ProductRepository(context);
        }

        #region Add
        public OrderProductModel[] AddOrderProduct(OrderProductModel[] orders)
        {
            try
            {
                return OrderProductRepository.AddOrderProducts(orders);
            }   
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Edit
        public OrderProductModel EditOrderProduct(OrderProductModel order)
        {
            try
            {
                return OrderProductRepository.EditOrderProduct(order);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Delete
        public OrderProductModel DeleteOrderProduct(int cod)
        {
            try
            {
                return OrderProductRepository.DeleteOrderProduct(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Searchs
        public List<OrderProductModel> GetOrdersProducts()
        {
            try
            {
                return OrderProductRepository.GetOrderProducts();
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public List<OrderProductViewModel> GetOrderProducts(int cod)
        {
            try
            {
                var order = OrderProductRepository.GetOrderProducts().Where(x => x.Cod == cod).ToList();
                var products = ProductRepository.GetProducts();
                int orderCod = 0;
                int productCod = 0;

                List<OrderProductViewModel> orderProducts = new List<OrderProductViewModel>();
                ProductModel produto = new ProductModel();


                foreach (OrderProductModel product in order)
                {
                    OrderProductViewModel orderProduct = new OrderProductViewModel()
                    {
                        Cod = product.Cod,
                        Name = product.Name,
                        OrderCod = product.OrderCod,
                        Price = product.Price,
                        ProductCod = product.ProductCod,
                        Quantity = product.Quantity
                    };
                    orderProducts.Add(orderProduct);
                    produto = products.Where(x => x.Cod == product.Cod || x.Name == product.Name).FirstOrDefault();
                    products.Remove(produto);
                    orderCod = product.OrderCod;
                }

                foreach (ProductModel product in products)
                {
                    OrderProductViewModel orderProduct = new OrderProductViewModel()
                    {
                        Cod = product.Cod,
                        Name = product.Name,
                        OrderCod = orderCod,
                        Price = product.Price,
                        ProductCod = productCod,
                        Quantity = 0
                    };
                    orderProducts.Add(orderProduct);
                }

                return orderProducts;
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion
    }
}
