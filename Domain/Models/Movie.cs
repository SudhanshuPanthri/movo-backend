namespace Domain.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public bool Adult {get;set;}
        public string? OriginalLanguage { get; set; }
        public List<int> GenreId { get; set; }=new List<int>();
        
        public decimal VoteAverage { get; set; }
        public int Duration { get; set; }
        public string? Rating { get; set; }
        public string? Overview { get; set; }
        public string? BackdropPath { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public ICollection<ShowTime>? ShowTimes { get; set; }
    }
}
