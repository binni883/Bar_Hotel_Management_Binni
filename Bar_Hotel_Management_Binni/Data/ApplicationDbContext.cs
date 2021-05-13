using System;
using System.Collections.Generic;
using System.Text;
using Bar_Hotel_Management_Binni.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bar_Hotel_Management_Binni.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Wine> Wines { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodRateList> FoodRateLists { get; set; }
        public DbSet<TableOrder> TableOrders { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
