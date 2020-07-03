using ECommerce.Model.EFModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Model
{
    public class EcommerceContextFactory : IDesignTimeDbContextFactory<EcommerceContext>
    {
        public EcommerceContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EcommerceContext>();
            optionsBuilder.UseSqlServer("Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=WebDongHo;Integrated Security=True");

            return new EcommerceContext(optionsBuilder.Options);
        }
    }
}
