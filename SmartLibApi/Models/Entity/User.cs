using Microsoft.AspNetCore.Identity;

namespace SmartLibApi.Models.Entity;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
}