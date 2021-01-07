using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWorkTask18
{
    public class ContextClass:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "Data Source=192.168.50.95;Initial Catalog=pnimmagadda;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            optionsBuilder.UseSqlServer(conn);
            base.OnConfiguring(optionsBuilder);

        }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> ProductDetails { get; set; }
    }
}

