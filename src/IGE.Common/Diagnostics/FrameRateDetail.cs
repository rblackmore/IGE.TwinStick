namespace IGE.Common.Diagnostics;

using Microsoft.Xna.Framework;

public class FrameRateDetail : DiagnosticDetail
{
  public const int MAX_SAMPLES = 100;

  private Queue<float> samples = new Queue<float>();

  private Timer timer = null!;

  public FrameRateDetail(Game game)
    : base(game)
  {
    this.Name = "Frame Rate";
    this.Description = "The current frame rate.";
  }

  public long TotalFrames { get; set; }
  public float TotalSeconds { get; set; }
  public float AverageFramesPerSecond { get; set; }
  public float CurrentFramesPerSecond { get; set; }

  public override void Initialize()
  {
    base.Initialize();

    this.timer = new Timer(this.Game, TimeSpan.FromSeconds(1))
    {
      Repeat = true,
    };

    this.timer.Start();
  }

  private void AddSample(float sample)
  {
    this.samples.Enqueue(sample);

    if (this.samples.Count > MAX_SAMPLES)
      this.samples.Dequeue();
  }

  public override void Update(GameTime gameTime)
  {
    if (!this.Enabled)
      return;

    base.Update(gameTime);
    this.timer.Update(gameTime);

    float sample = 1.0f / (float)gameTime.ElapsedGameTime.TotalSeconds;
    this.AddSample(sample);

    this.TotalFrames++;
    this.TotalSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

    this.CurrentFramesPerSecond = 1.0f / (float)gameTime.ElapsedGameTime.TotalSeconds;

    if (this.timer.IsTriggered())
      this.AverageFramesPerSecond = samples.Average(i => i);
  }
}
