using InspGraph.Model;
using System.Drawing;

namespace InspGraph.ViewModels
{
    public class SampleGraphViewModel : NotificationObject
    {
        #region フィールド
        /// <summary>
        /// チャートアイテム
        /// </summary>
        private IEnumerable<ChartItem>? _barChartItems;
        private IEnumerable<ChartItem>? _pieChartItems;
        private IEnumerable<ChartItem>? _radarChartItems;
        private IEnumerable<ChartItem>? _lineChartItems;

        /// <summary>
        /// チャートデータ
        /// </summary>
        private ChartData _barChartData = new ChartData("bar");
        private ChartData _pieChartData = new ChartData("pie");
        private ChartData _radarChartData = new ChartData("radar");
        private ChartData _lineChartData = new ChartData("line");
        #endregion


        #region プロパティ
        /// <summary>
        /// チャートアイテムプロパティ
        /// </summary>
        public IEnumerable<ChartItem>? BarChartItems
        {
            get => this._barChartItems;
            set { SetProperty(ref this._barChartItems, value); }
        }
        public IEnumerable<ChartItem>? PieChartItems
        {
            get => this._pieChartItems;
            set { SetProperty(ref this._pieChartItems, value); }
        }
        public IEnumerable<ChartItem>? RadarChartItems
        {
            get => this._radarChartItems;
            set { SetProperty(ref this._radarChartItems, value); }
        }
        public IEnumerable<ChartItem>? LineChartItems
        {
            get => this._lineChartItems;
            set { SetProperty(ref this._lineChartItems, value); }
        }
        #endregion


        #region　コマンド
        /// <summary>
        /// チャート表示更新コマンド
        /// </summary>
        public DelegateCommand CreateChartCommand { get; private set; }
        #endregion


        #region メソッド
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SampleGraphViewModel()
        {
            this.CreateChartCommand = new DelegateCommand(_ => CreateChart());
        }

        /// <summary>
        /// チャート表示更新
        /// </summary>
        private void CreateChart()
        {
            this.BarChartItems = this._barChartData.Items;
            this.PieChartItems = this._pieChartData.Items;
            this.RadarChartItems = this._radarChartData.Items;
            this.LineChartItems = this._lineChartData.Items;
        }

        #endregion

    }
}
