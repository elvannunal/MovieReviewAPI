using Entities.Model;
using Repositories.Abstract;

namespace Repositories.Concrete;

public class ReviewRepository: RepositoryBase<Review>, IReviewRepository
{
    public ReviewRepository(RepositoryContext context) : base(context)
    {
    }
}