namespace Domain.Models
{
    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        PayPal,
        Razorpay
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded
    }

    public class Payment
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }  
        public PaymentStatus PaymentStatus { get; set; } 
        public string? PaymentReference { get; set; }

        public User? User { get; set; }
        public Booking? Booking { get; set; }
    }
}
