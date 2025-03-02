namespace Domain.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public int SeatNumber { get; set; }
        public int ShowTimeId { get; set; }
        public int TheaterId { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ShowTime? ShowTime { get; set; }
        public ICollection<BookingDetail>? BookingDetails { get; set; }
    }
}
