using System;
using Microsoft.EntityFrameworkCore;
using ProductServer.Models;

namespace ProductServer.Repositories
{

  public class UnitOfWork : IUnitOfWork
  {
    public UnitOfWork(ProductContext context)
    {
      this.context = context;
      ProductRepository = new ProductRepository<Product>(context);
      UserRepository = new ProductRepository<User>(context);
      AuthRepository = new ProductRepository<Auth>(context);
    }

    public void Save()
    {
      context.SaveChanges();
    }

    public ProductRepository<Product> ProductRepository { get; }

    public ProductRepository<User> UserRepository { get; }

    public ProductRepository<Auth> AuthRepository { get; }

    private ProductContext context;
  }
  public interface IUnitOfWork
  {
    void Save();

    ProductRepository<Product> ProductRepository { get; }
    ProductRepository<User> UserRepository { get; }
    ProductRepository<Auth> AuthRepository { get; }
  }

}
