namespace Domain.Models
{
    public class Theater
    {
        public int TheaterId { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? City { get; set; }
        public int Capacity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<ShowTime>? ShowTimes { get; set; }
        public ICollection<Seat>? Seats { get; set; }
    }
}
