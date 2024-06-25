using CompositeWeb.data;
using CompositeWeb.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace CompositeWeb;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public Task<OkObjectResult> GetUsers()
    {
        var users = _context.Users.ToList();

        return Task.FromResult(Ok(users));
    }

    [HttpPost]
    public async Task PostUser(User request)
    {
        await _context.Users.AddAsync(request);
        await _context.SaveChangesAsync();
    }
}