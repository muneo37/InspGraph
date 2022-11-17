
public class ChartContents
{
    public ChartContents()
    {
        this.Options = "\"options\": {\"responsive\": true, \"maintainAspectRatio\": false}";
    }

    public string? Type { get; set; }

    public string[] Labels { get; set; } = { "" };

    public string Options { get; set; } = "\"options\": {}";

    public IEnumerable<ChartItem>? Items { get; set; }
}
