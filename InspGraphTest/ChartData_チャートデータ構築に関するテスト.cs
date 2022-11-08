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
            _conditions.LabelT = (int)LabelType.day;
            _conditions.StartDate = DateTime.Parse("2022/11/08");
            _conditions.EndDate = DateTime.Parse("2022/11/14");
            _conditions.DataT = new List<DataType> { DataType.okCount, DataType.ngCount };
        }

        [TestMethod]
        public void �`���[�g�f�[�^���\�z����e�X�g()
        {
            //���t���x���f�[�^
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
                Assert.Fail("�f�[�^�x�[�X�Ƀf�[�^������܂���B");
            }

        }
    }
}