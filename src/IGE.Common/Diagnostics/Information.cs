namespace IGE.Common.Diagnostics;

using Microsoft.Xna.Framework;

public class Information : Diagnostic
{
  public Information(Game game, GraphicsDeviceManager graphics, DiagnosticsDisplay diagnosticsDisplay, string message)
    : base(game, graphics, diagnosticsDisplay)
  {
    this.TextBlock.Text = message;
  }

  
}
