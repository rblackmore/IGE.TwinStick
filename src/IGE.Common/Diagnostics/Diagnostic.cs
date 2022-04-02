namespace IGE.Common.Diagnostics;

using IGE.Common.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class Diagnostic : DrawableGameEntity
{
  private DiagnosticsDisplay diagnosticsDisplay;

  protected Diagnostic(
    Game game,
    GraphicsDeviceManager graphics,
    DiagnosticsDisplay diagnosticsDisplay)
    : base(game, graphics)
  {
    this.diagnosticsDisplay = diagnosticsDisplay;
  }

  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public TextBlock TextBlock { get; set; } = new TextBlock();

  public Vector2 Position { get; set; }

  public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
  {
    this.TextBlock.Draw(gameTime, spriteBatch, diagnosticsDisplay.Font, this.Position);
  }

  public Vector2 Measure()
  {
    this.TextBlock.Size = this.TextBlock.Measure(this.diagnosticsDisplay.Font);
    return this.TextBlock.Size;
  }
}
