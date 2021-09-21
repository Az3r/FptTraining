using System;
using System.Linq;
using ProductServer.Models;

namespace ProductServer.Repositories
{
  public class AuthRepository : GenericRepository<Auth>
  {
    public AuthRepository(ProductContext context) : base(context) { }

    public void Activate(Auth token)
    {
      token.ActivatedAt = DateTime.UtcNow;
      Update(token);
    }

    public Auth Find(string token)
    {
      var auth = Entities.SingleOrDefault(t => t.Token.Equals(token));
      return auth;
    }
  }
}