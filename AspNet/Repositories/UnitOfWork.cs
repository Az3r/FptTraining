using System;
using ProductServer.Models;

namespace ProductServer.Repositories
{
  public class UnitOfWork : IDisposable
  {
    public UnitOfWork(ProductContext product)
    {
      productContext = product;
      ProductRepository = new ProductRepository(product);
    }

    public void Dispose()
    {
      productContext.Dispose();
    }

    public void Save()
    {
      productContext.SaveChanges();
    }

    public readonly ProductRepository ProductRepository;

    private readonly ProductContext productContext;
  }

}
