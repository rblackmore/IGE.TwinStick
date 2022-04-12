namespace IGE.Common.Services;

using Lamar;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceLocator
{
  private static GameServiceRegistry gameServiceRegistry;

  private static Container gameServiceContainer;

  //public static GameServiceRegistry? GameServiceRegistry => gameServiceRegistry
  //  ?? throw new InvalidOperationException("GameServiceRegistry is not initialized.");

  public static Container GameServiceContainer
  {
    get
    {
      if (gameServiceContainer == null)
        gameServiceContainer = new Container(gameServiceRegistry);

      return gameServiceContainer;
    }
  }

  public static void SetServiceRegistry(GameServiceRegistry registry)
  {
    gameServiceRegistry = registry;
  }

  public static void AddService<T>(T service) where T : class
  {
    gameServiceRegistry?.AddSingleton<T>(service);
  }

  public static T GetService<T>()
  {
    return GameServiceContainer.GetInstance<T>();
  }
}
