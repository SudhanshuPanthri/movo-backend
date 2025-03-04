namespace Domain.Models
{
    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }
    
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int SeatId { get; set; }
        public int ShowTimeId { get; set; }
        public DateTime BookingTime { get; set; }
        public decimal Price { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public string? BookingReference { get; set; }
        public int TmdbMovieId { get; set; }

        public User? User { get; set; }
        public ShowTime? ShowTime { get; set; }
        public Seat? Seat { get; set; }
        public Payment? Payment { get; set; }
    }
}
