using EvangelionERP.Models;
using System;
using System.Linq;


namespace EvangelionERP.Services
{
    public static class EvaUtil
    {
        public static FinancialModel FormatChartInfo(int month)
        {
            FinancialModel financial = new FinancialModel()
            {
                Cod = 0,
                InclusionDate = new DateTime(DateTime.Now.Year, month, 30),
                TotalValue = 0
            };

            return financial;
        }
    }
}
