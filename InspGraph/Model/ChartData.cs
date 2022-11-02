using InspGraph.Operator;
using System.Drawing;

namespace InspGraph.Model
{
    public class ChartData
    {
        ChartConditions _chartConditions;

        public ChartData(ChartConditions condition)
        {
            _chartConditions = condition;
        }

        private IEnumerable<ChartItem>? _items;
        public IEnumerable<ChartItem>? Items
        {
            get => this._items;
        }

        private List<string> CreateLabels(int labelType)
        {

            return new List<string>();
        }


    }
}
