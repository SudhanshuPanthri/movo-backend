using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using Infrastructure.Interfaces;
namespace Infrastructure.Implementation;

public class SeatRepo:ISeat
{
    private readonly ContextDB  _context;

    public SeatRepo(ContextDB context)
    {
        _context = context;
    }

    public async Task<List<Seat>> GetSeats()
    {
        try
        {
            var data = await _context.Seats.Where(x=>x.ShowTimeId==null).ToListAsync();
            if (data == null)
            {
                return null;
            }
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<Seat>();
        }
    }
    
    public async Task<Seat> GetSeat(int seatNumber)
    {
        try
        {
            var data = await _context.Seats.FirstOrDefaultAsync(x=>x.SeatId==seatNumber);
            if (data == null)
            {
                return null;
            }
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Seat();
        }
    }
    
    public async Task<List<Seat>> GetSeatsByTheatre(int theatreId)
    {
        try
        {
            var data = await _context.Seats.Where(x => x.TheaterId == theatreId).ToListAsync();
            if (data == null)
            {
                return null;
            }
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<Seat>();
        }
    }
}