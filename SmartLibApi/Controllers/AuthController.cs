using Microsoft.AspNetCore.Mvc;
using SmartLibApi.Models.Request;
using SmartLibApi.Models.Response;
using SmartLibApi.Services.Interface;

namespace SmartLibApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    // [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Register([FromBody] AuthReq.RegisterUserDto registerUserDto)
    {
        BaseResponse respone = new BaseResponse();
        var result = await _authService.RegisterUser(registerUserDto);

        if (result.Succeeded)
        {
            respone.Message = "Đăng ký tài khoản thành công";
            return Ok(respone);
        }

        respone.Message = "Đăng ký tài khoản không thành công";
        respone.Errors = result.Errors;
        return BadRequest(respone);
    }
}