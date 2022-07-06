using EvangelionERP.Models;
using Microsoft.AspNetCore.Mvc;
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

    }
}
