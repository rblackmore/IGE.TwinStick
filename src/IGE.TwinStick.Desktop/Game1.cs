namespace IGE.TwinStick.Desktop;

using IGE.Common.Diagnostics;
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
    this.graphics.PreferredBackBufferWidth = 1600;
    this.graphics.PreferredBackBufferHeight = 800;
    this.graphics.ApplyChanges();
    this.tank = new Tank(this, this.graphics)
    {
      Position = new Vector2(500, 500),
      Velocity = new Velocity2(new Vector2(10, 0), 0.0f),
      Scale = new Vector2(0.5f),
    };
    
    base.Initialize();
  }    

  protected override void LoadContent()
  {
    var diagnosticFont = this.Content.Load<SpriteFont>("CaskaydiaCoveNF12");

    DiagnosticDisplay.LoadContent(this.GraphicsDevice, diagnosticFont);
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
    DiagnosticDisplay.Update(gameTime);
    this.tank.Update(gameTime);
    base.Update(gameTime);
  }

  protected override void Draw(GameTime gameTime)
  {
    this.GraphicsDevice.Clear(Color.Transparent);

    this.spriteBatch.Begin();
    this.tank.Draw(gameTime, spriteBatch);


    DiagnosticDisplay.Draw(gameTime, this.spriteBatch);
    this.spriteBatch.End();
    
    base.Draw(gameTime);
  }
}
