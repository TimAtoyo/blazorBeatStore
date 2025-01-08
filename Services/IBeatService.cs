using EcommerseBlazor.Models;

namespace EcommerseBlazor.Services;

public interface IBeatService 
{
    Task<IEnumerable<Beat>> GetBeatListAsync();
    Task<Beat> CreateBeatAsync(Beat beat);
    Task<bool> DeleteBeatAsync(Beat beat);
    Task<bool> UploadBeat(int id);
}