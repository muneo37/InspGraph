﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspGraph
{
    /// <summary>
    /// 検査結果を表すクラスです
    /// </summary>
    public class InspectResult
    {
        /// <summary>
        /// 識別子を設定または取得します
        /// </summary>
        [Key]
        public int InspectResultId { get; set; }

        /// <summary>
        /// 品種の識別子を取得または設定します
        /// </summary>
        [ForeignKey("WorkData")]
        public int WorkDataId { get; set; }

        /// <summary>
        /// 品種識を設定または取得します
        /// </summary>
        public WorkData WorkData { get; set; } = new WorkData();

        /// <summary>
        /// カメラNoを設定または取得します
        /// </summary>
        public int CameraNo { get; set; }

        /// <summary>
        /// PCNoを設定または取得します
        /// </summary>
        public int PCNo { get; set; }

        /// <summary>
        /// 検査カウントを設定または取得します
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 検査結果を設定または取得します
        /// true:OK false:NG
        /// </summary>
        public bool IsOK { get; set; }

        /// <summary>
        /// 欠陥詳細を設定または取得します
        /// </summary>
        public string DefectDetail { get; set; } = string.Empty;

        /// <summary>
        /// 検査した時間を設定または取得します
        /// </summary>
        [Column(TypeName = "timestamp without time zone")]
        public DateTime InspTime { get; set; }
    }
}
