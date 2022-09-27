using System.Drawing;

namespace InspGraph.ViewModels
{
    public class SampleGraphViewModel : NotificationObject
    {
        int[] OkData = { 10503, 9993, 5004, 12305, 7604, 9994, 4196,
                         12345, 6467, 8858, 1305, 3467, 7774, 3735};

        int[] NgData = { 30, 54, 65, 86, 44, 22, 16,
                         87, 64, 8, 1, 76, 77, 85};

        string[] label = { "\"5:00\"", "\"6:00\"", "\"8/12\"", "\"8/13\"", "\"8/14\"", "\"8/15\"", "\"8/16\"",
            "\"8/17\"", "\"8/18\"", "\"8/19\"", "\"8/20\"", "\"8/21\"", "\"8/22\"", "\"8/23\"" };


        public SampleGraphViewModel()
        {
            this.CreateChartCommand = new DelegateCommand(_ => CreateChart());
        }

        private void CreateChart()
        {
            this.ChartItems = new ChartItem[]
            {
                new ChartItem(OkData)
                {
                    Labels = label,
                    Label = "OK数",
                    BackgroundColor = Color.FromArgb(100, 94, 142, 134),
                    BorderColor = Color.FromArgb(255, 94, 142, 134),
                    BorderWidth = 1,
                },

                new ChartItem(NgData)
                {
                    Label = "NG数",
                    BackgroundColor = Color.FromArgb(100, 186, 64, 48),
                    BorderColor = Color.FromArgb(255, 186, 64, 48),
                    BorderWidth = 1,
                },

            };
        }

        public DelegateCommand CreateChartCommand { get; private set; }

        private IEnumerable<ChartItem>? _chartItems;
        public IEnumerable<ChartItem>? ChartItems
        {
            get => this._chartItems;
            set { SetProperty(ref this._chartItems, value); }
        }

    }
}
