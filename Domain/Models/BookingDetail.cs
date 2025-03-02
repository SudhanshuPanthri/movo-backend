namespace Domain.Models
{
    public class BookingDetail
    {
        //This table stores the seat-specific details for a booking(i.e., which seats were selected by the user).
        public int BookingDetailId { get; set; }
        public int BookingId { get; set; }
        public int SeatId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Booking? Booking { get; set; }
        public Seat? Seat { get; set; }
    }
}
