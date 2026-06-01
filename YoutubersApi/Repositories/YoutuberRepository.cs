using Microsoft.EntityFrameworkCore;
using YoutubersApi.Models;
using YoutubersApi.Data;

namespace YoutubersApi.Repositories;

public class YoutuberRepository : IYoutuberRepository  
{
    private readonly AppDbContext _context;

    public YoutuberRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Youtuber>> GetAllYoutubersAsync()
    {
        return await _context.Youtubers.ToListAsync();
    }

    public async Task<Youtuber?> GetYoutuberByIdAsync(int id)
    {
        return await _context.Youtubers.FindAsync(id);
    }

    public async Task<Youtuber> AddYoutuberAsync(Youtuber youtuber)
    {
        _context.Youtubers.Add(youtuber);
        await _context.SaveChangesAsync();
        return youtuber;
    }

    public async Task UpdateYoutuberAsync(Youtuber youtuber)
    {
        _context.Youtubers.Update(youtuber);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteYoutuberAsync(int id)
    {
        var youtuber = await _context.Youtubers.FindAsync(id);
        if (youtuber is null)
            return false;

        _context.Youtubers.Remove(youtuber);
        await _context.SaveChangesAsync();
        return true;
    }
}