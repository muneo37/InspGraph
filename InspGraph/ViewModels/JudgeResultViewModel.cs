using System.Drawing;

namespace InspGraph.ViewModels;

public class JudgeResultViewModel : NotificationObject
{
    int[] OkData = { 10503, 9993, 5004, 12305, 7604, 9994, 4196,
                         12345, 6467, 8858, 1305, 3467, 7774, 3735};

    int[] NgData = { 30, 54, 65, 86, 44, 22, 16,
                         87, 64, 8, 1, 76, 77, 85};

    string[] label = { "\"8/10\"", "\"8/11\"", "\"8/12\"", "\"8/13\"", "\"8/14\"", "\"8/15\"", "\"8/16\"",
            "\"8/17\"", "\"8/18\"", "\"8/19\"", "\"8/20\"", "\"8/21\"", "\"8/22\"", "\"8/23\"" };

    int[] NoLabel = { 53, 23, 54, 42, 44, 64, 54,
                         45, 67, 58, 63, 75, 77, 35};
    int[] Mekure = { 30, 54, 45, 36, 44, 32, 56,
                         37, 34, 38, 43, 26, 27, 45};
    int[] Shiwa = { 13, 3, 5, 5, 4, 9, 6,
                         5, 7, 8, 13, 7, 7, 5};
    int[] Yabure = { 3, 4, 4, 6, 6, 2, 1,
                         7, 6, 8, 1, 7, 7, 8};

    int[] part = { 53, 23, 24, 2 };
    string[] partName = { "\"天面\"", "\"側面\"", "\"胴部\"", "\"底部\"" };
    string[] partColor = { "\"rgba(94, 142, 134, 0.5)\"", "\"rgba(186, 64, 48, 0.5)\"", "\"rgba(226, 221, 202, 0.5)\"", "\"rgba(44, 46, 60, 0.5)\"" };

    int[] No1 = { 53, 23, 54, 42, 44 };
    int[] No2 = { 11, 80, 11, 82, 92 };
    int[] No3 = { 44, 5, 73, 78, 27 };
    string[] ngKind = { "\"位置決め\"", "\"やぶれ\"", "\"めくれ\"", "\"しわ\"", "\"ラベル無し\"" };


    public JudgeResultViewModel()
    {
        this.CreateChartCommand = new DelegateCommand(_ => CreateChart());
        this.GraphKind = KindSelectList.Last();
    }

    private void CreateChart()
    {
        this.ChartItems = new BarChartItem[]
        {
            new BarChartItem(OkData)
            {
                Labels = label,
                Label = "OK数",
                BackgroundColor = Color.FromArgb(100, 94, 142, 134),
                BorderColor = Color.FromArgb(255, 94, 142, 134),
                BorderWidth = 1,
            },

            new BarChartItem(NgData)
            {
                Label = "NG数",
                BackgroundColor = Color.FromArgb(100, 186, 64, 48),
                BorderColor = Color.FromArgb(255, 186, 64, 48),
                BorderWidth = 1,
            },

        };

        this.ChartItems2 = new LineChartItem[]
        {
            new LineChartItem(NoLabel)
            {
                Labels = label,
                Label = "ラベル無し",
                BorderColor = Color.FromArgb(200, 94, 142, 134),
                BorderWidth = 1,
            },
            new LineChartItem(Mekure)
            {
                Labels = label,
                Label = "めくれ",
                BorderColor = Color.FromArgb(200, 186, 64, 48),
                BorderWidth = 1,
            },
            new LineChartItem(Shiwa)
            {
                Labels = label,
                Label = "しわ",
                BorderColor = Color.FromArgb(200, 226, 221, 202),
                BorderWidth = 1,
            },
            new LineChartItem(Yabure)
            {
                Labels = label,
                Label = "やぶれ",
                BorderColor = Color.FromArgb(200, 44, 46, 60),
                BorderWidth = 1,
            },
        };

        this.ChartItems3 = new PieChartItem[]
        {
            new PieChartItem(part, partColor)
            {
                Labels = partName,
                Label = "ラベル無し",
                BorderColor = Color.FromArgb(200, 30, 10, 233),
                BorderWidth = 1,
            },
        };

        this.ChartItems4 = new RadarChartItem[]
        {
            new RadarChartItem(No1)
            {
                Labels = ngKind,
                Label = "品種1",
                BorderColor = Color.FromArgb(200, 94, 142, 134),
                BorderWidth = 1,
            },
            new RadarChartItem(No2)
            {
                Labels = ngKind,
                Label = "品種2",
                BorderColor = Color.FromArgb(200, 186, 64, 48),
                BorderWidth = 1,
            },
            new RadarChartItem(No3)
            {
                Labels = ngKind,
                Label = "品種3",
                BorderColor = Color.FromArgb(200, 44, 46, 60),
                BorderWidth = 1,
            },
        };
    }

    private void CreateDynamicChart()
    {
        if (GraphKind == "bar")
        {
            this.ChartItems5 = new BarChartItem[]
            {
                new BarChartItem(OkData)
                {
                    Labels = label,
                    Label = "OK数",
                    BackgroundColor = Color.FromArgb(100, 94, 142, 134),
                    BorderColor = Color.FromArgb(255, 94, 142, 134),
                    BorderWidth = 1,
                },

                new BarChartItem(NgData)
                {
                    Label = "NG数",
                    BackgroundColor = Color.FromArgb(100, 186, 64, 48),
                    BorderColor = Color.FromArgb(255, 186, 64, 48),
                    BorderWidth = 1,
                },
            };
        }
        else if (GraphKind == "line")
        {
            this.ChartItems5 = new LineChartItem[]
            {
                new LineChartItem(NoLabel)
                {
                    Labels = label,
                    Label = "ラベル無し",
                    BorderColor = Color.FromArgb(200, 94, 142, 134),
                    BorderWidth = 1,
                },
                new LineChartItem(Mekure)
                {
                    Labels = label,
                    Label = "めくれ",
                    BorderColor = Color.FromArgb(200, 186, 64, 48),
                    BorderWidth = 1,
                },
                new LineChartItem(Shiwa)
                {
                    Labels = label,
                    Label = "しわ",
                    BorderColor = Color.FromArgb(200, 226, 221, 202),
                    BorderWidth = 1,
                },
                new LineChartItem(Yabure)
                {
                    Labels = label,
                    Label = "やぶれ",
                    BorderColor = Color.FromArgb(200, 44, 46, 60),
                    BorderWidth = 1,
                },
            };
        }
        else if (GraphKind == "pie")
        {
            this.ChartItems5 = new PieChartItem[]
            {
                new PieChartItem(part, partColor)
                {
                    Labels = partName,
                    Label = "ラベル無し",
                    BorderColor = Color.FromArgb(200, 30, 10, 233),
                    BorderWidth = 1,
                },
            };
        }
        else if (GraphKind == "radar")
        {
            this.ChartItems5 = new RadarChartItem[]
            {
                new RadarChartItem(No1)
                {
                    Labels = ngKind,
                    Label = "品種1",
                    BorderColor = Color.FromArgb(200, 94, 142, 134),
                    BorderWidth = 1,
                },
                new RadarChartItem(No2)
                {
                    Labels = ngKind,
                    Label = "品種2",
                    BorderColor = Color.FromArgb(200, 186, 64, 48),
                    BorderWidth = 1,
                },
                new RadarChartItem(No3)
                {
                    Labels = ngKind,
                    Label = "品種3",
                    BorderColor = Color.FromArgb(200, 44, 46, 60),
                    BorderWidth = 1,
                },
            };
        }
    }


    public DelegateCommand CreateChartCommand { get; private set; }

    private string _graphKind = "";
    public string GraphKind
    {
        get => this._graphKind;
        set 
        { 
            SetProperty(ref this._graphKind, value);
            CreateDynamicChart();
        }
    }

    private List<string> _kindSelectList = new List<string>() { "bar", "line", "pie", "radar" };
    public List<string> KindSelectList
    {
        get => this._kindSelectList;
    }

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

    private IEnumerable<ChartItem>? _chartItems3;
    public IEnumerable<ChartItem>? ChartItems3
    {
        get => this._chartItems3;
        set { SetProperty(ref this._chartItems3, value); }
    }

    private IEnumerable<ChartItem>? _chartItems4;
    public IEnumerable<ChartItem>? ChartItems4
    {
        get => this._chartItems4;
        set { SetProperty(ref this._chartItems4, value); }
    }

    private IEnumerable<ChartItem>? _chartItems5;
    public IEnumerable<ChartItem>? ChartItems5
    {
        get => this._chartItems5;
        set { SetProperty(ref this._chartItems5, value); }
    }

    private Random _rand = new Random();
}