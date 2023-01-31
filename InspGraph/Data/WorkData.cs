﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspGraph
{
    /// <summary>
    /// 品種データを表すクラスです
    /// </summary>
    public class WorkData
    {
        /// <summary>
        /// 品種識別子を設定または取得します
        /// </summary>
        [Key]
        public int WorkDataId { get; set; }

        /// <summary>
        /// 品種名を設定または取得します
        /// </summary>
        public string WorkDataName { get; set; } = string.Empty;

        /// <summary>
        /// 品種作成日時を設定または取得します
        /// </summary>
        [Column(TypeName = "timestamp without time zone")]
        public DateTime CreateDate { get; set; }

    }
}
