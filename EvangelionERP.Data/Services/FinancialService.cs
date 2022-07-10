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
    public class FinancialService
    {
        private readonly Context Context;
        private readonly FinancialRepository FinancialRepository;
        public FinancialService([FromServices] Context context)
        {
            Context = context;
            FinancialRepository = new FinancialRepository(context);
        }

        #region Add
        public FinancialModel AddFinancial(OrderModel order)
        {
            try
            {
                return FinancialRepository.AddFinancial(order);
            }   
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Edit
        public FinancialModel EditFinancial(FinancialModel order)
        {
            try
            {
                var orderCod = Context.FinancialModel.OrderByDescending(o => o.Cod).Select(o => o.Cod == 0 ? 1 : o.Cod).FirstOrDefault();

                if (order.Cod == 0)
                {
                    order.Cod = orderCod;
                }

                var ord = Context.FinancialModel.AsNoTracking().FirstOrDefault(x => x.Cod == orderCod);

                //Se não achar o pedido.
                if (ord == null)
                    return null;

                return FinancialRepository.EditFinancial(order);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Searchs
        public List<FinancialModel> GetFinancials()
        {
            try
            {
                return FinancialRepository.GetFinancials();
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public FinancialModel GetFinancial(int cod)
        {
            try
            {
                return FinancialRepository.GetFinancial(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public List<FinancialModel> GetFinancialsMonths()
        {
            try
            {
                return FinancialRepository.GetFinancialsMonths();
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion
    }
}
