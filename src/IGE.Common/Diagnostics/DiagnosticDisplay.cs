namespace IGE.Common.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IGE.Common.Diagnostics.Data;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public enum DisplayLocation
{
  TopLeft,
  TopRight,
  BottomLeft,
  BottomRight
}


public static class DiagnosticDisplay
{
  private static FrameRateCounter frameCounter = new FrameRateCounter();
  
  private static List<DiagnosticDetail> diagnostics = new List<DiagnosticDetail>();

  public static SpriteFont? Font { get; set; }

  public static DisplayLocation Location = DisplayLocation.TopLeft;

  private static GraphicsDevice? GraphicsDevice { get; set; }

  public static Vector2 Position
  {
    get
    {
      if (GraphicsDevice is null)
        return new Vector2(3);

      switch (Location)
      {
        case DisplayLocation.TopLeft:
          return new Vector2(3, 3);
        case DisplayLocation.TopRight:
          return new Vector2(GraphicsDevice.Viewport.Width - 3, 3);
        case DisplayLocation.BottomLeft:
          return new Vector2(3, GraphicsDevice.Viewport.Height - 3);
        case DisplayLocation.BottomRight:
          return new Vector2(GraphicsDevice.Viewport.Width - 3, GraphicsDevice.Viewport.Height - 3);
        default:
          return new Vector2(3, 3);
      }
    }
  }

  public static void LoadContent(GraphicsDevice graphicsDevice, SpriteFont font)
  {
    GraphicsDevice = graphicsDevice;
    Font = font;
    
    Add(new DiagnosticDetail(() =>
    {
      return $"FPS: {frameCounter.AverageFramesPerSecond}";
    }));
  }

  public static void Add(DiagnosticDetail diagnostic)
  {
    diagnostic.TextBlock.Font = Font;

    diagnostics.Add(diagnostic);

    CalculatePositions();
  }

  public static void Update(GameTime gameTime)
  {
    foreach (DiagnosticDetail diagnostic in diagnostics)
    {
      diagnostic.Update(gameTime);
    }

    CalculatePositions();
  }

  public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
  {
    frameCounter.Update(gameTime);
    
    foreach (DiagnosticDetail diagnostic in diagnostics)
    {
      diagnostic.Draw(gameTime, spriteBatch);
    }
  }

  private static void CalculatePositions()
  {
    var y = Position.Y;

    foreach (DiagnosticDetail diagnostic in diagnostics)
    {
      diagnostic.Position = new Vector2(Position.X, y);
      y += diagnostic.TextBlock.Measure().Y;
    }
  }
}
