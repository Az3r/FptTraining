namespace ProductServer.Helpers
{

  public class ApiError
  {
    public string Code { get; set; }
    public string Message { get; set; }

    public object Details { get; set; }
  }

  public static class ApiHelper
  {
    public static object Success<T>(T value) where T : class
    {
      return new
      {
        Result = value
      };
    }
    public static object Failure<T>(T value) where T : class
    {
      return new
      {
        Error = value
      };
    }
  }
}