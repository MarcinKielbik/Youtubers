


namespace YoutubersApi.Repositories;

public interface IYoutuberRepository
{
    Task<List<Youtuber>> GetAllYoutubersAsync();
    Task<Youtuber?> GetYoutuberById(int id);

    Task<Youtuber> AddYoutuberById(Youtuber youtuber);

    Task UpdateYoutuberAsync(Youtuber youtuber);

    Task<bool> DeleteYoutuberAsync(int id);
}
