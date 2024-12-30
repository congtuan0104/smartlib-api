using AutoMapper;
using SmartLibApi.Models.Entity;
using SmartLibApi.Models.Request;
using SmartLibApi.Models.Response;
using SmartLibApi.Repository.Interface;
using SmartLibApi.Services.Interface;

namespace SmartLibApi.Services.Implement;

public sealed class AuthorService : IAuthorService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogger<AuthorService> _logger;
    private readonly IMapper _mapper;

    public AuthorService(IRepositoryManager repository, ILogger<AuthorService> logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<Author>> GetAllAuthors()
    {
        return await _repository.Author.GetAllAuthorsAsync();
    }
    
    public async Task<Author> FindAuthorById(Guid id)
    {
        return await _repository.Author.FindAuthorById(id);
    }

    public async Task<AuthorDTO> CreateAuthor(AuthorReq.NewAuthor author)
    {
        var authorEntity = _mapper.Map<Author>(author);

        _repository.Author.AddAuthor(authorEntity);
        await _repository.SaveAsync();

        var authorToReturn = _mapper.Map<AuthorDTO>(authorEntity);
        return authorToReturn;
    }

}