using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspGraph;
using Microsoft.EntityFrameworkCore;

namespace InspGraph.Operator
{
    /// <summary>
    /// データベースからデータを読み込むクラスです
    /// </summary>
    public class Select : IDisposable
    {
        private static InspectionDataContext _db;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        static Select()
        {
            _db = new InspectionDataContext();
        }
        #region InspectResult関係
        /// <summary>
        /// 検査結果を全て取得
        /// </summary>
        /// <returns>検査結果</returns>
        public static IEnumerable<InspectResult> InspectResultAll()
        {
            return _db.InspectResults;
        }

        /// <summary>
        /// ID条件から検査結果を取得します。
        /// </summary>
        /// <param name="lowerValue">下限値</param>
        /// <param name="upperValue">上限値</param>
        /// <returns>条件範囲内の検査結果データリスト</returns>
        public static IEnumerable<InspectResult> InspectResultWhereId(int lowerValue,int upperValue)
        {
            return _db.InspectResults.Where(i => (lowerValue <= i.InspectResultId) && (i.InspectResultId <= upperValue));
        }

        /// <summary>
        /// 検査時間条件から検査結果を取得します。
        /// </summary>
        /// <param name="startTime">開始日時</param>
        /// <param name="endTime">終了日時</param>
        /// <returns>指定範囲内の検査結果データリスト</returns>
        public static IEnumerable<InspectResult> InspectResultWhereTime(DateTime startTime, DateTime endTime)
        {
            return _db.InspectResults.Where(i => (startTime <= i.InspTime) && (i.InspTime <= endTime));
        }

        /// <summary>
        /// 指定のカメラ番号と検査時間の検査結果を取得します。
        /// </summary>
        /// <param name="cameraNumber">カメラ番号</param>
        /// <param name="startTime">開始日時</param>
        /// <param name="endTime">終了日時</param>
        /// <returns></returns>
        public static IEnumerable<InspectResult> InspectResultWhereCamera(int cameraNumber, DateTime startTime, DateTime endTime)
        {
            return _db.InspectResults.Where(i => (startTime <= i.InspTime) && (i.InspTime <= endTime) && (i.CameraNo == cameraNumber));
        }

        /// <summary>
        /// IDで検査結果を取得します。
        /// </summary>
        /// <param name="equalValue"></param>
        /// <returns>指定IDの検査結果</returns>
        public static InspectResult? InspectResultWhereId(int equalValue)
        {
            try {
                return InspectResultWhereId(equalValue, equalValue).First();
            } catch
            {
                return null;
            }
        }

        /// <summary>
        /// カメラの番号を取得します。
        /// </summary>
        /// <returns>カメラ番号</returns>
        public static IEnumerable<int> CameraNumbers()
        {
            var list = new List<int>();
            foreach(var result in _db.InspectResults)
            {
                if(!list.Contains(result.CameraNo))
                {
                    list.Add(result.CameraNo);
                }
            }
            return list;
        }

        #endregion


        #region WorkData関係
        public static IEnumerable<WorkData> WorkDataAll()
        {
            return _db.WorkDatas;
        }

        public static IEnumerable<WorkData> WorkDataWhereId(int lowerValue, int upperValue)
        {
            return _db.WorkDatas.Where(w => (lowerValue <= w.WorkDataId) && (w.WorkDataId <= upperValue));
        }

        public static WorkData? WorkDataWhereId(int equalValue)
        {
            try
            {
                return WorkDataWhereId(equalValue, equalValue).First();
            }
            catch
            {
                return null;
            }
        }


        #endregion


        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
