namespace RealTimeChat.Blazor.Utilities;

public class GradientColors
{
    public string StartColor { get; set; }
    public string EndColor { get; set; }

    public GradientColors(string startColor, string endColor)
    {
        StartColor = startColor;
        EndColor = endColor;
    }
}