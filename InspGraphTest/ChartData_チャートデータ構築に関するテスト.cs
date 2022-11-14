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
            _conditions.ChartType = "bar";
        }

        [TestMethod]
        public void 日付ラベル_OKカウント数_チャートデータを構築するテスト()
        {
            _conditions.LabelT = (int)LabelType.day;
            _conditions.StartDate = DateTime.Parse("2022/11/08");
            _conditions.EndDate = DateTime.Parse("2022/11/14");
            _conditions.DataNames = new List<string> { "OK数" };

            //日付ラベルデータ
            var chartData = new ChartData(_conditions);

            if (chartData.Items != null)
            {
                foreach (var item in chartData.Items)
                {
                    var chartString = item.ToString();
                    Assert.AreEqual(chartString, "{\"label\": \"OK数\", \"data\": [5, 7, 3, 10, 8, 9], \"backgroundColor\": \"rgba(94, 142, 134, 0.39215686274509803)\", \"borderColor\": \"rgba(94, 142, 134, 1)\", \"borderWidth\": 1}");
                }
            }
            else
            {
                Assert.Fail("データベースにデータがありません。");
            }

        }

        [TestMethod]
        public void 日付ラベル_NGカウント数_チャートデータを構築するテスト()
        {
            _conditions.LabelT = (int)LabelType.day;
            _conditions.StartDate = DateTime.Parse("2022/11/08");
            _conditions.EndDate = DateTime.Parse("2022/11/14");
            _conditions.DataNames = new List<string> { "NG数" };

            //日付ラベルデータ
            var chartData = new ChartData(_conditions);

            if (chartData.Items != null)
            {
                foreach (var item in chartData.Items)
                {
                    var chartString = item.ToString();
                    Assert.AreEqual(chartString, "{\"label\": \"NG数\", \"data\": [5, 8, 4, 10, 9, 10], \"backgroundColor\": \"rgba(94, 142, 134, 0.39215686274509803)\", \"borderColor\": \"rgba(94, 142, 134, 1)\", \"borderWidth\": 1}");
                }
            }
            else
            {
                Assert.Fail("データベースにデータがありません。");
            }

        }
    }
}