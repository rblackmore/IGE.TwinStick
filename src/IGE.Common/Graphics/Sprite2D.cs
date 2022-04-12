namespace IGE.Common.Graphics;

using IGE.Common;
using IGE.Common.Graphics.ValueObjects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class Sprite2D : DrawableGameEntity
{
  protected Texture2D texture = null!;

  protected Vector2 position = Vector2.Zero;
  protected Vector2 scale = Vector2.One;
  protected Vector2 origin = Vector2.Zero;
  protected Color color = Color.White;
  protected float rotation = 0.0f;
  protected SpriteEffects spriteEffects = SpriteEffects.None;
  protected Velocity2 velocity = Velocity2.Zero;


  private readonly string assetName;

  public Sprite2D(string assetName!!)
  {
    this.assetName = assetName;
  }

  public Vector2 Position { get { return this.position; } init { this.position = value; } }
  public Vector2 Scale { get { return this.scale; } init { this.scale = value; } }
  public Vector2 Origin { get { return this.origin; } init { this.origin = value; } }
  public Color Color { get { return this.color; } init { this.color = value; } }
  public SpriteEffects SpriteEffects { get { return this.spriteEffects; } init { this.spriteEffects = value; } }
  public float Rotation { get { return this.rotation; } init { this.rotation = value; } }
  public Velocity2 Velocity { get { return this.velocity; } init { this.velocity = value; } }


  public Rectangle Rectangle => new Rectangle(
    (int)(this.position.X - this.origin.X),
    (int)(this.position.Y - this.origin.Y),
    (int)(this.texture.Width * this.scale.X),
    (int)(this.texture.Height * this.scale.Y));

  public override void Initialize()
  {
    base.Initialize();
  }

  public override void LoadContent()
  {
    this.texture = this.Game.Content.Load<Texture2D>(this.assetName);
    this.origin = new Vector2((this.texture.Width * this.scale.X), (this.texture.Height * this.scale.Y));
    base.LoadContent();
  }

  public override void UnloadContent()
  {
    base.UnloadContent();
  }

  public override void Update(GameTime gameTime)
  {
    var translation = this.velocity.GetTranslation(gameTime);
    this.position += translation;

    base.Update(gameTime);
  }

  public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
  {
    base.Draw(gameTime, spriteBatch);

    spriteBatch.Draw(
      this.texture,
      this.Rectangle,
      null!,
      this.Color,
      this.Rotation,
      this.Origin,
      this.SpriteEffects,
      0);
  }
}
