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
        var users = (await _userFileService.GetAsync()).ToList();

        users.Add(new UserModel
        {
            FirstName = userModel.FirstName,
            LastName = userModel.LastName
        });

        await _userFileService.UpdateAsync(users);

        return Ok();
    }
}