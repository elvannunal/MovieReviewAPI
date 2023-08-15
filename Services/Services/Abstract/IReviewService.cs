using System.Linq.Expressions;
using Entities.Dto;
using Entities.Model;

namespace Services.Abstract;

public interface IReviewService 
{
     IQueryable<ReviewDto> GetAllReviews();
    ReviewDto GetByCondition(Expression<Func<Review, bool>> expression);
    void AddReview(AddReviewDto addReviewDto);
    void UpdateReview(Guid id,UpdateReviewDto updateReviewDto);
    void DeleteReview(Guid id);


}