using AutoMapper;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace MovieReviewApi.Controllers;
[ApiController]
[Route("api/Movie")]
public class MovieController : Controller
{
   private readonly IMovieService _movie;
   private readonly IMapper _mapper;
   public MovieController(IMovieService movie, IMapper mapper)
   {
      _movie = movie;
      _mapper = mapper;
   }

   [HttpGet]
   public IActionResult GetAllMovies()
   {
     var movies= _movie.GetAllMovies();
     return Ok(movies);
   }

   [HttpGet("{id}")]
   public IActionResult GetMovieById(Guid id)
   {
       var movie = _movie.GetByCondition(x => x.id == id);
       if (movie != null)
           return Ok(movie);
       return NotFound();
   }

   [HttpDelete("{id}")]
   public IActionResult DeleteById(Guid id)
   {
       var movie =_movie.GetByCondition(x => x.id == id);
       if (movie != null)
       {
           _movie.DeleteMovie(id);
           return NoContent();
       }

       return BadRequest();
   }

   [HttpPost]
   public IActionResult AddMovie([FromBody] AddMovieDto addMovieDto)
   {
       addMovieDto.id= Guid.NewGuid();
       var newMovie = _mapper.Map<AddMovieDto>(addMovieDto);
       _movie.AddMovie(newMovie);
       return Ok(newMovie);
   }
   
   [HttpPut("{id}")]
   public IActionResult UpdateMovie(Guid id, [FromBody] UpdateMovieDto updateMovieDto)
   {
       var existingMovie = _movie.GetByCondition(x => x.id == id);
       if (existingMovie != null)
       {
           var updatedMovie = _mapper.Map<UpdateMovieDto>(updateMovieDto);
           _movie.UpdateMovie(id, updatedMovie);
           return Ok(updatedMovie);
       }
       return BadRequest();
   }

   
}