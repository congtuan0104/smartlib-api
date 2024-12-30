using Microsoft.AspNetCore.Mvc;
using SmartLibApi.Models.Request;
using SmartLibApi.Models.Response;
using SmartLibApi.Services.Interface;

namespace SmartLibApi.Controllers;

[Route("api/author")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAuthors()
    {
        BaseResponse response = new BaseResponse();
        var authors = await _authorService.GetAllAuthors();
        if (authors.Any())
        {
            response.Data = authors;
            return Ok(response);
        }

        return NotFound("Không tìm thấy tác giả nào");
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewAuthors([FromBody] AuthorReq.NewAuthor author)
    {
        BaseResponse response = new BaseResponse();
        
        var newAuthor = await _authorService.CreateAuthor(author);

        response.Data = newAuthor;
        response.Message = "Thêm tác giả thành công";

        return Ok(response);
    }
}