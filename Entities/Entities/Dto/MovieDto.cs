using Entities.Model;

namespace Entities.Dto;

public class MovieDto
{
    public Guid id { get; set; }
    public string Title { get; set; }
    public string? Director { get; set; }
    public string? Genre { get; set; }
    public float? Duration { get; set; }
    public string Description { get; set; }
    public string? Image { get; set; }

    public DateTime? ReleaseYear { get; set; }
    public ICollection<Review>? Reviews { get; set; }

}