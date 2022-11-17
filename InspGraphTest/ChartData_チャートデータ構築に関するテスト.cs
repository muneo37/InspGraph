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
        }

        [TestMethod]
        public void 日付ラベル_OKカウント数_チャートデータを構築するテスト()
        {
            _conditions.LabelT = (int)LabelType.day;
            _conditions.StartDate = DateTime.Parse("2022/11/08");
            _conditions.EndDate = DateTime.Parse("2022/11/14");
            _conditions.ItemConditions = new List<ChartItemConditions> {
                new ChartItemConditions{DataName = "OK数", BackGroundColor = AppColors.AccentColorBlue},
                };

            //日付ラベルデータ
            var chartData = new ChartData(_conditions);

            if (chartData.Items != null)
            {
                foreach (var item in chartData.Items)
                {
                    var chartString = item.ToString();
                    Assert.AreEqual(chartString, "{\"label\": \"OK数\", \"data\": [5, 7, 3, 10, 8, 9], \"backgroundColor\": \"rgba(114, 125, 242, 1)\"}");
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
            _conditions.ItemConditions = new List<ChartItemConditions> {
                            new ChartItemConditions{DataName = "NG数", BackGroundColor = AppColors.AccentColorPink},
                            };

            //日付ラベルデータ
            var chartData = new ChartData(_conditions);

            if (chartData.Items != null)
            {
                foreach (var item in chartData.Items)
                {
                    var chartString = item.ToString();
                    Assert.AreEqual(chartString, "{\"label\": \"NG数\", \"data\": [5, 8, 4, 10, 9, 10], \"backgroundColor\": \"rgba(249, 94, 126, 1)\"}");
                }
            }
            else
            {
                Assert.Fail("データベースにデータがありません。");
            }

        }
    }
}