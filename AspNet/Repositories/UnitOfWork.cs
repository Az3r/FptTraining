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
      ProductRepository = new ProductRepository(context);
      UserRepository = new GenericRepository<User>(context);
      AuthRepository = new GenericRepository<Auth>(context);
    }

    public void Save()
    {
      context.SaveChanges();
    }

    public ProductRepository ProductRepository { get; }

    public GenericRepository<User> UserRepository { get; }

    public GenericRepository<Auth> AuthRepository { get; }

    private ProductContext context;
  }
  public interface IUnitOfWork
  {
    void Save();

    ProductRepository ProductRepository { get; }
    GenericRepository<User> UserRepository { get; }
    GenericRepository<Auth> AuthRepository { get; }
  }

}
