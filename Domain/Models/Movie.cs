using Newtonsoft.Json; 

namespace Domain.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public bool Adult {get;set;}
        public string? OriginalLanguage { get; set; }
        
        public string? SerializedGenreIds { get; set; }  // Store the genres as a serialized string
        
        public decimal VoteAverage { get; set; }
        public int Duration { get; set; }
        public string? Rating { get; set; }
        public string? Overview { get; set; }
        public string? BackdropPath { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public ICollection<ShowTime>? ShowTimes { get; set; }

        // Deserialization method to get the List<int> back
        [JsonIgnore]  // Ignore this in serialization, if needed
        public List<int> GenreId 
        { 
            get => SerializedGenreIds != null ? JsonConvert.DeserializeObject<List<int>>(SerializedGenreIds) : new List<int>(); 
            set => SerializedGenreIds = JsonConvert.SerializeObject(value); 
        }
    }
}