using System.ComponentModel.DataAnnotations.Schema;
using Entities.Model;

namespace Entities.Dto;

public class AddReviewDto
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public decimal? Rating { get; set; }
    public Guid? MovieId { get; set; } 
   
}