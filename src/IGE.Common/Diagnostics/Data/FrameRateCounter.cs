namespace IGE.Common.Diagnostics.Data;

using Microsoft.Xna.Framework;

public class FrameRateCounter
{
  public const int MAX_SAMPLES = 100;

  private Queue<float> samples = new Queue<float>();

  private Timer timer = null!;

  public FrameRateCounter()
  {
    timer = new Timer(TimeSpan.FromSeconds(1))
    {
      Repeat = true,
    };

    timer.Start();
  }

  public long TotalFrames { get; set; }
  public float TotalSeconds { get; set; }
  public float AverageFramesPerSecond { get; set; }
  public float CurrentFramesPerSecond { get; set; }

  public void Initialize()
  {
  }

  public void Update(GameTime gameTime)
  {
    timer.Update(gameTime);

    var sample = 1.0f / (float)gameTime.ElapsedGameTime.TotalSeconds;
    AddSample(sample);

    TotalFrames++;
    TotalSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

    CurrentFramesPerSecond = 1.0f / (float)gameTime.ElapsedGameTime.TotalSeconds;

    if (timer.IsTriggered())
      AverageFramesPerSecond = samples.Average(i => i);
  }

  private void AddSample(float sample)
  {
    samples.Enqueue(sample);

    if (samples.Count > MAX_SAMPLES)
      samples.Dequeue();
  }
}
