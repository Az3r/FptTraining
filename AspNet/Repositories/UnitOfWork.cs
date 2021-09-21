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
      UserRepository = new UserRepository(context);
      AuthRepository = new AuthRepository(context);
    }

    public void Save()
    {
      context.SaveChanges();
    }

    public ProductRepository ProductRepository { get; }

    public UserRepository UserRepository { get; }

    public AuthRepository AuthRepository { get; }

    private ProductContext context;
  }
  public interface IUnitOfWork
  {
    void Save();

    ProductRepository ProductRepository { get; }
    UserRepository UserRepository { get; }
    AuthRepository AuthRepository { get; }
  }

}
