using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartLibApi.Models.Entity;

public class Book
{
    [Column("BookId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Title is required field")]
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public string? Language { get; set; }
    
    public short? YearOfPublication { get; set; }
    
    [ForeignKey(nameof(Author))]
    public Guid AuthorId { get; set; }
    public Author? Author { get; set; }
}