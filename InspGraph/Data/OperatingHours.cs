using System.ComponentModel.DataAnnotations;

namespace InspGraph.Data
{
    public class OperatingHours
    {
        /// <summary>
        /// 識別子を設定または取得します。
        /// </summary>
        [Key]
        public DateTime ReciveSignalTime { get; set; }

        /// <summary>
        /// 信号種別を設定または取得します。
        /// </summary>
        public bool IsRunning { get; set; }

    }
}
