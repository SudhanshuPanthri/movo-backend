using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<ShowTime> ShowTimes { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User Table Configuration
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasIndex(u => u.Email)
                .IsUnique();

            // Movie Table Configuration
            modelBuilder.Entity<Movie>()
                .ToTable("Movies")
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);

            // Theater Table Configuration
            modelBuilder.Entity<Theater>()
                .ToTable("Theaters");

            // Showtime Table Configuration
            modelBuilder.Entity<ShowTime>()
                .ToTable("Showtimes")
                .HasOne(s => s.Movie)
                .WithMany(m => m.ShowTimes)
                .HasForeignKey(s => s.MovieId);

            modelBuilder.Entity<ShowTime>()
                .HasOne(s => s.Theater)
                .WithMany(t => t.ShowTimes)
                .HasForeignKey(s => s.TheaterId);

            // Seat Table Configuration
            modelBuilder.Entity<Seat>()
                .ToTable("Seats")
                .HasOne(seat => seat.ShowTime)
                .WithMany(s => s.Seats)
                .HasForeignKey(seat => seat.ShowTimeId);

            modelBuilder.Entity<Seat>()
                .HasMany(s => s.BookingDetails)
                .WithOne(bd => bd.Seat)
                .HasForeignKey(bd => bd.SeatId)
                .OnDelete(DeleteBehavior.Restrict);

            // Booking Table Configuration
            modelBuilder.Entity<Booking>()
                .ToTable("Bookings")
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.ShowTime)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.ShowTimeId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Payment)
                .WithOne(p => p.Booking)
                .HasForeignKey<Payment>(p => p.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // BookingDetail Table Configuration
            modelBuilder.Entity<BookingDetail>()
                .ToTable("BookingDetails")
                .HasOne(bd => bd.Booking)
                .WithMany(b => b.BookingDetails)
                .HasForeignKey(bd => bd.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookingDetail>()
                .HasOne(bd => bd.Seat)
                .WithMany(s => s.BookingDetails)
                .HasForeignKey(bd => bd.SeatId)
                .OnDelete(DeleteBehavior.Restrict);

            // Payment Table Configuration
            modelBuilder.Entity<Payment>()
                .ToTable("Payments")
                .HasOne(p => p.Booking)
                .WithOne(b => b.Payment)
                .HasForeignKey<Payment>(p => p.BookingId);
        }
    }
}
