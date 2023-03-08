namespace webapi.Services;

public interface IFileService<T> where T : class
{
    Task<IEnumerable<T>> GetAsync();
    Task UpdateAsync(IEnumerable<T> items);
}