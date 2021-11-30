using Dsi.Spg.Ui.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsi.Spg.Ui.Data.Context
{
    public class SpgDbContext : DbContext
    {
        public SpgDbContext(DbContextOptions<SpgDbContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {}

        public DbSet<Member>? Members { get; set; }
        public DbSet<Platform>? Platforms { get; set; }
    }
}
