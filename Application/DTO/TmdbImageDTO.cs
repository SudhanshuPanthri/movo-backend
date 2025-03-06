using Newtonsoft.Json;

namespace Application.DTO;

public class Backdrops
{
    [JsonProperty("aspect_ratio")]
    public double AspectRatio { get; set; }
    public int Height { get; set; }      
    [JsonProperty("iso_639_1")]
    public string? Iso6391 { get; set; }
    [JsonProperty("file_path")]
    public string FilePath { get; set; } 
    [JsonProperty("vote_average")]
    public double VoteAverage { get; set; }
    [JsonProperty("vote_count")]
    public int VoteCount { get; set; } 
    public int Width { get; set; }   
}

public class Logos
{
    [JsonProperty("aspect_ratio")]
    public double AspectRatio { get; set; }
    public int Height { get; set; }      
    [JsonProperty("iso_639_1")]
    public string? Iso6391 { get; set; }
    [JsonProperty("file_path")]
    public string FilePath { get; set; } 
    [JsonProperty("vote_average")]
    public double VoteAverage { get; set; }
    [JsonProperty("vote_count")]
    public int VoteCount { get; set; } 
    public int Width { get; set; }     
}

public class Posters
{
    [JsonProperty("aspect_ratio")]
    public double AspectRatio { get; set; }
    public int Height { get; set; }      
    [JsonProperty("iso_639_1")]
    public string? Iso6391 { get; set; }
    [JsonProperty("file_path")]
    public string FilePath { get; set; } 
    [JsonProperty("vote_average")]
    public double VoteAverage { get; set; }
    [JsonProperty("vote_count")]
    public int VoteCount { get; set; } 
    public int Width { get; set; }   
}

public class TmdbImageDTO
{
    public List<Backdrops> Backdrops { get; set; }
    public int Id { get; set; }
    public List<Logos> Logos { get; set; }
    public List<Posters> Posters { get; set; }
}