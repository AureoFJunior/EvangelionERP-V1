using Microsoft.AspNetCore.Mvc;
using EvangelionERP.Data;
using EvangelionERP.Data.Repositorys;
using EvangelionERP.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EvangelionERP.Test
{
    public class ContextFactory
    {
        public readonly Context context;

        public ContextFactory()
        {
            var options = new DbContextOptionsBuilder<Context>()
           .UseSqlServer("Server=AMAJIKI\\SQLEXPRESS;Database=evangelionERP;Trusted_Connection=True;")
           .Options;

            // Insert seed data into the database using one instance of the context
            context = new Context(options);
        }
    }
}