using System.Linq.Expressions;

namespace SmartLibApi.Repository.Interface;

public interface IRepositoryBase<TEntity> where TEntity:class
{
    IQueryable<TEntity> GetAll(bool trackChanges);
    IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges);
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}