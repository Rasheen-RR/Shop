using Shop.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace Shop.Contexts
{
    public class NorthWindContext : DbContext
    {

        public DbSet<Categories> categories { get; set; }
        public DbSet<Customers> customers { get; set; }
        public DbSet<Employees> employees { get; set; }
        public DbSet<EmployeeTerritories> employeeteritorries { get; set; }
        public DbSet<OrderDetails> orderdetails { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Region> region { get; set; }
        public DbSet<Shippers> shippers { get; set; }
        public DbSet<Suppliers> suppliers { get; set; }
        public DbSet<Territories> territories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Default");
        }

        public NorthWindContext(
           Microsoft.EntityFrameworkCore.DbContextOptions<NorthWindContext> options)
           : base(options)
        {
        }
    }
}

