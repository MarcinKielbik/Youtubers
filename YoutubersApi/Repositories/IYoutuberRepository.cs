using YoutubersApi.Models;

namespace YoutubersApi.Repositories;

public interface IYoutuberRepository
{
    Task<List<Youtuber>> GetAllYoutubersAsync();
    Task<Youtuber?> GetYoutuberByIdAsync(int id);
    Task<Youtuber> AddYoutuberAsync(Youtuber youtuber);
    Task UpdateYoutuberAsync(Youtuber youtuber);
    Task<bool> DeleteYoutuberAsync(int id);
}
