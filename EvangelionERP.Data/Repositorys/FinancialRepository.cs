using EvangelionERP.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
