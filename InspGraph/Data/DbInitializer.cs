using InspGraph.Operator;

namespace InspGraph.Data
{
    public static class DbInitializer
    {
        public static void Initialize(InspectionDataContext context)
        {
            WorkData workData = new WorkData();
            workData.WorkDataId = 1;
            workData.WorkDataName= "Test";
            workData.CreateDate = DateTime.Parse("2023/01/27 13:27:00");
            Insert.InsertWorkData(workData);

            for (int i = 0; i < 10; i++)
            {
                InspectResult result = new InspectResult();
                result.InspectResultId = i;
                result.WorkDataId = 1;
                result.WorkData = Select.WorkDataWhereId(result.WorkDataId);
                result.CameraNo = 1;
                result.PCNo = 1;
                result.Count = i;
                result.IsOK = false;
                result.DefectDetail = "ラベル無し";
                result.InspTime = DateTime.Parse("2023/01/27 13:55:00");
                Insert.InsertInspectResult(result);
            }

            for (int i = 10; i < 20; i++)
            {
                InspectResult result = new InspectResult();
                result.InspectResultId = i;
                result.WorkDataId = 1;
                result.WorkData = Select.WorkDataWhereId(result.WorkDataId);
                result.CameraNo = 1;
                result.PCNo = 1;
                result.Count = i;
                result.IsOK = true;
                result.DefectDetail = "";
                result.InspTime = DateTime.Parse("2023/01/27 13:55:00");
                Insert.InsertInspectResult(result);
            }


        }

    }
}
