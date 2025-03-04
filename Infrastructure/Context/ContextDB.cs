using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options)
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
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for Users
            
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

            // Prevent cascading delete for ShowTime and Theater relationships
            modelBuilder.Entity<Seat>()
                .HasOne(se => se.ShowTime)
                .WithMany(st => st.Seats)
                .HasForeignKey(se => se.ShowTimeId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete for ShowTime
            
            modelBuilder.Entity<Seat>()
                .HasOne(se => se.Theater)
                .WithMany(t => t.Seats)
                .HasForeignKey(se => se.TheaterId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for Theater
            
            // Fixing the foreign key for Payments table:
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithOne(b => b.Payment)
                .HasForeignKey<Payment>(p => p.PaymentId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for Payment-Booking relationship

            base.OnModelCreating(modelBuilder);
        }
    }
}
