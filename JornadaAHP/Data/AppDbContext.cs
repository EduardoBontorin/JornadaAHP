using JornadaAHP.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace JornadaAHP.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}
        public DbSet<Motor> Motores { get; set; }
        public DbSet<Fonte> Fontes { get; set; }
        public DbSet<Drive> Drives { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Pontuacao>().HasNoKey();
        }
    }
}
