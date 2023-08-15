using System.Linq.Expressions;

namespace Repositories.Abstract;

public interface IRepositoryBase<T> 
{ 
    IQueryable<T> GetAll();
    T GetByCondition(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void Update(Guid id,T entity);
    void Delete(Guid id);
 
}