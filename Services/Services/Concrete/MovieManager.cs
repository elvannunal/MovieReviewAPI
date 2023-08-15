using System.Linq.Expressions;
using AutoMapper;
using Entities.Dto;
using Entities.Model;
using Repositories.Abstract;
using Services.Abstract;

namespace Services.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IRepositoryBase<Movie> _movieRepository;
        private readonly IMapper _mapper;

        public MovieManager(IRepositoryBase<Movie> movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

     
        public IQueryable<MovieDto> GetAllMovies()
        {
            var allMovies = _movieRepository.GetAll();
            var movieDtos = _mapper.ProjectTo<MovieDto>(allMovies);

            return movieDtos;
        }
        public MovieDto GetByCondition(Expression<Func<Movie, bool>> expression)
        {
            var movie = _movieRepository.GetByCondition(expression);
            var movieDto = _mapper.Map<MovieDto>(movie);
            return movieDto;        
        }

        public void AddMovie(AddMovieDto addMovieDto)
        {
            var newMovie = _mapper.Map<Movie>(addMovieDto);
            _movieRepository.Add(newMovie);
        }
        public void UpdateMovie(Guid id, UpdateMovieDto updateMovieDto)
        {
            var existingMovie = _movieRepository.GetByCondition(x => x.id == id);
            if (existingMovie != null)
            {
                _mapper.Map(updateMovieDto, existingMovie);
                _movieRepository.Update(id, existingMovie);
            }
        }
        public void DeleteMovie(Guid id)
        {
            _movieRepository.Delete(id);
        }
    }
}