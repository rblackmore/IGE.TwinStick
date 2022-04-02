namespace IGE.Common;

using IGE.Common.Interfaces;

using Microsoft.Xna.Framework;

public abstract class GameEntity : IGameEntity
{
  public bool Enabled { get; protected set; } = true;

  public virtual void Initialize() { }

  public virtual void LoadContent() { }

  public virtual void UnloadContent() { }

  public virtual void Update(GameTime gameTime) { }
}
