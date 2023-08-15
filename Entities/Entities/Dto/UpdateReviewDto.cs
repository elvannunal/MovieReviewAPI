namespace Entities.Dto;

public class UpdateReviewDto
{
        public string Content { get; set; }
        public decimal? Rating { get; set; }
        public Guid? MovieId { get; set; } 
}