using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartLibApi.Models.Entity;
using SmartLibApi.Models.Request;
using SmartLibApi.Services.Interface;

namespace SmartLibApi.Services.Implement;

public class AuthService : IAuthService
{
    private readonly ILogger<IAuthService> _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthService(ILogger<AuthService> logger, UserManager<User> userManager, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegisterUser(AuthReq.RegisterUserDto registerUserDto)
    {
        var user = _mapper.Map<User>(registerUserDto);
        var result = await _userManager.CreateAsync(user, registerUserDto.Password);
        if (result.Succeeded)
        {
            var allRoles = await _roleManager.Roles.ToListAsync();
            var userRoles = new List<string>();
            foreach (var role in registerUserDto.Roles!)
            {
                var roleExists = allRoles.Exists(r => r.Name.Equals(role));
                if (roleExists) userRoles.Add(role);
            }

            if (userRoles.Count > 0)
                await _userManager.AddToRolesAsync(user, userRoles);
        }

        return result;
    }
}