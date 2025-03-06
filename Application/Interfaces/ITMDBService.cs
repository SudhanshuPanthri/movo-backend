using Application.DTO;

namespace Application.Interfaces;

public interface ITMDBService
{ 
        Task<List<TmdbResponseDTO>> GetNowPlaying(int page); 
        Task<List<TmdbResponseDTO>> GetPopular(int page);
        Task<List<TmdbResponseDTO>> GetTopRated(int page);
        Task<TmdbMovieDetailDTO> GetDetail(int id);
        Task<TmdbImageDTO> GetImages(int id);
}