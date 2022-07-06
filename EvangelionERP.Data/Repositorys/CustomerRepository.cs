using EvangelionERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvangelionERP.Data.Repositorys
{
    public class CustomerRepository : BaseRepository<CustomerModel>
    {
        private readonly Context Context;
        public CustomerRepository([FromServices] Context context) : base(context) => Context = context;
    }
}
