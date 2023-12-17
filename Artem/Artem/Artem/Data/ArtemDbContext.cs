using Microsoft.EntityFrameworkCore;
using Artem.Models;
using System.Collections.Generic;

namespace Artem.Data
{
    public class ArtemDbContext : DbContext
    {
        public ArtemDbContext(DbContextOptions<ArtemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Report> Reports { get; set; }
    }
}
