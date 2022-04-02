namespace IGE.Common.Diagnostics;

using IGE.Common.Diagnostics.Data;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class DiagnosticsDisplay : DrawableGameEntity
{
  private Dictionary<Type, Diagnostic> diagnostics = new Dictionary<Type, Diagnostic>();
  
  private FrameRateCounter frameRateCounter;

  public DiagnosticsDisplay(
    Game game,
    GraphicsDeviceManager graphics,
    SpriteFont font)
    : base(game, graphics)
  {
    Font = font;
    this.frameRateCounter = new FrameRateCounter(game);
  }

  public Vector2 Position { get; set; } = new Vector2(3);
  
  public SpriteFont Font { get; set; }

  public override void Update(GameTime gameTime)
  {
    base.Update(gameTime);

    foreach (var diag in diagnostics.Values)
    {
      diag.Update(gameTime);
    }

    this.CalculatePositions();
  }

  public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
  {
    this.frameRateCounter.Update(gameTime);
    
    base.Draw(gameTime, spriteBatch);

    foreach (var diag in this.diagnostics.Values)
    {
      diag.Draw(gameTime, spriteBatch);
    }
  }

  private void CalculatePositions()
  {
    var y = Position.Y;
    
    foreach (var diag in diagnostics.Values)
    {
      diag.Position = new Vector2(Position.X, y);
      y += diag.Measure().Y;
    }
  }

  public void Add(Diagnostic diagnostic)
  {
    if (!this.diagnostics.ContainsKey(diagnostic.GetType()))
      diagnostics.Add(diagnostic.GetType(), diagnostic);

    this.CalculatePositions();
  }

  public void Remove(Diagnostic diagnostic)
  {
    if (this.diagnostics.ContainsKey(diagnostic.GetType()))
      diagnostics.Remove(diagnostic.GetType());
    
    this.CalculatePositions();
  }
}    
