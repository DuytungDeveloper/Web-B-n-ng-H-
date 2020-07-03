using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Model.EFModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class ApplicationDbContext : EcommerceContext
    {
        public ApplicationDbContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }
    }
}
