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
            ChartConditions conditions = new ChartConditions()
            {
                ChartType = "bar",
                LabelT = (int)LabelType.day,
                DataNames = new List<string> { "OK数", "NG数" },
                StartDate = DateTime.Parse("2022/11/08"),
                EndDate = DateTime.Parse("2022/11/14"),
                EnableCamera = new List<int> { 1, 3},
                EnableProduct = new List<int> { 1, 2, 3},
            };

            this.JudgeBarChartItems = new ChartData(conditions).Items;
        }
        #endregion

    }
}
