using Microsoft.EntityFrameworkCore;
using reactsite.Domain.Entity;
using reactsite.Domain.Enum;
using reactsite.Domain.Helpers;

namespace reactsite.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {


        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Admin
            modelBuilder.Entity<User>(builder =>
            {


                builder.HasData(new User
                {
                    Id = 1,
                    Login = "Admin",
                    Password = HashPasswordHelper.HashPassword("123456"),
                    Role = Role.Admin
                });

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Login).HasMaxLength(100).IsRequired();

                builder.HasOne(x => x.Profile)
                     .WithOne(x => x.User)
                     .HasPrincipalKey<User>(x => x.Id)
                     .OnDelete(DeleteBehavior.Cascade);

               
            });
            //DefaultUser
            modelBuilder.Entity<User>(builder =>
            {


                builder.HasData(new User
                {
                    Id = 2,
                    Login = "DefaultUser",
                    Password = HashPasswordHelper.HashPassword("654321"),
                    Role = Role.User
                });

                builder.Property(x => x.Id).ValueGeneratedOnAdd();
                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Login).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Profile>(builder =>
            {


                builder.Property(x => x.Id).ValueGeneratedOnAdd();
                builder.Property(x => x.Age);
                builder.Property(x => x.Address).HasMaxLength(200).IsRequired(false);

                builder.HasData(new Profile()
                {
                    Id = 1,
                    UserId = 1
                });
            });

            
        }

    }
}
