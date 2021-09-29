using System;
using Microsoft.EntityFrameworkCore;
using ProductServer.Models;

namespace ProductServer.Repositories
{
  public interface IUnitOfWork
  {
    ProductRepository ProductRepository { get; }
    UserRepository UserRepository { get; }
    AuthRepository AuthRepository { get; }
    CategoryRepository CategoryRepository { get; }
    GenericRepository<Supplier> SupplierRepository { get; }

    void Save();
  }

  public class UnitOfWork : IUnitOfWork
  {
    public UnitOfWork(ProductContext context)
    {
      this.context = context;
      ProductRepository = new ProductRepository(context);
      UserRepository = new UserRepository(context);
      AuthRepository = new AuthRepository(context);
      CategoryRepository = new CategoryRepository(context);
      SupplierRepository = new GenericRepository<Supplier>(context);
    }

    public void Save()
    {
      context.SaveChanges();
    }

    public ProductRepository ProductRepository { get; }

    public UserRepository UserRepository { get; }

    public AuthRepository AuthRepository { get; }
    public CategoryRepository CategoryRepository { get; }
    public GenericRepository<Supplier> SupplierRepository { get; }

    private ProductContext context;
  }

}
