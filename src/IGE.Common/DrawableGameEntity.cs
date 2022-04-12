namespace IGE.Common;

using IGE.Common.Interfaces;
using IGE.Common.Services;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class DrawableGameEntity : GameEntity, IDrawableGameEntity
{
  private readonly GraphicsDeviceManager graphics;

  protected DrawableGameEntity() 
  {
    this.graphics = ServiceLocator.GetService<GraphicsDeviceManager>();
  }

  protected GraphicsDeviceManager GraphicsDeviceManager => graphics;

  public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
}
