// using EcommerseBlazor.Models;
using EcommerseBlazor.Data;
using Microsoft.EntityFrameworkCore;

namespace EcommerseBlazor.Services;

public class BeatService : IBeatService
{
    private readonly BeatStoreContext _context;

    // Contructor
    public BeatService(BeatStoreContext contect){
        _context = contect;
    }

    public async Task<Beat> CreateBeatAsync(Beat beat)
    {

        var newBeat = new Beat
        {
            Title = beat.Title,
            Description = beat.Description,
            Genre = beat.Genre,            
            Price = beat.Price,
            FilePath = beat.FilePath,
            CoverImagePath = beat.CoverImagePath,
            UploadedBy = beat.UploadedBy,
            UploadDate = DateTime.Now,
            GenreID = beat.GenreID
        };

        try
        {
            await _context.AddAsync(newBeat);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
        return newBeat;
    }

    public Task<bool> DeleteBeatAsync(Beat beat)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Beat>> GetBeatListAsync()
    {
        IEnumerable<Beat> beats = await _context.Beats.ToListAsync();
        return beats;
        // throw new NotImplementedException();
    }

    public Task<bool> UploadBeat(int id)
    {
        throw new NotImplementedException();
    }
}

