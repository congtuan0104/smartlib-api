using Microsoft.EntityFrameworkCore;
using SmartLibApi.Models.Entity;
using SmartLibApi.Repository.Interface;

namespace SmartLibApi.Repository.Implement;

public class AuthorRepository: RepositoryBase<Author>, IAuthorRepository
{
    public AuthorRepository(RepositoryContext repositoryContext): base(repositoryContext) { }

    public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
    {
        return await GetAll().ToListAsync();
    }

    public async Task<Author?> FindAuthorById(Guid authorId)
    {
        return await GetAll().SingleOrDefaultAsync(a=> a.Id.Equals(authorId));
        // return await FindByCondition(a => a.Id.Equals(authorId)).SingleOrDefaultAsync();
    }
    
    public void AddAuthor(Author author)
    {
        Create(author);
    }
}