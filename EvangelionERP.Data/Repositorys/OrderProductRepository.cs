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
    public class OrderProductRepository : BaseRepository<OrderProductModel>
    {
        private readonly Context Context;
        public OrderProductRepository([FromServices] Context context) : base(context) => Context = context;

        #region Add
        public OrderProductModel[] AddOrderProducts(OrderProductModel[] orderProducts)
        {
            try
            {
                foreach (var orderProduct in orderProducts)
                {
                    //Se o produto possuir quantidade ou preço zerado ele não será incluso no pedido.
                    if (orderProduct.Price <= 0 || orderProduct.Quantity <= 0)
                        orderProducts = orderProducts.Where(x => x.ProductCod != orderProduct.ProductCod).ToArray();
                    else
                    {
                        //Atribui o número do pedido aos itens.
                        var orderCod = Context.OrderProductModel.OrderByDescending(o => o.Cod).Select(o => o.Cod == 0 ? 1 : o.Cod).FirstOrDefault() + 1;
                        for (int i = 0; i < orderProducts.Length; i++)
                        {
                            orderProducts[i].OrderCod = orderProducts[i].OrderCod == 0 ? orderCod : orderProducts[i].OrderCod;
                        }
                    }
                }

                Context.OrderProductModel.AddRange(orderProducts);
                Context.SaveChanges();

                return orderProducts;
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Edit
        public OrderProductModel EditOrderProduct(OrderProductModel order)
        {
            try
            {
                return Edit(order);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Delete
        public OrderProductModel DeleteOrderProduct(int cod)
        {
            try
            {
                var products = Context.OrderProductModel.Where(x => x.OrderCod == cod).AsNoTracking().ToList();

                //Remove do banco esse produto e salva as alterações.
                Context.OrderProductModel.FromSqlRaw("SET foreign_key_checks = 0;");

                foreach (OrderProductModel product in products)
                {
                    Context.Remove(product);
                }

                Context.OrderProductModel.FromSqlRaw("SET foreign_key_checks = 1;");
                Context.SaveChanges();

                return Delete(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Searchs
        public List<OrderProductModel> GetOrderProducts()
        {
            try
            {
                return GetAll();
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public OrderProductModel GetOrderProduct(int cod)
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
