using Microsoft.EntityFrameworkCore;
using EvangelionERP.Models;

namespace EvangelionERP.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserModel> UserModel { get; set; }
        public DbSet<EmployerModel> EmployerModel { get; set; }
        public DbSet<CustomerModel> CustomerModel { get; set; }
        public DbSet<ProductModel> ProductModel { get; set; }
        public DbSet<OrderProductModel> OrderProductModel { get; set; }
        public DbSet<OrderModel> OrderModel { get; set; }
        public DbSet<FinancialModel> FinancialModel { get; set; }
       
    }
}
