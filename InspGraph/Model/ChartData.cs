using InspGraph.Operator;
using System.Drawing;

namespace InspGraph.Model
{
    /// <summary>
    /// 条件にあわせて、ChartItemを生成するクラス
    /// </summary>
    public class ChartData
    {
        #region フィールド
        private ChartConditions _chartConditions;
        private List<ChartItem> _items = new List<ChartItem>();
        #endregion


        #region プロパティ
        public List<ChartItem> Items
        {
            get => this._items;
        }
        #endregion


        #region　メソッド
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="condition">アイテム条件</param>
        public ChartData(ChartConditions condition)
        {
            _chartConditions = condition;
            int[] data = new int[] { };
            ChartItem item;
            int index = -1;

            foreach(ChartItemConditions itemConditon in _chartConditions.ItemConditions)
            {
                index++;
                switch(_chartConditions.LabelT)
                {
                    case LabelType.day:
                        data = CreateDataByDate(itemConditon.DataName).ToArray();
                        break;
                    case LabelType.camera:
                        data = CreateDataByCamera(itemConditon.DataName).ToArray();
                        break;
                }

                switch(_chartConditions.ChartType)
                {
                    case "bar":
                    case "line":
                        item = new ChartItem(data)
                        {
                            Label = itemConditon.DataName,
                            BackgroundColors = SetBackGroundColor(index, data).ToArray(),
                            Options = itemConditon.Options,
                        };
                        this.Items.Add(item);
                        break;
                    case "doughnut":
                        item = new ChartItem(data)
                        {
                            Label = itemConditon.DataName,
                            BackgroundColors = SetBackGroundColorOrder(data).ToArray(),
                            Options = itemConditon.Options,
                        };
                        this.Items.Add(item);
                        break;
                    default: 
                        break;
                }
            }
        }

        /// <summary>
        /// ラベルデータ作成
        /// </summary>
        /// <returns>ラベル文字列リスト</returns>
        public List<string> CreateLabels()
        {
            var labels = new List<string>();

            switch (_chartConditions.LabelT)
            {
                case LabelType.day:
                    DateTime indexDate = _chartConditions.StartDate;
                    while (indexDate < _chartConditions.EndDate)
                    {
                        labels.Add("\"" + indexDate.ToString("MM/dd") + "\"");
                        indexDate = indexDate.AddDays(1);
                    }
                    break;
                case LabelType.camera:
                    var cameraNumbers = Select.CameraNumbers();
                    foreach (var cameraNumber in cameraNumbers)
                    {
                        labels.Add("\"" +"Camera"+ cameraNumber.ToString() + "\"");
                    }
                    break;
            }
            return labels;
        }

        /// <summary>
        /// 日付ごとのアイテムデータ作成
        /// </summary>
        /// <param name="dataName">データの種類</param>
        /// <returns>アイテムデータリスト</returns>
        private List<int> CreateDataByDate(string dataName)
        {
            var data = new List<int>();

            DateTime indexDate = _chartConditions.StartDate;
            while(indexDate < _chartConditions.EndDate)
            {
                var dateInspResult = Select.InspectResultWhereTime(indexDate, indexDate.AddDays(1));
                if(dateInspResult != null)
                {
                    int count = 0;
                    switch(dataName)
                    {
                        case "OK数":
                            Func<InspectResult, bool> isOk = x => x.IsOK;
                            count = Count<InspectResult>(dateInspResult, isOk);
                            break;
                        case "NG数":
                            Func<InspectResult, bool> isNg = x => !x.IsOK;
                            count = Count<InspectResult>(dateInspResult, isNg);
                            break;
                    }
                    data.Add(count);
                }
                indexDate = indexDate.AddDays(1);
            }

            return data;
        }

        /// <summary>
        /// カメラごとのアイテムデータ作成
        /// </summary>
        /// <param name="dataName">データの種類</param>
        /// <returns>アイテムデータリスト</returns>
        private List<int> CreateDataByCamera(string dataName)
        {
            var data = new List<int>();
            var cameraCount = Select.CameraNumbers();

            foreach (var camera in cameraCount)
            {
                var targetInspResult = Select.InspectResultWhereCamera(camera, _chartConditions.StartDate, _chartConditions.EndDate);

                int count = 0;
                switch (dataName)
                {
                    case "OK数":
                        Func<InspectResult, bool> isOk = x => x.IsOK;
                        count = Count<InspectResult>(targetInspResult, isOk);
                        break;
                    case "NG数":
                        Func<InspectResult, bool> isNg = x => !x.IsOK;
                        count = Count<InspectResult>(targetInspResult, isNg);
                        break;
                }
                data.Add(count);
            }

            return data;
        }

        /// <summary>
        /// 同じ色のColorリストを取得する。
        /// </summary>
        /// <param name="accentColorNumber">アクセントカラー番号</param>
        /// <param name="data">データ</param>
        /// <returns>Colorリスト</returns>
        private List<Color> SetBackGroundColor(int accentColorNumber, int[] data)
        {
            var colors = new List<Color>();

            foreach (var datum in data)
            {
                colors.Add(AppColors.AccentColors[accentColorNumber]);
            }
            return colors;
        }

        /// <summary>
        /// アクセントカラーを順番にリスト化したものを取得する。
        /// </summary>
        /// <param name="data">データ</param>
        /// <returns>Colorリスト</returns>
        private List<Color> SetBackGroundColorOrder(int[] data)
        {
            var colors = new List<Color>();

            for(int i=0; i<data.Length; i++)
            {
                var num = i%AppColors.AccentColors.Length;
                colors.Add(AppColors.AccentColors[num]);
            }
            return colors;
        }

        #endregion

        #region ヘルパーメソッド
        /// <summary>
        /// 指定された判定基準を満たすものの要素数を数えます。
        /// </summary>
        /// <typeparam name="T">判定対象とするオブジェクトの型を指定します。</typeparam>
        /// <param name="enumerator">判定対象とするオブジェクトのコレクションを指定します。</param>
        /// <param name="predicate">判定処理を指定します。</param>
        /// <returns>判定基準を満たす要素数を返します。</returns>
        private static int Count<T>(IEnumerable<T> enumerator, Func<T, bool> predicate)
        {
            int count = 0;
            foreach (T item in enumerator)
            {
                if (predicate(item))
                    count++;
            }
            return count;
        }
        #endregion


    }
}
