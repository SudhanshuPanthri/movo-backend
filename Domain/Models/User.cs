﻿namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
        
        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
