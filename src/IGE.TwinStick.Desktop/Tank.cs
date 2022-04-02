namespace IGE.TwinStick.Desktop;

using IGE.Common.Graphics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class Tank : Sprite2D
{
  private float rotationSpeedDegrees = 45.0f;
  private float acceleration = 5.0f;
  
  public Tank(Game game, GraphicsDeviceManager graphics) 
    : base(game, graphics, "BlueTankTransparent")
  {
  }

  public override void Initialize()
  {
    base.Initialize();
  }

  public override void Update(GameTime gameTime)
  {
    base.Update(gameTime);

    var keyboardState = Keyboard.GetState();

    if (keyboardState.IsKeyDown(Keys.Left))
      this.rotation -= MathHelper.ToRadians(rotationSpeedDegrees * (float)gameTime.ElapsedGameTime.TotalSeconds);
    else if (keyboardState.IsKeyDown(Keys.Right))
      this.rotation += MathHelper.ToRadians(rotationSpeedDegrees * (float)gameTime.ElapsedGameTime.TotalSeconds);

    if (keyboardState.IsKeyDown(Keys.Up))
      this.velocity = this.Velocity.IncreaseSpeed((float)gameTime.ElapsedGameTime.TotalSeconds * this.acceleration);
    else if (keyboardState.IsKeyDown(Keys.Down))
      this.velocity = this.Velocity.DecreaseSpeed((float)gameTime.ElapsedGameTime.TotalSeconds * this.acceleration);

    if (keyboardState.IsKeyDown(Keys.Space))
      this.velocity = this.velocity.Stop();
  }
}
