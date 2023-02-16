using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarModelInAspNetCoreWebAppWithEntityFrameWorkTest.Models;

namespace CarModelInAspNetCoreWebAppWithEntityFrameWorkTest.Data
{
    public class CarModelInAspNetCoreWebAppWithEntityFrameWorkTestContext : DbContext
    {
        public CarModelInAspNetCoreWebAppWithEntityFrameWorkTestContext (DbContextOptions<CarModelInAspNetCoreWebAppWithEntityFrameWorkTestContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Car { get; set; } = default!;
    }
}
