namespace IGE.Common;

using IGE.Common.Interfaces;

using Microsoft.Xna.Framework;

public abstract class GameEntity : IGameEntity
{
  private readonly Game game;

  protected GameEntity(Game game!!)
  {
    this.game = game;
  }

  protected Game Game => game;

  public bool Enabled { get; protected set; } = true;

  public virtual void Initialize() { }

  public virtual void LoadContent() { }

  public virtual void UnloadContent() { }

  public virtual void Update(GameTime gameTime) { }
}
