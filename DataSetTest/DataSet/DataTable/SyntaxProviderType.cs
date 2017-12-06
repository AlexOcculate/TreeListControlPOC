using System;
using System.Linq;

namespace DataSetTest
{
    public class SyntaxProviderType : BaseTable
    {
        public const string TABLE_NAME = "SyntaxProviderType";
        //
        public SyntaxProviderType(string filePathName, string xmlNamespace = null, string xmlPrefix = null, string tableName = TABLE_NAME)
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
            this.Rows.Add(now, 1000, -1, fldr, tp, "Auto", URI, PVW, DSC);
            this.Rows.Add(now, 1100, -1, fldr, tp, "Generic", URI, PVW, DSC);
            this.Rows.Add(now, 1200, -1, fldr, tp, "ANSI SQL-2003", URI, PVW, DSC);
            this.Rows.Add(now, 1300, -1, fldr, tp, "ANSI SQL-89", URI, PVW, DSC);
            this.Rows.Add(now, 1400, -1, fldr, tp, "ANSI SQL-92", URI, PVW, DSC);
            this.Rows.Add(now, 1500, -1, fldr, tp, "Firebird 1.0", URI, PVW, DSC);
            this.Rows.Add(now, 1600, -1, fldr, tp, "Firebird 1.5", URI, PVW, DSC);
            this.Rows.Add(now, 1700, -1, fldr, tp, "Firebird 2.0", URI, PVW, DSC);
            this.Rows.Add(now, 1800, -1, fldr, tp, "Firebird 2.5", URI, PVW, DSC);
            this.Rows.Add(now, 1900, -1, fldr, tp, "IBM DB2", URI, PVW, DSC);
            this.Rows.Add(now, 2000, -1, fldr, tp, "IBM Informix 10", URI, PVW, DSC);
            this.Rows.Add(now, 2100, -1, fldr, tp, "IBM Informix 8", URI, PVW, DSC);
            this.Rows.Add(now, 2200, -1, fldr, tp, "IBM Informix 9", URI, PVW, DSC);
            this.Rows.Add(now, 2300, -1, fldr, tp, "MS Access 2000 (MS Jet 4.0)", URI, PVW, DSC);
            this.Rows.Add(now, 2400, -1, fldr, tp, "MS Access 2003 (MS Jet 4.0)", URI, PVW, DSC);
            this.Rows.Add(now, 2500, -1, fldr, tp, "MS Access 97 (MS Jet 3.0)", URI, PVW, DSC);
            this.Rows.Add(now, 2600, -1, fldr, tp, "MS Access XP (MS Jet 4.0)", URI, PVW, DSC);
            this.Rows.Add(now, 2700, -1, fldr, tp, "MS SQL Server 2000", URI, PVW, DSC);
            this.Rows.Add(now, 2800, -1, fldr, tp, "MS SQL Server 2005", URI, PVW, DSC);
            this.Rows.Add(now, 2900, -1, fldr, tp, "MS SQL Server 2008", URI, PVW, DSC);
            this.Rows.Add(now, 3000, -1, fldr, tp, "MS SQL Server 2012", URI, PVW, DSC);
            this.Rows.Add(now, 3100, -1, fldr, tp, "MS SQL Server 2014", URI, PVW, DSC);
            this.Rows.Add(now, 3200, -1, fldr, tp, "MS SQL Server 7", URI, PVW, DSC);
            this.Rows.Add(now, 3300, -1, fldr, tp, "MS SQL Server Compact Edition", URI, PVW, DSC);
            this.Rows.Add(now, 3400, -1, fldr, tp, "MySQL 3.xx", URI, PVW, DSC);
            this.Rows.Add(now, 3500, -1, fldr, tp, "MySQL 4.0", URI, PVW, DSC);
            this.Rows.Add(now, 3600, -1, fldr, tp, "MySQL 4.1", URI, PVW, DSC);
            this.Rows.Add(now, 3700, -1, fldr, tp, "MySQL 5.0", URI, PVW, DSC);
            this.Rows.Add(now, 3800, -1, fldr, tp, "Oracle 10", URI, PVW, DSC);
            this.Rows.Add(now, 3900, -1, fldr, tp, "Oracle 11", URI, PVW, DSC);
            this.Rows.Add(now, 4000, -1, fldr, tp, "Oracle 7", URI, PVW, DSC);
            this.Rows.Add(now, 4100, -1, fldr, tp, "Oracle 8", URI, PVW, DSC);
            this.Rows.Add(now, 4200, -1, fldr, tp, "Oracle 9", URI, PVW, DSC);
            this.Rows.Add(now, 4300, -1, fldr, tp, "PostgreSQL", URI, PVW, DSC);
            this.Rows.Add(now, 4400, -1, fldr, tp, "SQLite", URI, PVW, DSC);
            this.Rows.Add(now, 4500, -1, fldr, tp, "Sybase ASE", URI, PVW, DSC);
            this.Rows.Add(now, 4600, -1, fldr, tp, "Sybase SQL Anywhere", URI, PVW, DSC);
            this.Rows.Add(now, 4700, -1, fldr, tp, "Teradata", URI, PVW, DSC);
            this.Rows.Add(now, 4800, -1, fldr, tp, "VistaDB", URI, PVW, DSC);
        }
    }
}
