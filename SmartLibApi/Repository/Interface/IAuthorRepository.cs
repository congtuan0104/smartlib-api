using SmartLibApi.Models.Entity;

namespace SmartLibApi.Repository.Interface;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAuthorsAsync();
    Task<Author?> FindAuthorById(Guid authorId);
    void AddAuthor(Author author);
}