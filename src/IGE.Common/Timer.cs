namespace IGE.Common;

using Microsoft.Xna.Framework;

public class Timer
{
  private TimeSpan span;

  private TimeSpan currentElapsed;

  private bool IsEnabled = true;

  public Timer(TimeSpan interval)
  {
    this.span = interval;
  }

  public bool Repeat { get; set; }
  public int TriggerCount { get; set; }
  

  public void Initialize()
  {
    this.IsEnabled = false;
    this.currentElapsed = this.span;
  }
  
  public void Update(GameTime gameTime)
  {
    if (!this.IsEnabled)
      return;

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
    this.IsEnabled = true;
  }

  public void Reset()
  {
    this.currentElapsed = this.span;
  }

  public void Stop()
  {
    this.IsEnabled = false;
  }
}
