using InspGraph.Model;

namespace InspGraph.ViewModels
{
    public class StatisticsViewModel : NotificationObject
    {
        #region フィールド

        /// <summary>
        /// チャート
        /// </summary>
        private ChartContents? _judgeBarChartContents;

        #endregion


        #region プロパティ

        /// <summary>
        /// チャートプロパティ
        /// </summary>
        public ChartContents? JudgeBarChartContents
        {
            get => this._judgeBarChartContents;
            set { SetProperty(ref this._judgeBarChartContents, value); }
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
                LabelT = (int)LabelType.day,
                ItemConditions = new List<ChartItemConditions> {
                            new ChartItemConditions{DataName = "OK数", BackGroundColor = AppColors.AccentColorBlue, Options = "\"barPercentage\": 0.2"},
                            new ChartItemConditions{DataName = "NG数", BackGroundColor = AppColors.AccentColorPink, Options = "\"barPercentage\": 0.2"},
                            },
                StartDate = DateTime.Parse("2022/11/08"),
                EndDate = DateTime.Parse("2022/11/14"),
                EnableCamera = new List<int> { 1, 3},
                EnableProduct = new List<int> { 1, 2, 3},
            };

            var chartData = new ChartData(conditions);

            this.JudgeBarChartContents = new ChartContents()
            {
                Type = "bar",
                Labels = chartData.CreateLabels().ToArray(),
                Items = chartData.Items,
                Options = "\"options\": {\"responsive\": true, \"maintainAspectRatio\": false}"
            };
        }
        #endregion

    }
}
