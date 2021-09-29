using System;
using System.Collections.Generic;
using System.Linq;
using ProductServer.Models;

namespace ProductServer.Repositories
{
  public class CategoryRepository : GenericRepository<Category>
  {
    public CategoryRepository(ProductContext context) : base(context) { }

    public IEnumerable<Category> FindAndTrack(IEnumerable<Guid> ids)
    {
      return Entities.Where(c => ids.Contains(c.ID));
    }
  }
}