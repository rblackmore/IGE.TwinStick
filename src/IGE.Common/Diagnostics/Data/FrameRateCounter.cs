namespace IGE.Common.Diagnostics.Data;

using Microsoft.Xna.Framework;

public class FrameRateCounter : GameEntity
{
  public const int MAX_SAMPLES = 100;

  private Queue<float> samples = new Queue<float>();

  private Timer timer = null!;

  public FrameRateCounter(Game game)
    : base(game)
  {
    timer = new Timer(game, TimeSpan.FromSeconds(1))
    {
      Repeat = true,
    };

    timer.Start();
  }

  public static long TotalFrames { get; set; }
  public static float TotalSeconds { get; set; }
  public static float AverageFramesPerSecond { get; set; }
  public static float CurrentFramesPerSecond { get; set; }

  public override void Initialize()
  {
    base.Initialize();


  }

  public override void Update(GameTime gameTime)
  {
    if (!Enabled)
      return;

    base.Update(gameTime);
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
