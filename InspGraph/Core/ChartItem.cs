using System.Drawing;

public class ChartItem
{
    public ChartItem(int [] data)
    {
        if (data is null)
            throw new ArgumentNullException("data");

        this.Data = data;
        this.Type = "bar";
        this.Options = "\"options\": {\"responsive\": true, \"maintainAspectRatio\": false}";
        Data = data;
    }

    public int[] Data { get; set; }

    public string Type { get; set; }

    public string[] Labels { get; set; }

    public string Label { get; set; } = "ChartItem";

    public Color BackgroundColor { get; set; }

    public Color BorderColor { get; set; }

    public double BorderWidth { get; set; }

    public string Options { get; set; } = "\"options\": {}";

    public string ToString()
    {
        return "{" +
            String.Join(", ", new string[]
                {
                                $"\"label\": \"{this.Label}\"",
                                $"\"data\": [{string.Join(", ", this.Data)}]",
                                $"\"backgroundColor\": \"rgba({this.BackgroundColor.R}, {this.BackgroundColor.G}, {this.BackgroundColor.B}, {this.BackgroundColor.A / 255.0})\"",
                                $"\"borderColor\": \"rgba({this.BorderColor.R}, {this.BorderColor.G}, {this.BorderColor.B}, {this.BorderColor.A / 255.0})\"",
                                $"\"borderWidth\": {this.BorderWidth}",
                })
            + "}";
    }
}
