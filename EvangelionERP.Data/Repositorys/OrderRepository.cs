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
    public class OrderRepository : BaseRepository<OrderModel>
    {
        private readonly Context Context;
        public OrderRepository([FromServices] Context context) : base(context) => Context = context;

        #region Add
        public OrderModel AddOrder(OrderModel order)
        {
            try
            {
                return Add(order);
            }   
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Edit
        public OrderModel EditOrder(OrderModel order)
        {
            try
            {
                var orderCod = Context.OrderModel.OrderByDescending(o => o.Cod).Select(o => o.Cod == 0 ? 1 : o.Cod).FirstOrDefault();

                if (order.Cod == 0)
                {
                    order.Cod = orderCod;
                }

                var ord = Context.OrderModel.AsNoTracking().FirstOrDefault(x => x.Cod == orderCod);

                //Se não achar o pedido.
                if (ord == null)
                    return null;

                return Edit(order);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Searchs
        public List<OrderModel> GetOrders()
        {
            try
            {
                return GetAll().OrderByDescending(x => x.Cod).ToList();
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public OrderModel GetOrder(int cod)
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
