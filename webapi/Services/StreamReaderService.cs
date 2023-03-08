namespace webapi.Services;

public interface IStreamReaderService
{
    Task<string> ReadToEndAsync(string file);
}

public sealed class StreamReaderService : IStreamReaderService
{
    public async Task<string> ReadToEndAsync(string file)
    {
        using var r = new StreamReader(file);
        return await r.ReadToEndAsync();
    }
}