using System.Drawing;

namespace InspGraph.ViewModels;

public class JudgeResultViewModel : NotificationObject
{
    public JudgeResultViewModel()
    {
        this.CreateChartCommand = new DelegateCommand(_ => CreateChart());
    }

    private void CreateChart()
    {
        const int datanum = 1001;
        this.ChartItems = new ChartItem[]
        {
            new ChartItem(Enumerable.Range(0, datanum).Select(x => new Tuple<double, double>(x, Math.Sin(2 * Math.PI * DateTime.Today.Day * x / 1000) + (this._rand.NextDouble() - 0.5) / 5)).ToArray())
            {
                Label = "Item 1",
                BackgroundColor = Color.FromArgb(255, 232, 17, 35),
                BorderColor = Color.FromArgb(255, 232, 17, 35),
                BorderWidth = 1,
                PointStyle = PointStyles.circle,
                PointRadius = 5,
                PointBackgroundColor = Color.FromArgb(255, 232, 17, 35),
                PointBorderColor = Color.FromArgb(255, 232, 17, 35),
                PointBorderWidth = 1,
                PointHoverRadius = 8,
                IsShowLine = true,
            },
            new ChartItem(Enumerable.Range(0, datanum).Select(x => new Tuple<double, double>(x, Math.Sin(2 * Math.PI * DateTime.Today.Day * x / 1000 - Math.PI) + (this._rand.NextDouble() - 0.5) / 5)).ToArray())
            {
                Label = "Item 2",
                BackgroundColor = Color.FromArgb(255, 27, 110, 194),
                BorderColor = Color.FromArgb(255, 27, 110, 194),
                BorderWidth = 1,
                PointStyle = PointStyles.rect,
                PointRadius = 5,
                PointBackgroundColor = Color.FromArgb(255, 27, 110, 194),
                PointBorderColor = Color.FromArgb(255, 27, 110, 194),
                PointBorderWidth = 1,
                PointHoverRadius = 8,
                IsShowLine = true,
            },
        };

        this.ChartItems2 = new ChartItem[]
        {
            new ChartItem(Enumerable.Range(0, datanum).Select(x => new Tuple<double, double>(x, Math.Sin(2 * Math.PI * DateTime.Today.Day * x / 1000) + (this._rand.NextDouble() - 0.5) / 5)).ToArray())
            {
                Label = "Item 1",
                BackgroundColor = Color.FromArgb(255, 232, 255, 35),
                BorderColor = Color.FromArgb(255, 232, 255, 35),
                BorderWidth = 1,
                PointStyle = PointStyles.circle,
                PointRadius = 5,
                PointBackgroundColor = Color.FromArgb(255, 232, 255, 35),
                PointBorderColor = Color.FromArgb(255, 232, 255, 35),
                PointBorderWidth = 1,
                PointHoverRadius = 8,
                IsShowLine = true,
            },
            new ChartItem(Enumerable.Range(0, datanum).Select(x => new Tuple<double, double>(x, Math.Sin(2 * Math.PI * DateTime.Today.Day * x / 1000 - Math.PI) + (this._rand.NextDouble() - 0.5) / 5)).ToArray())
            {
                Label = "Item 2",
                BackgroundColor = Color.FromArgb(255, 27, 4, 194),
                BorderColor = Color.FromArgb(255, 27, 4, 194),
                BorderWidth = 1,
                PointStyle = PointStyles.rect,
                PointRadius = 5,
                PointBackgroundColor = Color.FromArgb(255, 27, 4, 194),
                PointBorderColor = Color.FromArgb(255, 27, 4, 194),
                PointBorderWidth = 1,
                PointHoverRadius = 8,
                IsShowLine = true,
            },
        };
    }

    public DelegateCommand CreateChartCommand { get; private set; }

    public string PageTitle { get; } = "Blazor De NWF";

    private IEnumerable<ChartItem>? _chartItems;
    public IEnumerable<ChartItem>? ChartItems
    {
        get => this._chartItems;
        set { SetProperty(ref this._chartItems, value); }
    }

    private IEnumerable<ChartItem>? _chartItems2;
    public IEnumerable<ChartItem>? ChartItems2
    {
        get => this._chartItems2;
        set { SetProperty(ref this._chartItems2, value); }
    }

    private Random _rand = new Random();
}