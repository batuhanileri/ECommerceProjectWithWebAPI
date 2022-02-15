using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        //OnConfiguring ile hangi veritabanını ilişkilendireceğimiz yer
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //DbSet ile hangi nesne hangi nesneye karşılık gelicek 
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


    }
}
