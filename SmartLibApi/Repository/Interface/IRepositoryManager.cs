namespace SmartLibApi.Repository.Interface;

public interface IRepositoryManager
{
    IAuthorRepository Author { get; }

    Task SaveAsync();
}