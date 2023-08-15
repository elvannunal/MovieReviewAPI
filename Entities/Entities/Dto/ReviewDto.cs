using System.ComponentModel.DataAnnotations.Schema;
using Entities.Model;

namespace Entities.Dto;

public class ReviewDto
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public decimal? Rating { get; set; }
    [ForeignKey("MovieId")] 
    public Guid? MovieId { get; set; } 
    public Movie? Movie { get; set; }
 
}