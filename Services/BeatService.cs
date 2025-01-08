using EcommerseBlazor.Models;
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
            GenreId = beat.GenreId,
            Purchases = beat.Purchases,
            UploadedByNavigation = beat.UploadedByNavigation,
        };

        await _context.AddAsync(newBeat);

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
    }

    public Task<bool> UploadBeat(int id)
    {
        throw new NotImplementedException();
    }
}

