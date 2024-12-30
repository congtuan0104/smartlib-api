namespace SmartLibApi.Models.Response;

public record AuthorDTO(Guid Id, string? Name,string? Avatar, short YearOfBirth, short? YearOfDeath);