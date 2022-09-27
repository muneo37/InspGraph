using InspGraph.Model;
using System.Drawing;

namespace InspGraph.ViewModels
{
    public class SampleGraphViewModel : NotificationObject
    {
        #region フィールド
        private IEnumerable<ChartItem>? _chartItems;
        private ChartData _chartData = new ChartData();
        #endregion


        #region プロパティ
        public IEnumerable<ChartItem>? ChartItems
        {
            get => this._chartItems;
            set { SetProperty(ref this._chartItems, value); }
        }
        #endregion


        #region　コマンド
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
            this.ChartItems = this._chartData.Items;
        }

        #endregion

    }
}
