using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ProductServer.Models;

namespace ProductServer.Repositories
{
  public class UserRepository : GenericRepository<User>
  {
    public UserRepository(ProductContext context) : base(context) { }

    public User Verify(string name, string hashedPassword)
    {
      User user = Entities.SingleOrDefault(u => u.DisplayName.Equals(name) && u.HashedPassword.Equals(hashedPassword, StringComparison.Ordinal));
      return user;
    }
  }
}