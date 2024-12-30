using Microsoft.AspNetCore.Identity;
using SmartLibApi.Models.Request;

namespace SmartLibApi.Services.Interface;

public interface IAuthService
{
    Task<IdentityResult> RegisterUser(AuthReq.RegisterUserDto registerUserDto);
}