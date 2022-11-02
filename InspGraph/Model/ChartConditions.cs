namespace InspGraph.Model
{
    /// <summary>
    /// Chart構築条件構造体
    /// </summary>
    public struct ChartConditions
    {
        public string ChartType { get; set; }
        public int Label { get; set; }
        public List<int> Data { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<int> EnableCamera { get; set; }
        public List<int> EnableProduct { get; set; }
        public List<string> EnableDefect { get; set; }
    }

    /// <summary>
    /// グラフ軸データの種類
    /// </summary>
    public enum LabelType
    {
        day,
        camera,
        product,
        defect,
    }

    /// <summary>
    /// グラフデータの種類
    /// </summary>
    public enum DataType
    {
        okCount,
        ngCount,
        ngRatio,
        ngCameraCount,
        ngDefectCount,
        ngCameraRatio,
        ngDefectRatio,
    }
}
