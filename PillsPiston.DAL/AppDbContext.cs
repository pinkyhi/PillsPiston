using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PillsPiston.DAL.Entities;

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
                        Model = "Basic"
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

            modelBuilder.Entity<Relationship>()
                .HasKey(e => new { e.SubjectId, e.WatcherId });


        }
    }
}
