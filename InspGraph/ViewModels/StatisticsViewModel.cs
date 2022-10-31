using InspGraph.Model;

namespace InspGraph.ViewModels
{
    public class StatisticsViewModel : NotificationObject
    {
        #region フィールド
        /// <summary>
        /// チャートアイテム
        /// </summary>
        private IEnumerable<ChartItem>? _judgeBarChartItems;

        /// <summary>
        /// チャートデータ
        /// </summary>
        private ChartData _judgeBarChartData = new ChartData("bar");
        #endregion


        #region プロパティ

        /// <summary>
        /// チャートアイテムプロパティ
        /// </summary>
        public IEnumerable<ChartItem>? JudgeBarChartItems
        {
            get => this._judgeBarChartItems;
            set { SetProperty(ref this._judgeBarChartItems, value); }
        }
        #endregion


        #region コマンド
        /// <summary>
        /// チャート表示コマンド
        /// </summary>
        public DelegateCommand CreateChartCommand { get; private set; }
        #endregion

        #region メソッド
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public StatisticsViewModel()
        {
            this.CreateChartCommand = new DelegateCommand(_ => CreateChart());
        }

        /// <summary>
        /// チャート表示更新
        /// </summary>
        private void CreateChart()
        {
            this.JudgeBarChartItems = this._judgeBarChartData.Items;
        }
        #endregion

    }
}
