using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation;

public class TheatreRepo:ITheatre
{
    private readonly ContextDB _context;
    
    public TheatreRepo(ContextDB context)
    {
        _context = context; 
    }

    public async Task<bool> AddTheater(Theater theater)
    {
        var data=await _context.Theaters.FindAsync(theater.TheaterId);
        if (data == null)
        {
            _context.Theaters.Add(theater);
            await _context.SaveChangesAsync();
            return true;
        }
        else
        {
            throw new Exception("Theatre already exists");
            return false;
        }
    }

    public async Task<bool> UpdateTheater(Theater theater)
    {
        var data=await _context.Theaters.FindAsync(theater.TheaterId);
        if (data != null)
        {
            _context.Theaters.Update(theater);
        }
        else
        {
            _context.Theaters.Add(theater);
        }

        return true;
    }

    public async Task<bool> DeleteTheater(int theaterId)
    {
        var data=await _context.Theaters.FindAsync(theaterId);
        if (data != null)
        {
            _context.Theaters.Remove(data);
            return true;
        }
        else
        {
            throw new Exception("There is nothing to remove");
            return false;
        }
    }

    public async Task<List<Theater>> GetTheaters()
    {
        var data = await _context.Theaters.ToListAsync();
        if (data != null)
        {
            return data;
        }
        else
        {
            return new List<Theater>();
        }
    }

    public async Task<Theater?> GetTheater(int theaterId)
    {
        var data=await _context.Theaters.FindAsync(theaterId);
        if (data != null)
        {
            return data;
        }
        else
        {
            throw new Exception("Could n't find theater with the id");
        }
    }

    public async Task<List<Theater>> GetTheatersByName(string name)
    {
        var data=await _context.Theaters.Where(x=>x.Name.Contains(name)).ToListAsync();
        if (data != null)
        {
            return data;
        }
        else
        {
            return new List<Theater>();
        }
    }

    public async Task<List<Theater>> GetTheatersByLocation(string location)
    {
        var data=await _context.Theaters.Where(x => x.Location.Contains(location)).ToListAsync();
        if (data != null)
        {
            return data;
        }
        else
        {
            return new List<Theater>();
        }
    }

    public async Task<List<Theater>> GetTheatersByCity(string city)
    {
        var data=await _context.Theaters.Where(x=>x.City.Contains(city)).ToListAsync();
        if (data != null)
        {
            return data;
        }
        else
        {
            return new List<Theater>();
        }
    }
}