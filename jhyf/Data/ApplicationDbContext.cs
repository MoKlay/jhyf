using jhyf.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace jhyf.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Link>().Property(z => z.Id).UseIdentityColumn();
            builder.Entity<Link>().Property(z => z.NameFromLink).HasMaxLength(100);

            builder.Entity<Link>().HasData(
                new Link
                {
                    Id = 1,
                    NameFromLink = "Мой YouTube канал",
                    Linki = "www.youtube.com",
                });

            base.OnModelCreating(builder);
        }

        public DbSet<Link> Links { get; set; }

        public DbSet<AddHomework> Homeworks { get; set; }

        public DbSet<AddLectures> Lectures { get; set; }

        public DbSet<AddNews> News { get; set; }
    }
}
