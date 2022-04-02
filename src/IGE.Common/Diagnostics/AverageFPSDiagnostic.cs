namespace IGE.Common.Diagnostics;

using IGE.Common.Diagnostics.Data;

using Microsoft.Xna.Framework;

public class AverageFPSDiagnostic : Diagnostic
{
  public AverageFPSDiagnostic(Game game, GraphicsDeviceManager graphics, DiagnosticsDisplay diagnosticsDisplay)
    : base(game, graphics, diagnosticsDisplay)
  {

  }

  public override void Update(GameTime gameTime)
  {
    base.Update(gameTime);

    this.TextBlock.Text = "Average FPS: " + FrameRateCounter.AverageFramesPerSecond.ToString("0.00");
  }
}
