namespace Domain.Models
{
    public class Payment
    {
        //Will be using packages like Stripe, Razorpay, etc. to handle payments.
        //Dummy Model as of now
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Booking? Booking { get; set; }
    }
}
