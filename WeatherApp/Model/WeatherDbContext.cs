using Microsoft.EntityFrameworkCore;

namespace WeatherApp.Model
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext()
        {
        }

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Weather> Weather { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weather>(entity =>
            {
                entity.Property(e => e.Min)
                    .IsRequired();

                entity.Property(e => e.Max)
                    .IsRequired();

                entity.Property(e => e.Adjective)
                   .IsRequired();
            });
        }
    }
}
