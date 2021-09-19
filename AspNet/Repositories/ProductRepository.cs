using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductServer.Models;

namespace ProductServer.Repositories
{
  public class ProductRepository<TEntity> where TEntity : class
  {
    public ProductRepository(ProductContext context)
    {
      this.context = context;
      Entities = context.Set<TEntity>();
    }

    public void Create(TEntity entity)
    {
      Entities.Add(entity);
    }

    public void Update(TEntity entity)
    {
      Entities.Update(entity);
    }

    public void Delete(object id)
    {
      TEntity found = Entities.Find(id);
      if (found is not null) Entities.Remove(found);
    }

    public List<TEntity> Find(Func<TEntity, bool> filter, int size, int offset)
    {
      var products = Entities.Where(filter).Skip(offset * size).Take(size).ToList();
      return products;
    }

    public void Save()
    {
      context.SaveChanges();
    }

    private ProductContext context;
    public readonly DbSet<TEntity> Entities;
  }

}
