using LawFirmDataBaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmDataBaseImplement
{
    public class LawFirmDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-1L0DP37\SQLEXPRESS;Initial Catalog=LawFirmDatabaseHomework;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Blank> Blanks { set; get; }
        public virtual DbSet<Product> Products { set; get; }
        public virtual DbSet<ProductBlank> ProductBlanks { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Sklad> Sklads { set; get; }
        public virtual DbSet<SkladBlank> SkladBlanks { set; get; }
    }
}
