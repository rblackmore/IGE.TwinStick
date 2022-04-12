namespace IGE.Common.Services;

using Lamar;

public class GameServiceRegistry : ServiceRegistry
{
  public GameServiceRegistry()
  {
    For<Camera>().Use<Camera>();
  } 
}
