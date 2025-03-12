using EcommerseBlazor.Components.Pages;
using EcommerseBlazor.Data;
using EcommerseBlazor.Models;
using EcommerseBlazor.Services;
using Microsoft.EntityFrameworkCore;

namespace EcommerseBlazor.Services;

public class BeatService : IBeatService
{
    private readonly BeatStoreDbContext _context;


    public BeatService(BeatStoreDbContext context)
    {
        _context = context;
    }


    public async Task<List<Beat>> GetBeatsAsync()
    {
        // try
        // {
            return await _context.Beats.ToListAsync();
        // }
        // catch (TaskCanceledException )
        // {
        //     Console.WriteLine("Database operation was canceled.");
        //     return new List<Beat>();
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine($"Error fetching beats: {ex.Message}");
        //     return new List<Beat>();
        // }
    }


    public async Task<Beat> GetBeatByIdAsync(int id)
    {
         var beat = await _context.Beats.FindAsync(id);
         if(beat is not null){
            return beat;
        }

        return new Beat();
    }


    public async Task CreateBeatAsync(Beat beat)
    {
        try {

        _context.Beats.Add(beat);
        await _context.SaveChangesAsync();
        }catch(Exception ex) {
            Console.WriteLine(ex);
        }
    }

    public async Task UpdateBeatAsync(Beat beat)
    {
        _context.Beats.Update(beat);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteBeatAsync(int id)
    {
        var beat = await _context.Beats.FindAsync(id);
        if (beat != null)
        {
            _context.Beats.Remove(beat);
            await _context.SaveChangesAsync();
        }
    }
}
