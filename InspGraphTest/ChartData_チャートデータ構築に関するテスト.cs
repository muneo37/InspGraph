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
            //�\�z�����ݒ�
            _conditions.ChartType = "bar";
            _conditions.Label = (int)LabelType.day;
            _conditions.StartDate = DateTime.Parse("2022/11/01");
            _conditions.EndDate = DateTime.Parse("2022/11/14");
        }

        [TestMethod]
        public void �`���[�g�f�[�^���\�z����e�X�g()
        {
            //���t���x���f�[�^
            var chartData = new ChartData(_conditions);

            if (chartData.Items != null)
            {
                var chartString = chartData.Items.ToString();
                Assert.AreEqual(chartString, "");
            }
            else
            {
                Assert.Fail("�f�[�^�x�[�X�Ƀf�[�^������܂���B");
            }

        }
    }
}