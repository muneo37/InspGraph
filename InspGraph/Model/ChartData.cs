using InspGraph.Operator;
using System.Drawing;

namespace InspGraph.Model
{
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

            foreach(ChartItemConditions itemConditon in _chartConditions.ItemConditions)
            {
                ChartItem item = new ChartItem(CreateDataByDate(itemConditon.DataName).ToArray())
                {
                    Label = itemConditon.DataName,
                    BackgroundColor = itemConditon.BackGroundColor,
                };
                this.Items.Add(item);
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
