using Domain.Models;

namespace Infrastructure.Interfaces;

public interface ITheatre
{
    Task<bool> AddTheater(Theater theater);
    Task<bool> UpdateTheater(Theater theater);
    Task<bool> DeleteTheater(int theaterId);
    Task<List<Theater>> GetTheaters();
    Task<Theater?> GetTheater(int theaterId);
    Task<List<Theater>> GetTheatersByName(string name);
    Task<List<Theater>> GetTheatersByLocation(string location);
    Task<List<Theater>> GetTheatersByCity(string city);
}