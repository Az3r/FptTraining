using Microsoft.EntityFrameworkCore;

namespace ProductServer.Repositories
{
  public interface IProductRepository<TEntity> where TEntity : class
  {
    void Create(TEntity entity);
    void Delete(object id);
    void Update(TEntity entity);
    void Save();
    DbSet<TEntity> Entities { get; }
  }
}