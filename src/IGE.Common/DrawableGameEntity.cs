namespace IGE.Common;

using IGE.Common.Interfaces;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class DrawableGameEntity : GameEntity, IDrawableGameEntity
{
  public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
}
