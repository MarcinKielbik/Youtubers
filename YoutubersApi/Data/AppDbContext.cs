using Microsoft.EntityFrameworkCore;
using YoutubersApi.Models;

namespace YoutubersApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}


    public DbSet<Youtuber> Youtubers => Set<Youtuber>();
}