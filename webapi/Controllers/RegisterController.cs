using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegisterController : ControllerBase
{
    private readonly IFileService<UserModel> _userFileService;

    public RegisterController(IFileService<UserModel> userFileService)
    {
        _userFileService = userFileService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserModel userModel)
    {      
        await _userFileService.AppendAsync(userModel);
        return Ok();
    }
}