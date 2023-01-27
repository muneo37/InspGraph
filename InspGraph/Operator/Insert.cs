using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspGraph.Operator
{
    public class Insert : IDisposable
    {
        private static InspectionDataContext _db;

        static Insert()
        {
            _db = new InspectionDataContext();
        }

        public static void InsertInspectResult(InspectResult inspectResult)
        {
            _db.Update(inspectResult);
            //_db.InspectResults.Add(inspectResult);
            _db.SaveChanges();
        }

        public static void InsertWorkData(WorkData workData) 
        {
            _db.Update(workData);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
