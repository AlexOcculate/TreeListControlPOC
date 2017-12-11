using System;
using System.Data;
using System.Linq;
using DevExpress.XtraTreeList.Columns;

namespace DataSetTest
{
    public class Config : BaseTable
    {
        public const string TABLE_NAME = "Config";

        public Config(string filePathName, string xmlNamespace = null, string xmlPrefix = null, string tableName = TABLE_NAME)
            : base(filePathName, xmlNamespace, xmlPrefix, tableName)
        {
        }

        public new void CreateBuiltInDataValues()
        {
            const object URI = null;
            const object PVW = null;
            const object DSC = null;
            DateTime now = DateTime.Now;
            this.Rows.Add(now, -1, -1, false, 1000, "ROOT", URI, PVW, DSC);
            this.Rows.Add(now, 10, -1, false, 2000, "Sample Folder", URI, PVW, DSC);
            this.Rows.Add(now, 15, 10, false, 4000, "Connection III", URI, PVW, DSC);
            //
            this.Rows.Add(now, 20, -1, false, 3000, "DataStores", URI, PVW, DSC);
            this.Rows.Add(now, 30, 20, false, 2000, "Sample Folder", URI, PVW, DSC);
            this.Rows.Add(now, 35, 30, false, 4000, "Connection", URI, PVW, DSC);
            this.Rows.Add(now, 37, 20, false, 4000, "Connection II", URI, PVW, DSC);
            //
            this.Rows.Add(now, 40, -1, false, 3000, "DataSource", URI, PVW, DSC);
            this.Rows.Add(now, 50, 40, false, 2000, "Sample Folder", URI, PVW, DSC);
            //
            this.Rows.Add(now, 60, -1, false, 3000, "DataTarget", URI, PVW, DSC);
            this.Rows.Add(now, 70, 60, false, 2000, "Sample Folder", URI, PVW, DSC);
        }
    }
}
