namespace IGE.Common.Graphics.ValueObjects;

using System.Collections.Generic;

using Microsoft.Xna.Framework;

public sealed class Velocity2 : IComparable, IComparable<Velocity2>
{
  public Velocity2()
  {

  }

  public Velocity2(Vector2 direction)
  {
    Direction = direction;
  }

  public Velocity2(float speed)
  {
    Speed = speed;
  }

  public Velocity2(Vector2 direction, float speed)
  {
    Speed = speed;
    Direction = direction;
  }

  public Vector2 Direction { get; } = Vector2.Zero;
  public float Speed { get; } = 0.0f;

  public static Velocity2 Zero { get; } = new Velocity2(Vector2.Zero, 0.0f);

  public Vector2 GetTranslation(GameTime gameTime)
  {
    if (this.Speed == 0.0f || this.Direction == Vector2.Zero)
      return Vector2.Zero;

    return this.Direction * ((float)gameTime.ElapsedGameTime.TotalSeconds * this.Speed / this.Direction.Length());
  }

  public Velocity2 ChangeDirection(Vector2 newDirection)
  {
    return new Velocity2(newDirection, this.Speed);
  }

  public Velocity2 IncreaseSpeed(float delta)
  {
    return new Velocity2(this.Direction, this.Speed + delta);
  }

  public Velocity2 DecreaseSpeed(float delta)
  {
    return new Velocity2(this.Direction, this.Speed - delta);
  }

  public Velocity2 ChangeSpeed(float newSpeed)
  {
    return new Velocity2(this.Direction, newSpeed);
  }

  public Velocity2 Stop()
  {
    return new Velocity2(Vector2.Zero, 0.0f);
  }

  public override string ToString()
  {
    return $"Direction: {this.Direction}, Speed: {this.Speed}";
  }

  #region Equality
  private IEnumerable<object> GetEqualityValues()
  {
    yield return this.Direction;
    yield return this.Speed;
  }

  private int? hashCode = null;

  public static bool operator ==(Velocity2 a, Velocity2 b)
  {
    if (a is null && b is null)
      return true;

    if (a is null || b is null)
      return false;

    return a.Equals(b);
  }

  public static bool operator !=(Velocity2 a, Velocity2 b)
  {
    return !(a == b);
  }

  public override bool Equals(object? obj)
  {
    if (obj is null)
      return false;

    if (obj is not Velocity2 other)
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
    return this.CompareTo(obj as Velocity2);
  }

  public int CompareTo(Velocity2? other)
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

