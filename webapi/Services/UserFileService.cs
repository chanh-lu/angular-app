using Newtonsoft.Json;
using webapi.Models;

namespace webapi.Services;

public sealed class UserFileService : IFileService<UserModel>
{
    private const string File = ".\\App_Data\\users.json";

    private readonly IStreamReaderService _streamReaderService;
    private readonly IStreamWriterService _streamWriterService;

    public UserFileService(
        IStreamReaderService streamReaderService,
        IStreamWriterService streamWriterService
    )
    {
        _streamReaderService = streamReaderService;
        _streamWriterService = streamWriterService;
    }

    public async Task<IEnumerable<UserModel>> GetAsync()
    {
        var jsonString = await _streamReaderService.ReadToEndAsync(File);
        var users = JsonConvert.DeserializeObject<List<UserModel>>(jsonString);

        return users != null
            ? users
            : Array.Empty<UserModel>();
    }

    public async Task UpdateAsync(IEnumerable<UserModel> users)
    {
        var jsonString = JsonConvert.SerializeObject(users);
        await _streamWriterService.WriteLineAsync(File, jsonString);
    }
}