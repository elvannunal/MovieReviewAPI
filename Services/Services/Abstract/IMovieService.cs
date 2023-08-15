using System.Linq.Expressions;
using Entities.Dto;
using Entities.Model;

namespace Services.Abstract;

public interface IMovieService
{
  
    IQueryable<MovieDto> GetAllMovies();
    MovieDto GetByCondition(Expression<Func<Movie, bool>> expression);
    
    void AddMovie(AddMovieDto addMovieDto);

    void UpdateMovie(Guid id,UpdateMovieDto updateMovieDto);

    void DeleteMovie(Guid id);
}