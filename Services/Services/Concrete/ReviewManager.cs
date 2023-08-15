using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Entities.Dto;
using Entities.Model;
using Repositories.Abstract;
using Services.Abstract;

namespace Services.Concrete
{
    public class ReviewManager : IReviewService
    {
        private readonly IRepositoryBase<Review> _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewManager(IRepositoryBase<Review> reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public IQueryable<ReviewDto> GetAllReviews()
        {
            var allReviews = _reviewRepository.GetAll();
            var reviewDtos = _mapper.ProjectTo<ReviewDto>(allReviews);
            return reviewDtos;
        }

        public ReviewDto GetByCondition(Expression<Func<Review, bool>> expression)
        {
            var review = _reviewRepository.GetByCondition(expression);
            var reviewDto = _mapper.Map<ReviewDto>(review);
            return reviewDto;
        }
     
        public void AddReview(AddReviewDto addReviewDto)
        {
           
            if ( addReviewDto.MovieId != null)
            {
                var newReview = _mapper.Map<Review>(addReviewDto);  
                newReview.MovieId = addReviewDto.MovieId;
                _reviewRepository.Add(newReview);
            }
        }

        public void UpdateReview(Guid id, UpdateReviewDto updateReviewDto)
        {
            var existingReview = _reviewRepository.GetByCondition(x => x.Id == id);
            if (existingReview != null && updateReviewDto.MovieId != null )
            {
                _mapper.Map(updateReviewDto, existingReview);
                _reviewRepository.Update(id,existingReview);
            }
        }
        public void DeleteReview(Guid id)
        {
            _reviewRepository.Delete(id);
        }
    }
}