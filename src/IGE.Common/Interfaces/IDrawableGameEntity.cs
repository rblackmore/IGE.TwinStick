namespace IGE.Common.Interfaces;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface IDrawableGameEntity : IGameEntity
{
  void Draw(GameTime gameTime, SpriteBatch spriteBatch);
}
