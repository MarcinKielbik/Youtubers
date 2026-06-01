namespace YoutubersApi.Repositories;

public class YoutuberRepository
{
    private readonly AppDbContext _youtuberContext;

    public YoutuberRepository(AppDbContext youtuberContext)
    {
        _youtuberContext = youtuberContext;
    }

    public async Task<List<Youtuber>> GetAllYoutubersAsync()
    {
        return await _youtuberContext.Youtuber.ToListAsync();
    }

    public async Task<Youtuber?> GetYoutuberById(int id)
    {
        return await _youtuberContext.Youtuber.FindAsync(id);
    }

    public async Task<Youtuber> AddYoutuberById(Youtuber youtuber)
    {
        _youtuberContext.Youtuber.Add(youtuber);

        await _youtuberContext.SaveChangesAsync();

        return youtuber;
    }

    public async Task UpdateYoutuberAsync(Youtuber youtuber)
    {
        _youtuberContext.Youtuber.Update(youtuber);

        await _youtuberContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteYoutuberAsync(int id)
    {
        var youtuber = await _youtuberContext.Youtuber.FindAsync(id);

        if (youtuber is null)
        {
            return false;
        }

        _youtuberContext.Youtuber.Remove(youtuber);
        await _youtuberContext.SaveChangesAsync();
        return true;
    }

}