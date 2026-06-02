using YoutubersApi.Models;

namespace YoutubersApi.Services;

public interface IYoutuberService
{
    Task<List<Youtuber>> GetAllAsync();
    Task<Youtuber?> GetByIdAsync(int id);
    Task<Youtuber> AddAsync(Youtuber youtuber);
    Task<Youtuber?> UpdateAsync(int id, Youtuber youtuber);
    Task<bool> DeleteAsync(int id);
}