using BackendAPI.Data;
using BackendAPI.Models;
using BackendAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/users")]  // -> /api/users
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
private readonly IServiceProvider _services;

public UsersController(ApplicationDbContext dbContext, IServiceProvider services)
{
    _dbContext = dbContext;
    _services  = services;
}
        [HttpPost("register")]  // -> POST /api/users/register
        public async Task<IActionResult> Register(
            [FromForm] string username,
            [FromForm] string email,
            [FromForm] string password,
            [FromForm] IFormFile? image)
        {
            if (await _dbContext.Users.AnyAsync(u => u.Email == email))
                return BadRequest("User with this email already exists.");

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = password // TODO: hash in production
            };

            if (image is { Length: > 0 })
{
    // Construct only when really needed
    var blobService = _services.GetRequiredService<BlobStorageService>();

    var safeFileName = $"{Guid.NewGuid()}_{Path.GetFileName(image.FileName)}";
    await using var stream = image.OpenReadStream();
    var contentType = string.IsNullOrWhiteSpace(image.ContentType)
        ? "application/octet-stream"
        : image.ContentType;

    var imageUrl = await blobService.UploadFileAsync(stream, safeFileName, contentType);
    user.ImageUrl = imageUrl;
}

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpGet("{id:int}")]  // -> GET /api/users/123
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            return user is null ? NotFound() : Ok(user);
        }
    }
}
