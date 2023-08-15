using Entities.Model;
using Repositories.Abstract;

namespace Repositories.Concrete;

public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
{
    public MovieRepository(RepositoryContext context) : base(context)
    {
    }
}