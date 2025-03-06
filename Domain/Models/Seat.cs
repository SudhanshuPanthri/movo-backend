namespace Domain.Models
{

    public enum SeatType
    {
        Standard,
        VIP,
        Premium
    }
    public class Seat
    {
        public int SeatId { get; set; }
        public string? SeatNumber { get; set; }
        public int? ShowTimeId { get; set; }
        public int TheaterId { get; set; }
        public bool IsBooked { get; set; }
        public SeatType? Type { get; set; }

        public ShowTime? ShowTime { get; set; }
        public Theater? Theater { get; set; } 
        public ICollection<Booking>? Bookings { get; set; }
    }
}
