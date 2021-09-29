using System.Linq;
using ProductServer.Models;

namespace ProductServer.Repositories
{
  public class UserRepository : GenericRepository<User>
  {
    public UserRepository(ProductContext context) : base(context) { }

    public User Find(string name)
    {
      User user = Entities.SingleOrDefault(u => u.DisplayName.Equals(name));
      return user;
    }
  }
}