namespace webapi.Services;

public interface IStreamWriterService
{
    Task WriteLineAsync(string file, string content);
}

public sealed class StreamWriterService : IStreamWriterService
{
    public async Task WriteLineAsync(string file, string content)
    {
        await using var sw = new StreamWriter(file);
        await sw.WriteLineAsync(content);
    }
}