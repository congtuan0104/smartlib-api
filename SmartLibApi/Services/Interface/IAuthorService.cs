using SmartLibApi.Models.Entity;
using SmartLibApi.Models.Request;
using SmartLibApi.Models.Response;

namespace SmartLibApi.Services.Interface;

public interface IAuthorService
{
    Task<IEnumerable<Author>> GetAllAuthors();

    Task<AuthorDTO> CreateAuthor(AuthorReq.NewAuthor author);
}