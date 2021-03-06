namespace IGE.Common.Text;

using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public sealed class TextBlock
{
  public string Text { get; set; } = string.Empty;
  public TextAlignment Alignment { get; set; }

  public Vector2 Size { get; set; }
  public Color Color { get; set; } = Color.White;
  public SpriteFont Font { get; set; }

  public void Draw(
    GameTime gametime,
    SpriteBatch spriteBatch,
    Vector2 position)
  {
    spriteBatch.DrawString(this.Font, this.Text, position, this.Color);
  }

  public Vector2 Measure()
  {
    return this.Font.MeasureString(this.Text);
  }

  #region Equality
  private IEnumerable<object> GetEqualityValues()
  {
    yield return this.Text;
  }

  private int? hashCode = null;

  public static bool operator ==(TextBlock a, TextBlock b)
  {
    if (a is null && b is null)
      return true;

    if (a is null || b is null)
      return false;

    return a.Equals(b);
  }

  public static bool operator !=(TextBlock a, TextBlock b)
  {
    return !(a == b);
  }

  public override bool Equals(object? obj)
  {
    if (obj is null)
      return false;

    if (obj is not TextBlock other)
      return false;

    return this.GetEqualityValues()
      .SequenceEqual(other.GetEqualityValues());
  }

  public override int GetHashCode()
  {
    if (!hashCode.HasValue)
      hashCode = HashCode.Combine(this.GetEqualityValues());

    return this.hashCode.Value;
  }

  public int CompareTo(object? obj)
  {
    return this.CompareTo(obj as TextBlock);
  }

  public int CompareTo(TextBlock? other)
  {
    if (other is null)
      return 1;

    var thisType = this.GetType();
    var otherType = other.GetType();

    if (thisType != otherType)
    {
      return string.Compare(
        thisType.ToString(),
        otherType.ToString(),
        StringComparison.Ordinal);
    }

    var thisValues = this.GetEqualityValues().ToArray();
    var otherValues = other.GetEqualityValues().ToArray();

    for (var i = 0; i < thisValues.Length; i++)
    {
      var valueComparison = CompareValue(thisValues[i], otherValues[i]);

      if (valueComparison != 0)
        return valueComparison;
    }

    return 0;
  }

  private int CompareValue(object obj1, object obj2)
  {
    if (obj1 is null && obj2 is null)
      return 0;

    if (obj1 is null)
      return -1;

    if (obj2 is null)
      return 1;

    if (obj1 is IComparable comparable1 && obj2 is IComparable comparable2)
      return comparable1.CompareTo(comparable2);

    return obj1.Equals(obj2) ? 0 : -1;
  }
  #endregion
}
