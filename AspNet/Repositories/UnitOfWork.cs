using System;
using Microsoft.EntityFrameworkCore;
using ProductServer.Models;

namespace ProductServer.Repositories
{
  public class UnitOfWork
  {
    public UnitOfWork(ProductContext context)
    {
      this.context = context;
      ProductRepository = new ProductRepository<Product>(context);
    }

    public void Save()
    {
      context.SaveChanges();
    }

    public readonly ProductRepository<Product> ProductRepository;

    private readonly ProductContext context;
  }

}
