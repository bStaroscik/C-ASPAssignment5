using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment4.Models;

namespace Assignment4.Data
{
    public class Assignment4DbContext : DbContext
    {
        public Assignment4DbContext (DbContextOptions<Assignment4DbContext> options)
            : base(options)
        {
        }

        public DbSet<FuelCalcItem> FuelCalcItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FuelCalcItem>().HasData(
                new FuelCalcItem
                {
                    Id = 1,
                    StartOdometer = 0,
                    EndOdometer = 100,
                    AmountOfFuel = 50,
                    CostOfFuel = 25.5m
                }
                );

        }
    }
}
