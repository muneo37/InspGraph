using InspGraph;
using InspGraph.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InspGraphTest
{
    [TestClass]
    public class ChartData_チャートデータ構築に関するテスト
    {
        List<InspectResult> _results = new List<InspectResult>();
        ChartConditions _conditions;

        [TestInitialize]
        public void チャートデータ構築に関するテスト初期化()
        {
          
            //構築条件設定
            _conditions.ChartType = "bar";
            _conditions.LabelT = (int)LabelType.day;
            _conditions.StartDate = DateTime.Parse("2022/11/08");
            _conditions.EndDate = DateTime.Parse("2022/11/14");
            _conditions.DataT = new List<DataType> { DataType.okCount, DataType.ngCount };
        }

        [TestMethod]
        public void チャートデータを構築するテスト()
        {
            //日付ラベルデータ
            var chartData = new ChartData(_conditions);

            if (chartData.Items != null)
            {
                foreach (var item in chartData.Items)
                {
                    var chartString = item.ToString();
                    Assert.AreEqual(chartString, "");
                }
            }
            else
            {
                Assert.Fail("データベースにデータがありません。");
            }

        }
    }
}