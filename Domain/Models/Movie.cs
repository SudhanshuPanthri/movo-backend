namespace Domain.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public int GenreId { get; set; }
        public int Duration { get; set; }
        public string? Rating { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Genre? Genre { get; set; }
        public ICollection<ShowTime>? ShowTimes { get; set; }
    }
}
