using YoutubersApi.Models;
using YoutubersApi.Repositories;

namespace YoutubersApi.Services;

public class YoutuberService : IYoutuberService
{

    private readonly IYoutuberRepository _repository;


    public YoutuberService(IYoutuberRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Youtuber>> GetAllAsync()
    {
        return await _repository.GetAllYoutubersAsync();
    }
    public async Task<Youtuber?> GetByIdAsync(int id)
    {
        return await _repository.GetYoutuberByIdAsync(id);
    }
    public async Task<Youtuber> AddAsync(Youtuber youtuber)
    {
        Validate(youtuber);
        return await _repository.AddYoutuberAsync(youtuber);
    }
    public async Task<Youtuber?> UpdateAsync(int id, Youtuber youtuber)
    {
        var existing = await _repository.GetYoutuberByIdAsync(id);

        if (existing is null) return null;

        Validate(youtuber);

        existing.Name = youtuber.Name;
        existing.ChannelName = youtuber.ChannelName;
        existing.Subscribers = youtuber.Subscribers;
        existing.Category = youtuber.Category;
        
        await _repository.UpdateYoutuberAsync(existing);
        return existing;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteYoutuberAsync(id);
    }

    private static void Validate(Youtuber youtuber)
    {
        if (string.IsNullOrWhiteSpace(youtuber.Name))
            throw new ArgumentException("Name is required.");

        if (string.IsNullOrWhiteSpace(youtuber.ChannelName))
            throw new ArgumentException("Channel name is required.");

        if (youtuber.Subscribers < 0)
            throw new ArgumentException("Subscribers cannot be negative.");

        if (string.IsNullOrWhiteSpace(youtuber.Category))
            throw new ArgumentException("Category is required.");
    }
}