using Moq;
using Newtonsoft.Json;
using webapi.Models;
using webapi.Services;

namespace webapi.tests.Services;

public class UserFileServiceTest
{
    private static readonly Mock<IStreamReaderService> MockStreamReaderService = new();
    private static readonly Mock<IStreamWriterService> MockStreamWriterService = new();

    private readonly UserFileService _subject = new(
        MockStreamReaderService.Object,
        MockStreamWriterService.Object
    );

    [Fact]
    public async Task GetAsync_Should_Returns_Users()
    {
        var expected = new[]
        {
            new UserModel
            {
                FirstName = "firstname",
                LastName = "lastName"
            }
        };

        MockStreamReaderService
            .Setup(x => x.ReadToEndAsync(It.IsAny<string>()))
            .Returns(Task.FromResult(JsonConvert.SerializeObject(expected)));

        var result = await _subject.GetAsync();

        Assert.Equivalent(expected, result);
    }

    [Fact]
    public async Task UpdateAsync_Should_Write_To_File()
    {
        await _subject.UpdateAsync(It.IsAny<IEnumerable<UserModel>>());

        MockStreamWriterService.Verify(
            x => x.WriteLineAsync(It.IsAny<string>(), It.IsAny<string>()),
            Times.Once
        );
    }
}