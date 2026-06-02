using Microsoft.AspNetCore.Mvc;
using YoutubersApi.Models;
using YoutubersApi.Services;
using YoutubersApi.DTOs;


namespace YoutubersApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class YoutuberController : ControllerBase
{
    private readonly IYoutuberService _service;

    public YoutuberController(IYoutuberService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Youtuber>>> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Youtuber>> GetById(int id)
    {
        var youtuber = await _service.GetByIdAsync(id);
        return youtuber is null ? NotFound() : Ok(youtuber);
    }

    [HttpPost]
    public async Task<ActionResult<YoutuberDto>> Add(YoutuberDto youtuberDto)
    {
        try
        {
            var youtuber = new Youtuber
            {
                Name = youtuberDto.Name,
                ChannelName = youtuberDto.ChannelName,
                Subscribers = youtuberDto.Subscribers,
                Category = youtuberDto.Category
            };

            var created = await _service.AddAsync(youtuber);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
}
    }

    [HttpPut("{id}")]
public async Task<ActionResult<Youtuber>> Update(int id, Youtuber youtuber)
{
    try
    {
        var updated = await _service.UpdateAsync(id, youtuber);
        return updated is null ? NotFound() : Ok(updated);
    }
    catch (ArgumentException ex)
    {
        return BadRequest(ex.Message);
    }
}

[HttpDelete("{id}")]
public async Task<ActionResult> Delete(int id)
{
    var deleted = await _service.DeleteAsync(id);
    return deleted ? NoContent() : NotFound();
}
}