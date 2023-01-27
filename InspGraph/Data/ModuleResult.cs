using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspGraph.Data
{
    public class ModuleResult
    {
        /// <summary>
        /// モジュール結果Idを設定または取得します
        /// </summary>
        [Key]
        public int ModuleResultId { get; set; }

        /// <summary>
        /// 検査結果の識別子を設定または取得します。
        /// </summary>        
        [ForeignKey("InspResult")]
        public int InspResultId { get; set; }

        /// <summary>
        /// 検査結果を設定または取得します。
        /// </summary>
        public InspectResult InspResult { get; set; } = new InspectResult();

        /// <summary>
        /// データの名称を設定または取得します
        /// </summary> 
        public string DataName { get; set; } = string.Empty;

        /// <summary>
        /// モジュールの結果データを設定または取得します
        /// </summary>
        public double ModuleResultData { get; set; }
    }
}
