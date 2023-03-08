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
    public async Task Post_Should_Update_File_With_Users()
    {
        MockFileService
            .Setup(x => x.GetAsync())
            .Returns(Task.FromResult<IEnumerable<UserModel>>(Array.Empty<UserModel>()));

        await _subject.Post(new UserModel());

        MockFileService.Verify(
            x => x.GetAsync(),
            Times.Once
        );

        MockFileService.Verify(
            x => x.UpdateAsync(It.IsAny<IEnumerable<UserModel>>()),
            Times.Once
        );
    }
}