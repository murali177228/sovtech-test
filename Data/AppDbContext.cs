using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sovtech_test.Data
{
    public class AppDbContext : DbContext
    {
        //public DbSet<Chuck> Chucks { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
    }
}