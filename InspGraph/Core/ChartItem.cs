using System.Drawing;

public abstract class ChartItem
{
    public ChartItem()
    {
        ;
    }

    public string Type { get; set; }

    public string[] Labels { get; set; }

    public string Label { get; set; } = "ChartItem";

    public Color BackgroundColor { get; set; }

    public Color BorderColor { get; set; }

    public double BorderWidth { get; set; }

    public string Options { get; set; } = "\"options\": {}";

    public abstract override string ToString();

}
