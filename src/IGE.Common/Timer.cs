namespace IGE.Common;

using System.Timers;

using Microsoft.Xna.Framework;

public class Timer : GameEntity
{
  private TimeSpan span;

  private TimeSpan currentElapsed;

  public Timer(Game game, TimeSpan interval)
    : base(game)
  {
    this.span = interval;
  }

  public bool Repeat { get; set; }
  public int TriggerCount { get; set; }
  

  public override void Initialize()
  {
    base.Initialize();
    this.Enabled = false;
    this.currentElapsed = this.span;
  }

  public override void Update(GameTime gameTime)
  {
    if (!this.Enabled)
      return;

    base.Update(gameTime);

    this.currentElapsed += gameTime.ElapsedGameTime;
  }

  public bool IsTriggered()
  {
    if (this.currentElapsed < this.span)
      return false;

    if (!this.Repeat)
      this.Stop();

    this.Reset();

    this.TriggerCount++;

    return true;
  }
  
  public void Start()
  {
    this.Enabled = true;
  }

  public void Reset()
  {
    this.currentElapsed = this.span;
  }

  public void Stop()
  {
    this.Enabled = false;
  }
}
