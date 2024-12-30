using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SmartLibApi.Repository.Interface;

namespace SmartLibApi.Repository.Implement;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    protected RepositoryContext RepositoryContext;
    private readonly DbSet<TEntity> _dbSet;

    protected RepositoryBase(RepositoryContext repositoryContext)
    {
        this.RepositoryContext = repositoryContext;
        this._dbSet = repositoryContext.Set<TEntity>();
    }

    public IQueryable<TEntity> GetAll(bool trackChange = false) => trackChange ? _dbSet : _dbSet.AsNoTracking();
    
    // public IQueryable<TEntity> FindById<T>(T Id, bool trackChange = false) => trackChange ? _dbSet.F : _dbSet.AsNoTracking();
    
    public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = false) =>
        !trackChanges
            ? _dbSet.Where(expression).AsNoTracking()
            : _dbSet.Where(expression);

    public void Create(TEntity entity) => _dbSet.Add(entity);

    public void Update(TEntity entity) => _dbSet.Update(entity);

    public void Delete(TEntity entity) => _dbSet.Remove(entity);
}