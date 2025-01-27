using EcommerseBlazor.Models;
namespace EcommerseBlazor.Services;

public interface IBeatService
{
    Task<List<Beat>> GetBeatsAsync();
    Task<Beat> GetBeatByIdAsync(int Id);
     Task CreateBeatAsync(Beat beat);
    Task UpdateBeatAsync(Beat beat);
    Task DeleteBeatAsync(int id);
}
