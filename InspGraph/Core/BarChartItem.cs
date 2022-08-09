namespace InspGraph.Core
{
    public class BarChartItem : ChartItem
    {
        public BarChartItem(int[] data)
        {
            this.Data = data;
        }

        public int[] Data { get; set; }

        public override string ToString()
        {
            return "{" +
                String.Join(", ", new string[]
                    {
                        $"\"label\": \"{this.Label}\"",
                        $"\"data\": [{string.Join(", ", this.Point.Select(pt => $"{{\"x\": {pt.Item1}, \"y\": {pt.Item2}}}"))}]",
                        $"\"backgroudColor\": \"rgba({this.BackgroundColor.R}, {this.BackgroundColor.G}, {this.BackgroundColor.B}, {this.BackgroundColor.A / 255.0})\"",
                        $"\"borderColor\": \"rgba({this.BorderColor.R}, {this.BorderColor.G}, {this.BorderColor.B}, {this.BorderColor.A / 255.0})\"",
                        $"\"borderWidth\": {this.BorderWidth}",
                        $"\"fill\": false",
                        $"\"pointStyle\": \"{this.PointStyle.ToString()}\"",
                        $"\"pointRadius\": {this.PointRadius}",
                        $"\"pointHoverRadius\": {this.PointHoverRadius}",
                        $"\"pointBackgroudColor\": \"rgba({this.PointBackgroundColor.R}, {this.PointBackgroundColor.G}, {this.PointBackgroundColor.B}, {this.PointBackgroundColor.A / 255.0})\"",
                        $"\"pointBorderColor\": \"rgba({this.PointBorderColor.R}, {this.PointBorderColor.G}, {this.PointBorderColor.B}, {this.PointBorderColor.A / 255.0})\"",
                        $"\"pointBorderWidth\": {this.PointBorderWidth}",
                        $"\"showLine\": {this.IsShowLine.ToString().ToLower()}",
                    })
                + "}";
        }
    }
}
