namespace Entities.Dto;

public class UpdateMovieDto
{
    public string Title { get; set; }
    public string? Director { get; set; }
    public string? Genre { get; set; }
    public float? Duration { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public DateTime? ReleaseYear { get; set; }
}