using System.ComponentModel.DataAnnotations;

namespace SmartLibApi.Models.Request;

public class AuthorReq
{
    public record NewAuthor
    {
        [Required(ErrorMessage = "Tên tác giả là bắt buộc")]
        [MaxLength(60, ErrorMessage = "Tên tác giả không vượt quá 60 ký tự")]
        public string? Name { get; init; }
    
        public string? Avatar { get; init; }
    
        public short? YearOfBirth { get; init; }
    
        public short? YearOfDeath { get; init; }
    }
}