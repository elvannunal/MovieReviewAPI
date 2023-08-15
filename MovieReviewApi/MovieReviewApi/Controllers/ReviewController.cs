using AutoMapper;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace MovieReviewApi.Controllers;
[ApiController]
[Route("api/Review")]
public class ReviewController : Controller
{
    private readonly IReviewService _reviewService;
    private readonly IMovieService _movieService;
    private readonly IMapper _mapper;

    public ReviewController(IReviewService reviewService, IMapper mapper, IMovieService movieService)
    {
        _reviewService = reviewService;
        _mapper = mapper;
        _movieService = movieService;
    }

    [HttpGet]
    public IActionResult GetAllReview()
    {
        var allReviews = _reviewService.GetAllReviews();
        return Ok(allReviews);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var getById = _reviewService.GetByCondition(x => x.Id == id);
        if (getById != null)
            return Ok(getById);
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(Guid id)
    {
        var deleteById= _reviewService.GetByCondition(x => x.Id == id);

        if (deleteById != null)
        {
            _reviewService.DeleteReview(id);
            return NoContent();
        }

        return BadRequest();
    }

    [HttpPost]
    public IActionResult AddReview([FromBody]AddReviewDto addReviewDto)
    {
        var movie = _movieService.GetByCondition(x => x.id == addReviewDto.MovieId);
        if (movie != null)
        {
            addReviewDto.MovieId = movie.id;
            addReviewDto.Id=Guid.NewGuid();
            var addReview = _mapper.Map<AddReviewDto>(addReviewDto);
            _reviewService.AddReview(addReview);
            return Ok(addReview);
        }

        return BadRequest();
        
    }

    [HttpPut]
    public IActionResult UpdateReview(Guid id, [FromBody] UpdateReviewDto updateReviewDto)
    {
        var existId = _reviewService.GetByCondition(x => x.Id == id);
        var movieid = _movieService.GetByCondition(x => x.id == updateReviewDto.MovieId);

        if (existId != null && movieid!= null)
        {
            var updateReview = _mapper.Map<UpdateReviewDto>(updateReviewDto);
            _reviewService.UpdateReview(id,updateReview);
            return Ok(updateReview);
        }

        return BadRequest();
    }
} 