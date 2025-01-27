using EcommerseBlazor.Services;
using Microsoft.EntityFrameworkCore;
using EcommerseBlazor.Models;  // Make sure to include this for async LINQ operations.
using EcommerseBlazor.Data;  // Make sure to include this for async LINQ operations.

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
            return await _context.Beats.ToListAsync();  
        }

        
        public async Task<Beat> GetBeatByIdAsync(int id)
        {
            return await _context.Beats.FindAsync(id);  
        }

        
        public async Task CreateBeatAsync(Beat beat)
        {
            _context.Beats.Add(beat);  
            await _context.SaveChangesAsync(); 
        }

        // Update an existing beat asynchronously
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
