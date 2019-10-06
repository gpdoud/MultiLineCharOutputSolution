using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineCharOutput {
    
    public class AppDbContext : DbContext {

        public virtual DbSet<AP> APs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public AppDbContext() {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            var connStr = @"server=localhost\sqlexpress;database=ApDb;trusted_connection=true;";
            options.UseSqlServer(connStr);
        }
        protected override void OnModelCreating(ModelBuilder builder) {}
    }
}
