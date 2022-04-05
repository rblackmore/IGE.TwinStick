namespace IGE.Common.Diagnostics;

using IGE.Common.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class DiagnosticDetail
{
  private Func<string> UpdateValue;

  public DiagnosticDetail(Func<string> updateDelegate)
  {
    this.UpdateValue = updateDelegate;
  }

  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public TextBlock TextBlock { get; set; } = new TextBlock();

  public Vector2 Position { get; set; }

  public void Update(GameTime gameTime)
  {
    this.TextBlock.Text = this.UpdateValue();  
  }

  public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
  {
    this.TextBlock.Draw(gameTime, spriteBatch, this.Position);
  }
}
