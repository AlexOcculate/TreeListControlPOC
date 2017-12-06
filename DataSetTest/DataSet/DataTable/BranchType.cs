using System;
using System.Linq;

namespace DataSetTest
{
    public class BranchType : BaseTable
    {
        public const string TABLE_NAME = "BranchType";
        //
        public BranchType(string filePathName, string xmlNamespace = null, string xmlPrefix = null, string tableName = TABLE_NAME)
            : base(filePathName, xmlNamespace, xmlPrefix, tableName)
        {
        }
        public override void CreateBuiltInDataValues()
        {
            const bool fldr = false;
            const int tp = 0;
            const object URI = null;
            const object PVW = null;
            const object DSC = null;
            DateTime now = DateTime.Now;
            this.Rows.Add(now, 1000, -1, fldr, tp, "ROOT", URI, PVW, DSC);
            this.Rows.Add(now, 2000, -1, fldr, tp, "FOLDER", URI, PVW, DSC);
            this.Rows.Add(now, 3000, -1, fldr, tp, "DATASTORE", URI, PVW, DSC);
        }
    }
}
