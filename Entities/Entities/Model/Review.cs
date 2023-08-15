using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model;

public class Review: BaseEntity
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public decimal? Rating { get; set; }

    [ForeignKey("MovieId")] // Specify the foreign key property name
    public Guid? MovieId { get; set; } 
    public Movie? Movie { get; set; }
}