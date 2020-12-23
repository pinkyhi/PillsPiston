using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PillsPiston.Core.Enums;
using PillsPiston.DAL.Entities;
using System;

namespace PillsPiston.DAL
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Database InitValues
            
            modelBuilder.Entity<Device>().HasData(
                new Device[]
                {
                    new Device
                    {
                        Id = "1fd5ce18-33ed-49d7-9fe5-113fce9dd7ee",
                        Model = DeviceModelsEnum.Medium
                    }
                }
            );
            modelBuilder.Entity<Cell>().HasData(
               new Cell[]
               {
                     new Cell{
                         Id = "82c74137-0ac2-4253-847f-91517f0fe65b",
                         DeviceId = "1fd5ce18-33ed-49d7-9fe5-113fce9dd7ee"
                     },
                     new Cell{
                         Id = "95580112-8343-4bb8-8986-86ce6bcfed56",
                         DeviceId = "1fd5ce18-33ed-49d7-9fe5-113fce9dd7ee"
                     },
                     new Cell{
                         Id = "d2c5370c-0e4a-4029-80b0-c81b8dd10ca5",
                         DeviceId = "1fd5ce18-33ed-49d7-9fe5-113fce9dd7ee"

                     }
               }
           );
           modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole[]
               {
                    new IdentityRole
                    {
                        Id = "c8047019-3c79-4931-8d17-565e0a3e179e",
                        Name = "admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = "79eee7aa-a6fd-490e-8a8b-87c1d7b18eac"
                    }
               }
           );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>[]
                    {

                        new IdentityUserRole<string>
                        {
                            UserId = "f3239ef1-0a8e-4177-bcc9-aba6e8c9f40a",
                            RoleId = "c8047019-3c79-4931-8d17-565e0a3e179e"
                        }
                    }
                );
            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = "f3239ef1-0a8e-4177-bcc9-aba6e8c9f40a",
                        RegistrationDate = DateTime.Now,
                        UserName = "string",
                        NormalizedUserName = "STRING",
                        Email = "user@example.com",
                        NormalizedEmail = "USER@EXAMPLE.COM",
                        EmailConfirmed = false,
                        PasswordHash = "AQAAAAEAACcQAAAAEGTyVrwmp9kP+aopbU7o0UE4obPpwMrPgQIBivdapczHKHZyYhDLG594OKMpep/M8A==",
                        SecurityStamp = "IKG47N6O46QYWGSQVCK5JG3RDK34XEZU",
                        ConcurrencyStamp = "48b6196a-3a8f-4581-90f7-8357747db012",
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    }
                );

            modelBuilder.Entity<User>()
                .HasMany(u => u.Subjects)
                .WithOne(s => s.Subject)
                .HasForeignKey(s => s.SubjectId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Watchers)
                .WithOne(s => s.Watcher)
                .HasForeignKey(s => s.WatcherId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Devices)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Device>()
                .HasMany(d => d.Cells)
                .WithOne(c => c.Device)
                .HasForeignKey(c => c.DeviceId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Cell>()
                .HasMany(d => d.Adoptions)
                .WithOne(c => c.Cell)
                .HasForeignKey(c => c.CellId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Cell>()
                .HasMany(d => d.Notifications)
                .WithOne(c => c.Cell)
                .HasForeignKey(c => c.CellId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cell>()
                .Property(c => c.Model)
                .HasConversion<int>();
            modelBuilder.Entity<Device>()
                .Property(c => c.Model)
                .HasConversion<int>();
            modelBuilder.Entity<Relationship>()
                .Property(c => c.RelationshipStatus)
                .HasConversion<int>();

            modelBuilder.Entity<Relationship>()
                .HasKey(e => new { e.SubjectId, e.WatcherId });


        }
    }
}
