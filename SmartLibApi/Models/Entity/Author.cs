using System.ComponentModel.DataAnnotations.Schema;

namespace SmartLibApi.Models.Entity;

public class Author
{
    [Column("AuthorId")]
    public Guid Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Avatar { get; set; }
    
    public string? Country { get; set; }
    
    public short? YearOfBirth { get; set; }
    
    public short? YearOfDeath { get; set; }
    
    public ICollection<Book>? Books { get; set; } 
}