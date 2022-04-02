namespace IGE.Common.Text;

public struct TextAlignment
{
  public TextAlignment()
  {
    
  }
  
  public HorizontalTextAlignment HorizontalAlignment { get; set; } 
    = HorizontalTextAlignment.LeftJustified;
  public VerticalTextAlignment VerticalAlignment { get; set; } 
    = VerticalTextAlignment.TopJustified;
}

public enum HorizontalTextAlignment
{
  LeftJustified = 0,
  CenterJustified = 1,
  RightJustified = 2
}

public enum VerticalTextAlignment
{
  TopJustified = 0,
  CenterJustified = 1,
  BottonJustified = 2
}
