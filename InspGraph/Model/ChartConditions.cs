using System.Drawing;

namespace InspGraph.Model
{
    /// <summary>
    /// Chart構築条件構造体
    /// </summary>
    public struct ChartConditions
    {
        public string ChartType { get; set; }
        public LabelType LabelT { get; set; }
        public List<ChartItemConditions> ItemConditions { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<int> EnableCamera { get; set; }
        public List<int> EnableProduct { get; set; }
        public List<string> EnableDefect { get; set; }
    }

    /// <summary>
    /// グラフ軸データの種類
    /// </summary>
    public enum LabelType
    {
        day,    //日付
        time,   //時間
        camera, //カメラ
        product,//品種
        defect, //欠陥
    }

    /// <summary>
    /// ChartItem条件
    /// </summary>
    public struct ChartItemConditions
    {
        public string DataName { get; set; }
        public string Options { get; set; }
    }
}
