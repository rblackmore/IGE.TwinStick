namespace IGE.Common;

using IGE.Common.Interfaces;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class DrawableGameEntity : GameEntity, IDrawableGameEntity
{
  private readonly GraphicsDeviceManager graphics;

  protected DrawableGameEntity(Game game, GraphicsDeviceManager graphics!!) 
    : base(game)
  {
    this.graphics = graphics;
  }

  protected GraphicsDeviceManager GraphicsDeviceManager => graphics;

  public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
}
