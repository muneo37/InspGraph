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
        private static InspectionDatasContext _db;

        static Select()
        {
            _db = new InspectionDatasContext();
        }
        #region InspectResult関係
        public static IEnumerable<InspectResult> InspectResultAll()
        {
            return _db.InspectResults;
        }

        public static IEnumerable<InspectResult> InspectResultWhareId(int lowerValue,int upperValue)
        {
            return _db.InspectResults.Where(i => (lowerValue <= i.InspectResultId) && (i.InspectResultId <= upperValue));
        }

        public static InspectResult? InspectResultWhareId(int equalValue)
        {
            try {
                return InspectResultWhareId(equalValue, equalValue).First();
            } catch
            {
                return null;
            }
        }
        #endregion

        #region User関係
        /// <summary>
        /// すべてのユーザーリストを取得します
        /// </summary>
        /// <returns></returns>
        public static int UserAll()
        //public static IEnumerable<User> UserAll()
        {
            IEnumerable<User> test = _db.Users;
            return 5;
        }

        /// <summary>
        /// Idの上限値下限値を設定し、条件にあったUserリストを取得します
        /// </summary>
        /// <param name="lowerValue">下限値</param>
        /// <param name="upperValue">上限値</param>
        /// <returns>Userリスト</returns>
        public static IEnumerable<User> UserWhareId(int lowerValue, int upperValue)
        {
            return _db.Users.Where(u => (lowerValue <= u.UserId) && (u.UserId <= upperValue));
        }

        /// <summary>
        /// Idを指定し、条件にあったUserを取得します
        /// </summary>
        /// <param name="equalValue">検索するId値</param>
        /// <returns>User</returns>
        public static User? UserWhareId(int equalValue)
        {
            try
            {
                return UserWhareId(equalValue, equalValue).First();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ユーザー名を指定し、条件に合致したUserリストを取得します
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<User> UserWhareName(string name)
        {
            return _db.Users.Where(u => u.Name == name);
        }

        /// <summary>
        /// 権限の上限値下限値を設定し、条件にあったUserリストを取得します
        /// </summary>
        /// <param name="lowerValue">下限値</param>
        /// <param name="upperValue">上限値</param>
        /// <returns>Userリスト</returns>
        public static IEnumerable<User> UserWhareAuthority(int lowerValue, int upperValue)
        {
            return _db.Users.Where(u => (lowerValue <= u.Authority) && (u.Authority <= upperValue));
        }

        /// <summary>
        /// 権限を指定し、条件にあったUserを取得します
        /// </summary>
        /// <param name="equalValue">検索する権限</param>
        /// <returns>User</returns>
        public static User? UserWhareAuthority(int equalValue)
        {
            try
            {
                return UserWhareAuthority(equalValue, equalValue).First();
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region WorkData関係
        public static IEnumerable<WorkData> WorkDataAll()
        {
            return _db.WorkDatas;
        }

        public static IEnumerable<WorkData> WorkDataWhareId(int lowerValue, int upperValue)
        {
            return _db.WorkDatas.Where(w => (lowerValue <= w.WorkDataId) && (w.WorkDataId <= upperValue));
        }

        public static WorkData? WorkDataWhareId(int equalValue)
        {
            try
            {
                return WorkDataWhareId(equalValue, equalValue).First();
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
