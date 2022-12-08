using InspGraph.Model;
using System.Collections.ObjectModel;

namespace InspGraph.ViewModels
{
    public class StatisticsViewModel : NotificationObject
    {
        #region フィールド

        /// <summary>
        /// チャート
        /// </summary>
        private List<ChartContents> _chartContents = new List<ChartContents>();

        /// <summary>
        /// チャートコンフィグレーションのリスト [0]:チャート種類　[1]:ラベルタイプ　[2]以降:アイテム名
        /// </summary>
        private List<string[]> _chartConfig = new List<string[]>();

        #endregion


        #region プロパティ

        /// <summary>
        /// チャートプロパティ
        /// </summary>
        public List<ChartContents> ChartContents
        {
            get => this._chartContents;
            set { SetProperty(ref this._chartContents, value); }
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
            string dir = Directory.GetCurrentDirectory();
            string configFile = dir + "\\conf.txt";

            this._chartConfig = ConfigReader.ReadCommaStrings(configFile);
            this.CreateChartCommand = new DelegateCommand(_ => CreateChart());
        }

        /// <summary>
        /// チャート表示更新
        /// </summary>
        private void CreateChart()
        {
            List<ChartContents> chartContents = new List<ChartContents>();

            foreach( var config in this._chartConfig)
            {
                var itemConditions = new List<ChartItemConditions>();

                for(int i=2; i<config.Length; i++)
                {
                    itemConditions.Add(new ChartItemConditions { DataName = config[i], BackGroundColor = AppColors.AccentColorBlue, Options = "\"barPercentage\": 0.2" });//TODO
                }

                ChartConditions conditions = new ChartConditions()
                {
                    LabelT = ConvertLabelType(config[1]),
                    ItemConditions = itemConditions,
                    StartDate = DateTime.Parse("2022/11/08"),
                    EndDate = DateTime.Parse("2022/11/14"),
                    EnableCamera = new List<int> { 1, 3 },
                    EnableProduct = new List<int> { 1, 2, 3 },
                };

                var chartData = new ChartData(conditions);

                var contents = new ChartContents()
                {
                    Type = config[0],
                    Labels = chartData.CreateLabels().ToArray(),
                    Items = chartData.Items,
                    Options = "\"options\": {\"responsive\": true, \"maintainAspectRatio\": false}"
                };

                chartContents.Add(contents);
            }

            this.ChartContents = chartContents;
        }

        /// <summary>
        /// 文字列をLabelType型に変換する。
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        private LabelType ConvertLabelType(string label)
        {
            switch (label)
            {
                case "0":
                    return LabelType.day;
                case "1":
                    return LabelType.time;
                case "2":
                    return LabelType.defect;
                case "3":
                    return LabelType.camera;
                case "4":
                    return LabelType.product;
                default:
                    return LabelType.day;
            }
        }
        #endregion

    }
}
