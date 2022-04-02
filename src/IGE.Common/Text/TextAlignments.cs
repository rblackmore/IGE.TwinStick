namespace IGE.Common.Text;

public struct TextAlignment
{
  public TextAlignment()
  {
    this.HorizontalAlignment = HorizontalTextAlignment.Left;
    this.VerticalAlignment = VerticalTextAlignment.Top;
  }
  
  public HorizontalTextAlignment HorizontalAlignment { get; set; } 

  public VerticalTextAlignment VerticalAlignment { get; set; } 
}

public enum HorizontalTextAlignment
{
  Left = 0,
  Centered = 1,
  Right = 2
}

public enum VerticalTextAlignment
{
  Top = 0,
  Centered = 1,
  Bottom = 2
}
