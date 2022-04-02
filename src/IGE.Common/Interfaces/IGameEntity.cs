namespace IGE.Common.Interfaces;

using Microsoft.Xna.Framework;

public interface IGameEntity
{
  bool Enabled { get; }

  void Initialize();

  void LoadContent();

  void UnloadContent();
  
  void Update(GameTime gameTime);
}
