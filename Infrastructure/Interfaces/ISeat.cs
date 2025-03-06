using Domain.Models;

namespace Infrastructure.Interfaces;

public interface ISeat
{
    Task<List<Seat>> GetSeats();
    Task<Seat> GetSeat(int seatNumber);
    Task<List<Seat>> GetSeatsByTheatre(int theatreId);
}