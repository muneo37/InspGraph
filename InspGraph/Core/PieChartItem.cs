using System.Drawing;



public class PieChartItem : ChartItem
{
    public PieChartItem(int[] data, string[] backgroundColors)
    {
        if (data is null)
            throw new ArgumentNullException("data");

        this.Data = data;
        this.BackgroundColors = backgroundColors;
        this.Type = "pie";
        this.Options = "\"options\": {\"plugins\": { \"legend\": {\"display\": \"true\", \"position\": \"left\"}}}";
        //this.Options = "\"options\": {}";
        //this.Options = "\"options\": {\"animation\": true}";

    }

    public int[] Data { get; set; }
    public string[] BackgroundColors { get; set; }

    public override string ToString()
    {
        return "{" +
            String.Join(", ", new string[]
                {
                        $"\"data\": [{string.Join(", ", this.Data)}]",
                        $"\"backgroundColor\": [{string.Join(", ", this.BackgroundColors)}]",
                        $"\"borderWidth\": {this.BorderWidth}",
                })
            + "}";
    }
}


