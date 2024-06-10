using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;

namespace DAL
{
    public class ApplicationContext
        : DbContext
    {
        private readonly byte[] _encryptionKey = { 253, 122, 245, 97, 4, 223, 128, 147, 131, 135, 67, 75, 31, 140, 241, 160 };
        private readonly byte[] _encryptionIV = { 253, 122, 245, 97, 4, 223, 128, 147, 131, 135, 67, 75, 31, 140, 241, 160 };
        private readonly IEncryptionProvider _provider;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            _provider = new AesProvider(_encryptionKey, _encryptionIV);
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new[]
            {
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },

                new Role
                {
                    Id = 2,
                    Name = "Editor"
                },
            });
            modelBuilder.Entity<User>().HasData(new[]
            {
                new User
                {
                    Id = 1,
                    Login = "Admin",
                    Password = "ADGjgVNFqMy8qsaVNwuhPyW96mam0F6+zuAgkLjiNTc7YFfz4zoo4YWk7qnFTCciPg==",
                    Name = "Admin",
                    IsDeleted = false,
                    RoleId = 1

                }
            });
            modelBuilder.Entity<Dye>().HasData(new[]
            {
                new Dye
                {
                    Id = 1,
                    Name = "Blue",
                },
                new Dye
                {
                    Id = 2,
                    Name = "Black",
                }
            });
            modelBuilder.Entity<PrintingPress>().HasData(new[]
            {
                new PrintingPress
                {
                    Id = 1,
                    Name = "First Printing press"
                }
            });
            modelBuilder.Entity<Material>().HasData(new[]
            {
                new Material
                {
                    Id = 1,
                    Name = "First",
                    Content = "Some Content",
                    Format = "A4",
                    DyeId = 1
                },
                new Material
                {
                    Id = 2,
                    Name = "Second",
                    Content = "Some Content",
                    Format = "A4",
                    DyeId = 1
                },
            });

            modelBuilder.UseEncryption(_provider);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Dye> Dyes { get; set; }
        public DbSet<Edition> Editions{ get; set; }
        public DbSet<PrintingPress> PrintingPresses{ get; set; }
        public DbSet<Material> Materials{ get; set; }

    }
}

