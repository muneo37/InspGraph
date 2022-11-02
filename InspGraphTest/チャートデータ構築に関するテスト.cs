using InspGraph;

namespace InspGraphTest
{
    [TestClass]
    public class チャートデータ構築に関するテスト
    {
        List<InspectResult> _results = new List<InspectResult>();

        [TestInitialize]
        public void チャートデータ構築に関するテスト初期化()
        {
            //ユーザーデータ作成
            User takeshi = new User();
            takeshi.UserId = 1;
            takeshi.Name = "takeshi kitano";
            takeshi.Authority = 1;

            //品種データ作成
            WorkData fanta = new WorkData();
            fanta.UserId = 1;
            fanta.User = takeshi;
            fanta.WorkDataId = 1;
            fanta.WorkDataName = "fanta";

            //検査結果データ作成
            InspectResult result1 = new InspectResult();
            result1.InspectResultId = 1;
            result1.WorkDataId = 1;
            result1.WorkData = fanta;
            result1.CameraNo = 1;
            result1.PCNo = 1;
            result1.Count = 1;
            result1.IsOK = true;
            result1.InspTime = DateTime.Parse("2022/01/01 12:00:00");

            InspectResult result2 = new InspectResult();
            result2.InspectResultId = 2;
            result2.WorkDataId = 1;
            result2.WorkData = fanta;
            result2.CameraNo = 1;
            result2.PCNo = 1;
            result2.Count = 2;
            result2.IsOK = true;
            result2.InspTime = DateTime.Parse("2022/01/02 13:00:00");

            InspectResult result3 = new InspectResult();
            result3.InspectResultId = 3;
            result3.WorkDataId = 1;
            result3.WorkData = fanta;
            result3.CameraNo = 1;
            result3.PCNo = 1;
            result3.Count = 3;
            result3.IsOK = false;
            result3.InspTime = DateTime.Parse("2023/01/03 14:00:00");

            _results.Add(result1);
            _results.Add(result2);
            _results.Add(result3);

        }

        [TestMethod]
        public void ラベルデータを構築するテスト()
        {

        }
    }
}