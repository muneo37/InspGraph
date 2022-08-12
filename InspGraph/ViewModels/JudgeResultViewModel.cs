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
        const int datanum = 1000;

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
            new ChartItem(Enumerable.Range(0, datanum/2).Select(x => new Tuple<double, double>(x, Math.Sin(2 * Math.PI * DateTime.Today.Day * x / 1000 - Math.PI) + (this._rand.NextDouble() - 0.5) / 5)).ToArray())
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

        int[] OkData = { 10503, 9993, 5004, 12305, 7604, 9994, 4196,
                         12345, 6467, 8858, 1305, 3467, 7774, 3735};
        int[] NgData = { 30, 54, 65, 86, 44, 22, 16,
                         87, 64, 8, 1, 76, 77, 85};
        this.ChartItems2 = new BarChartItem[]
        {
            new BarChartItem(OkData)
            {
                Label = "OK��",
                BackgroundColor = Color.FromArgb(100, 20, 40, 200),
                BorderColor = Color.FromArgb(255, 10, 10, 255),
                BorderWidth = 1,
            },
            new BarChartItem(NgData)
            {
                Label = "NG��",
                BackgroundColor = Color.FromArgb(100, 240, 4, 30),
                BorderColor = Color.FromArgb(255, 255, 4, 25),
                BorderWidth = 1,
            },
        };


        this.ChartItems3 = new BarChartItem[]
        {
            new BarChartItem(OkData)
            {
                Label = "OK��",
                BackgroundColor = Color.FromArgb(100, 20, 40, 200),
                BorderColor = Color.FromArgb(255, 10, 10, 255),
                BorderWidth = 1,
            },
            new BarChartItem(NgData)
            {
                Label = "NG��",
                BackgroundColor = Color.FromArgb(100, 240, 4, 30),
                BorderColor = Color.FromArgb(255, 255, 4, 25),
                BorderWidth = 1,
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

    private IEnumerable<BarChartItem>? _chartItems2;
    public IEnumerable<BarChartItem>? ChartItems2
    {
        get => this._chartItems2;
        set { SetProperty(ref this._chartItems2, value); }
    }

    private IEnumerable<BarChartItem>? _chartItems3;
    public IEnumerable<BarChartItem>? ChartItems3
    {
        get => this._chartItems3;
        set { SetProperty(ref this._chartItems3, value); }
    }

    private Random _rand = new Random();
}