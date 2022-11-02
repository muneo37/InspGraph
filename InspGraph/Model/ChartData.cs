using InspGraph.Operator;
using System.Drawing;

namespace InspGraph.Model
{
    public class ChartData
    {
        int[] OkData = { 10503, 9993, 5004, 12305, 7604, 9994, 4196,
                         12345, 6467, 8858, 1305, 3467, 7774, 3735};

        int[] NgData = { 30, 54, 65, 86, 44, 22, 16,
                         87, 64, 8, 1, 76, 77, 85};

        string[] label = { "\"5:00\"", "\"6:00\"", "\"8/12\"", "\"8/13\"", "\"8/14\"", "\"8/15\"", "\"8/16\"",
            "\"8/17\"", "\"8/18\"", "\"8/19\"", "\"8/20\"", "\"8/21\"", "\"8/22\"", "\"8/23\"" };


        public ChartData(ChartConditions condition)
        {
            IEnumerable<InspectResult> results = Select.InspectResultWhereId(3, 5);

            int count = results.ElementAt(0).Count;


            _items = new ChartItem[]
            {
                new ChartItem(OkData)
                {
                    Type = "bar",
                    Labels = label,
                    Label = "OK数",
                    BackgroundColor = Color.FromArgb(100, 94, 142, 134),
                    BorderColor = Color.FromArgb(255, 94, 142, 134),
                    BorderWidth = 1,
                },

                new ChartItem(NgData)
                {
                    Label = "NG数",
                    BackgroundColor = Color.FromArgb(100, 186, 64, 48),
                    BorderColor = Color.FromArgb(255, 186, 64, 48),
                    BorderWidth = 1,
                },

            };
        }

        private IEnumerable<ChartItem> _items;
        public IEnumerable<ChartItem> Items
        {
            get => this._items;
        }


    }
}
