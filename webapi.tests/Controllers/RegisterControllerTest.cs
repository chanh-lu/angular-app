using Moq;
using webapi.Controllers;
using webapi.Models;
using webapi.Services;

namespace webapi.tests.Controllers;

public class RegisterControllerTest
{
    private static readonly Mock<IFileService<UserModel>> MockFileService = new();

    private readonly RegisterController _subject = new(MockFileService.Object);

    [Fact]
    public async Task Post_Should_Append_User()
    {
        await _subject.Post(It.IsAny<UserModel>());

        MockFileService.Verify(
            x => x.AppendAsync(It.IsAny<UserModel>()),
            Times.Once
        );
    }
}