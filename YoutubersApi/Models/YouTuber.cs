namespace YoutubersApi.Models;

public class Youtuber
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string ChannelName {get; set; } = string.Empty;

    public int Subscribers {get; set;}

    public string Category {get; set;} = string.Empty;
}