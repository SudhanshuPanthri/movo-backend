
namespace Domain.Models
{
    public class ShowTime
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int TheaterId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalSeats { get; set; }
        public int TotalSeatsAvailable { get; set; }
        public bool IsSoldOut { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Movie? Movie { get; set; }
        public Theater? Theater { get; set; }
        public ICollection<Seat>? Seats { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
