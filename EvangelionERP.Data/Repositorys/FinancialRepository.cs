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
    public class FinancialRepository : BaseRepository<FinancialModel>
    {
        private readonly Context Context;
        public FinancialRepository([FromServices] Context context) : base(context) => Context = context;

        #region Add
        public FinancialModel AddFinancial(OrderModel order)
        {
            try
            {
                FinancialModel financial = new FinancialModel();
                financial.Cod = 0;
                financial.InclusionDate = DateTime.Now;
                financial.TotalValue = Context.FinancialModel.OrderByDescending(x => x.InclusionDate).FirstOrDefault().TotalValue;

                if (order.FlOutput == true)
                {
                    financial.TotalValue += order.TotalValue;
                }
                else
                {
                    financial.TotalValue -= order.TotalValue;
                }

                return Add(financial);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Edit
        public FinancialModel EditFinancial(FinancialModel financial)
        {
            try
            {
                return Edit(financial);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Delete
        public FinancialModel DeleteFinancial(int cod)
        {
            try
            {
                return Delete(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Searchs
        public List<FinancialModel> GetFinancials()
        {
            try
            {
                return GetAll().OrderByDescending(x => x.Cod).ThenBy(x => x.InclusionDate).ToList();
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public FinancialModel GetFinancial(int cod)
        {
            try
            {
                FinancialModel financial = GetAll().OrderByDescending(x => x.InclusionDate).FirstOrDefault();

                if (cod == null || cod <= 0)
                    financial = GetById(cod);

                return financial;
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public List<FinancialModel> GetFinancialsMonths()
        {
            List<FinancialModel> financials = new List<FinancialModel>();
            FinancialModel financial = new FinancialModel();
            List<int> years = new List<int>();
            int oldYear = 0;

            var query = Context.FinancialModel.AsNoTracking().OrderByDescending(x => x.Cod).ThenBy(x => x.InclusionDate).ToList();

            foreach (FinancialModel fin in query)
            {
                if (fin.InclusionDate.Year != oldYear)
                {
                    years.Add(fin.InclusionDate.Year);
                }
                oldYear = fin.InclusionDate.Year;
            }

            //Pega o último financeiro de cada mês.
            foreach (int year in years)
            {
                financials.Add(Context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 1).OrderByDescending(x => x.Cod).FirstOrDefault()); //Jan
                financials.Add(Context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 2).OrderByDescending(x => x.Cod).FirstOrDefault()); //Fev
                financials.Add(Context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 3).OrderByDescending(x => x.Cod).FirstOrDefault()); //Mar
                financials.Add(Context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 4).OrderByDescending(x => x.Cod).FirstOrDefault()); //Abr
                financials.Add(Context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 5).OrderByDescending(x => x.Cod).FirstOrDefault()); //Mai
                financials.Add(Context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 6).OrderByDescending(x => x.Cod).FirstOrDefault()); //Jun
                financials.Add(Context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 7).OrderByDescending(x => x.Cod).FirstOrDefault()); //Jul
                financials.Add(Context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 8).OrderByDescending(x => x.Cod).FirstOrDefault()); //Ago
                financials.Add(Context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 9).OrderByDescending(x => x.Cod).FirstOrDefault()); //Set
                financials.Add(Context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 10).OrderByDescending(x => x.Cod).FirstOrDefault()); //Out
                financials.Add(Context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 11).OrderByDescending(x => x.Cod).FirstOrDefault()); //Nov
                financials.Add(Context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 12).OrderByDescending(x => x.Cod).FirstOrDefault()); //Dez
            }
            return financials.Where(x => x != null).ToList();
        }
        #endregion
    }
}
