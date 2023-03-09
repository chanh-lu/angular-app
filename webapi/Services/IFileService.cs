namespace webapi.Services;

public interface IFileService<T> where T : class
{
    Task<IEnumerable<T>> ReadAsync();
    Task AppendAsync(T item);
}