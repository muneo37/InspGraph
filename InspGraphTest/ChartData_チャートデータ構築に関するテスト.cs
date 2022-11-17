using InspGraph;
using InspGraph.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InspGraphTest
{
    [TestClass]
    public class ChartData_�`���[�g�f�[�^�\�z�Ɋւ���e�X�g
    {
        List<InspectResult> _results = new List<InspectResult>();
        ChartConditions _conditions;

        [TestInitialize]
        public void �`���[�g�f�[�^�\�z�Ɋւ���e�X�g������()
        {          
        }

        [TestMethod]
        public void ���t���x��_OK�J�E���g��_�`���[�g�f�[�^���\�z����e�X�g()
        {
            _conditions.LabelT = (int)LabelType.day;
            _conditions.StartDate = DateTime.Parse("2022/11/08");
            _conditions.EndDate = DateTime.Parse("2022/11/14");
            _conditions.ItemConditions = new List<ChartItemConditions> {
                new ChartItemConditions{DataName = "OK��", BackGroundColor = AppColors.AccentColorBlue},
                };

            //���t���x���f�[�^
            var chartData = new ChartData(_conditions);

            if (chartData.Items != null)
            {
                foreach (var item in chartData.Items)
                {
                    var chartString = item.ToString();
                    Assert.AreEqual(chartString, "{\"label\": \"OK��\", \"data\": [5, 7, 3, 10, 8, 9], \"backgroundColor\": \"rgba(114, 125, 242, 1)\"}");
                }
            }
            else
            {
                Assert.Fail("�f�[�^�x�[�X�Ƀf�[�^������܂���B");
            }

        }

        [TestMethod]
        public void ���t���x��_NG�J�E���g��_�`���[�g�f�[�^���\�z����e�X�g()
        {
            _conditions.LabelT = (int)LabelType.day;
            _conditions.StartDate = DateTime.Parse("2022/11/08");
            _conditions.EndDate = DateTime.Parse("2022/11/14");
            _conditions.ItemConditions = new List<ChartItemConditions> {
                            new ChartItemConditions{DataName = "NG��", BackGroundColor = AppColors.AccentColorPink},
                            };

            //���t���x���f�[�^
            var chartData = new ChartData(_conditions);

            if (chartData.Items != null)
            {
                foreach (var item in chartData.Items)
                {
                    var chartString = item.ToString();
                    Assert.AreEqual(chartString, "{\"label\": \"NG��\", \"data\": [5, 8, 4, 10, 9, 10], \"backgroundColor\": \"rgba(249, 94, 126, 1)\"}");
                }
            }
            else
            {
                Assert.Fail("�f�[�^�x�[�X�Ƀf�[�^������܂���B");
            }

        }
    }
}