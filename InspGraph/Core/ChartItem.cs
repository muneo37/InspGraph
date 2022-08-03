using System.Drawing;

namespace InspGraph
{
    public class ChartItem
    {
        public ChartItem(Tuple<double, double>[] data)
        {
            if (data is null)
                throw new ArgumentNullException("points");

            this.Point = data;
        }

        public string Label { get; set; } = "ChartItem";

        public Tuple<double, double>[] Point { get; set; }

        public Color BackgroundColor { get; set; }

        public Color BorderColor { get; set; }

        public double BorderWidth { get; set; }

        public PointStyles PointStyle { get; set; }

        public double PointRadius { get; set; }

        public Color PointBackgroundColor { get; set; }

        public Color PointBorderColor { get; set; }

        public double PointBorderWidth { get; set; }

        public double PointHoverRadius { get; set; }

        public bool IsShowLine { get; set; }

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
