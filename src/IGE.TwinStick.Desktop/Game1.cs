namespace IGE.TwinStick.Desktop;

using IGE.Common.Graphics;
using IGE.Common.Graphics.ValueObjects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Game1 : Game
{
  private Tank tank;

  private GraphicsDeviceManager graphics;
  private SpriteBatch spriteBatch = null!;

  public Game1()
    : base()
  {
    this.graphics = new GraphicsDeviceManager(this);

    this.Content.RootDirectory = "Content";
    this.IsFixedTimeStep = true;
    this.IsMouseVisible = true;
  }

  protected override void Initialize()
  {
    this.graphics.PreferredBackBufferWidth = 1920;
    this.graphics.PreferredBackBufferHeight = 1080;
    this.graphics.ApplyChanges();
    this.tank = new Tank(this, this.graphics)
    {
      Position = new Vector2(100, 100),
      Velocity = new Velocity2(new Vector2(10, 0), 0.0f),
      Scale = new Vector2(0.5f),
    };
    
    base.Initialize();
  }    

  protected override void LoadContent()
  {
    this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
    this.tank.LoadContent();
    base.LoadContent();
  }

  protected override void UnloadContent()
  {
    this.tank.UnloadContent();
    base.UnloadContent();
  }

  protected override void Update(GameTime gameTime)
  {
    this.tank.Update(gameTime);
    base.Update(gameTime);
  }

  protected override void Draw(GameTime gameTime)
  {
    this.GraphicsDevice.Clear(Color.CornflowerBlue);

    this.spriteBatch.Begin();
    this.tank.Draw(gameTime, spriteBatch);
    this.spriteBatch.End();
    
    base.Draw(gameTime);
  }
}
