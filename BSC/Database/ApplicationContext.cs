using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSC.Database
{
    public class ApplicationContext : DbContext {
        public DbSet<Models.Token> Tokens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=sqlitedemo.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Models.Token>()
                .HasKey(k => new { k.Id, k.UpdatedAt });
        }
    }
}
