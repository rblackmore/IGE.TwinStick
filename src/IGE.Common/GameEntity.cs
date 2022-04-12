namespace IGE.Common;

using IGE.Common.Interfaces;
using IGE.Common.Services;

using Microsoft.Xna.Framework;

public abstract class GameEntity : IGameEntity
{
  private readonly Game game;

  protected GameEntity()
  {
    this.game = ServiceLocator.GetService<Game>();
  }

  protected Game Game => game;

  public bool Enabled { get; protected set; } = true;

  public virtual void Initialize() { }

  public virtual void LoadContent() { }

  public virtual void UnloadContent() { }

  public virtual void Update(GameTime gameTime) { }
}
