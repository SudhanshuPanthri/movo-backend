using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<ShowTime> Shows { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Booking> Tickets { get; set; }
        public DbSet<Payment> Payments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Bookings)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Payments)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
            
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.ShowTimes)
                .WithOne(s => s.Movie)
                .HasForeignKey(s => s.MovieId);
            
            modelBuilder.Entity<Theater>()
                .HasMany(t => t.ShowTimes)
                .WithOne(s => s.Theater)
                .HasForeignKey(s => s.TheaterId);
            
            modelBuilder.Entity<ShowTime>()
                .HasMany(s => s.Seats)
                .WithOne(se => se.ShowTime)
                .HasForeignKey(se => se.ShowTimeId);
            
            modelBuilder.Entity<ShowTime>()
                .HasMany(s => s.Bookings)
                .WithOne(t => t.ShowTime)
                .HasForeignKey(t => t.ShowTimeId);
            
            modelBuilder.Entity<Seat>()
                .HasMany(se => se.Bookings)
                .WithOne(t => t.Seat)
                .HasForeignKey(t => t.SeatId);
            
            modelBuilder.Entity<Booking>()
                .HasOne(t => t.Payment)
                .WithOne(p => p.Booking)
                .HasForeignKey<Payment>(p => p.PaymentId);
            
            modelBuilder.Entity<Seat>()
                .Property(se => se.Type)
                .HasConversion<string>(); 
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
