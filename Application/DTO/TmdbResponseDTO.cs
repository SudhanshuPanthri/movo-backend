namespace Application.DTO
{
    public class Result
    {
        public Dates Dates { get; set; }
        public int Page { get; set; }
        public List<TmdbResponseDTO> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }

    public class Dates
    {
        public string Maximum { get; set; }
        public string Minimum { get; set; }
    }
    
    public class TmdbResponseDTO
    {
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public List<int> GenreIds { get; set; }
        public int Id { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public string ReleaseDate { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
    }
}