using Application.DTO;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
namespace Application.Services;

public class TMDBService:ITMDBService
{
    private readonly HttpClient _httpClient;
    private readonly RestClient _restClient;
    private readonly string _APIKEY;
    public TMDBService(HttpClient httpClient,IConfiguration  config)
    {
        _httpClient = httpClient;
        _APIKEY = config.GetSection("TMDBAPI").Value;
        _restClient=new RestClient("https://api.themoviedb.org/3");
    }
    
    public async Task<List<TmdbResponseDTO>> GetNowPlaying(int page)
    {
        var request = new RestRequest("movie/now_playing", Method.Get);
        request.AddQueryParameter("language", "en-US");
        request.AddQueryParameter("page", page.ToString());
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", $"Bearer {_APIKEY}");

        var response = await _restClient.ExecuteAsync(request);

        if (response.IsSuccessful)
        {
            var data = JsonConvert.DeserializeObject<Result>(response.Content);
            
            return data?.Results ?? new List<TmdbResponseDTO>();
        }
        else
        {
            throw new Exception($"Error: {response.ErrorMessage}");
        }
    }

    
    public async Task<List<TmdbResponseDTO>> GetPopular(int page)
    {
        var request = new RestRequest("movie/popular", Method.Get);
        request.AddQueryParameter("language", "en-US");
        request.AddQueryParameter("page", page.ToString());
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", $"Bearer {_APIKEY}");

        var response = await _restClient.ExecuteAsync<Result>(request);
            
        if (response.IsSuccessful)
        {
            var data = JsonConvert.DeserializeObject<Result>(response.Content);
            return data?.Results ?? new List<TmdbResponseDTO>();
        }
        else
        {
            throw new Exception($"Error: {response.ErrorMessage}");
        }
    }
    
    public async Task<List<TmdbResponseDTO>> GetTopRated(int page)
    {
        var request = new RestRequest("movie/top_rated", Method.Get);
        request.AddQueryParameter("language", "en-US");
        request.AddQueryParameter("page", page.ToString());
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", $"Bearer {_APIKEY}");

        var response = await _restClient.ExecuteAsync<List<object>>(request);
            
        if (response.IsSuccessful)
        {
            var data = JsonConvert.DeserializeObject<Result>(response.Content);
            
            return data?.Results ?? new List<TmdbResponseDTO>();
        }
        else
        {
            throw new Exception($"Error: {response.ErrorMessage}");
        }
    }
    
    //MOVIE SPECIFIC METHODS

    public async Task<TmdbMovieDetailDTO> GetDetail(int id)
    {
        var request = new RestRequest($"movie/{id}", Method.Get);
        request.AddQueryParameter("language", "en-US");
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", $"Bearer {_APIKEY}");

        var response = await _restClient.ExecuteAsync<object>(request);
            
        if (response.IsSuccessful)
        {
            var data = JsonConvert.DeserializeObject<TmdbMovieDetailDTO>(response.Content);
            
            return data;
        }
        else
        {
            throw new Exception($"Error: {response.ErrorMessage}");
        }
    }
}




