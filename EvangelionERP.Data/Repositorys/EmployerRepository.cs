using EvangelionERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvangelionERP.Data.Repositorys
{
    public class EmployerRepository : BaseRepository<EmployerModel>
    {
        private readonly Context Context;
        public EmployerRepository([FromServices] Context context) : base(context) => Context = context;
    }
}
