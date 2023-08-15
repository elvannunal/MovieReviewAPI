using System.Linq.Expressions;
using Repositories.Abstract;

namespace Repositories.Concrete;

public class RepositoryBase<T> : IRepositoryBase<T> where T:class
{
    protected readonly RepositoryContext _context;

    public RepositoryBase(RepositoryContext context)
    {
        _context = context;
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }
    public T GetByCondition(Expression<Func<T, bool>> expression)
    { 
        return _context.Set<T>().FirstOrDefault(expression) ?? throw new Exception("Entity not found!");
    }
    
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(Guid id,T entity)
    {
        var existingEntity = _context.Set<T>().Find(id);
        if (existingEntity != null)
        {
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }

    public void Delete(Guid id)
    {
        var entityToDelete = _context.Set<T>().Find(id);
        if (entityToDelete != null)
        {
            _context.Set<T>().Remove(entityToDelete);
            _context.SaveChanges();
        }
    }
}