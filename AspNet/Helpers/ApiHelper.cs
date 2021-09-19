namespace ProductServer.Helpers
{

  public static class ApiHelper
  {
    public static object Success<T>(T value) where T : class
    {
      return new
      {
        Result = value
      };
    }
    public static object Failure(string code, string message, object details = null)
    {
      return new
      {
        Error = new
        {
          Code = code,
          Message = message,
          Details = details
        }
      };
    }
  }
}