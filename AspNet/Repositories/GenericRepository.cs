using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductServer.Models;

namespace ProductServer.Repositories
{
  public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    public GenericRepository(ProductContext context)
    {
      this.context = context;
      Entities = context.Set<TEntity>();
    }

    public virtual void Create(TEntity entity)
    {
      Entities.Add(entity);
    }

    public virtual void Update(TEntity entity)
    {
      Entities.Update(entity);
    }

    public virtual void Delete(object id)
    {
      TEntity found = Entities.Find(id);
      if (found is not null) Entities.Remove(found);
    }

    public void Save()
    {
      context.SaveChanges();
    }

    protected ProductContext context;
    public DbSet<TEntity> Entities { get; protected set; }
  }

}
