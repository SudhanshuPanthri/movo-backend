namespace Domain.Models
{
    public class Booking
    {
        //This table stores booking information for users who have reserved seats for a movie at a specific showtime.
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int ShowTimeId { get; set; }
        public decimal TotalPrice { get; set; }
        public string? BookingStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User? User { get; set; }
        public ShowTime? ShowTime { get; set; }
        public ICollection<BookingDetail>? BookingDetails { get; set; }
        public int PaymentId { get; set; }
        public Payment? Payment { get; set; }
    }
}
