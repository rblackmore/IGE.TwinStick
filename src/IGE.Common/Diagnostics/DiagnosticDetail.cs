namespace IGE.Common.Diagnostics;

using Microsoft.Xna.Framework;

public abstract class DiagnosticDetail : GameEntity
{
  protected DiagnosticDetail(Game game) 
    : base(game)
  {
  }

  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
}
