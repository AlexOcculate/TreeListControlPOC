using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public sealed class DataStoreTechnology
    {
        public static readonly DataStoreTechnology ACCESS__MICROSOFT = new DataStoreTechnology(1, "Access (Microsoft)");
        //public static readonly DataStoreTechnology ACCESS_MULTI_USER_THREAD_SAFE__MICROSOFT = new DataStoreTechnology(2, "Access Multi-User Thread Safe (Microsoft)");
        //public static readonly DataStoreTechnology ADAPTIVE_SERVER_ANYWHERE__SYBASE = new DataStoreTechnology(3, "Adaptive Server AnyWhere (Sybase)");
        //public static readonly DataStoreTechnology ADAPTIVE_SERVER_ENTERPRISE__SYBASE = new DataStoreTechnology(4, "Adaptive Server Enterprise (Sybase)");
        //public static readonly DataStoreTechnology ADVANTAGE_DATABASE_SERVER__SAP = new DataStoreTechnology(5, "Advantage Database Server (SAP)");
        // AMAZON REDSHIFT
        //public static readonly DataStoreTechnology DB2__IBM = new DataStoreTechnology(6, "DB2 (IBM)");
        //public static readonly DataStoreTechnology FIREBIRD = new DataStoreTechnology(7, "Firebird");
        // GOOGLE BIGQUERY
        //public static readonly DataStoreTechnology INFORMIX__IBM = new DataStoreTechnology(8, "Informix (IBM)");
        //public static readonly DataStoreTechnology MYSQL = new DataStoreTechnology(9, "MySQL");
        //public static readonly DataStoreTechnology NEXUSDB = new DataStoreTechnology(10, "NexusDB");
        //public static readonly DataStoreTechnology ODBC = new DataStoreTechnology(11, "ODBC");
        //public static readonly DataStoreTechnology OLEDB = new DataStoreTechnology(12, "OLEDB");
        //public static readonly DataStoreTechnology ORACLE = new DataStoreTechnology(13, "Oracle");
        //public static readonly DataStoreTechnology ORACLE_ODP = new DataStoreTechnology(14, "Oracle ODP");
        //public static readonly DataStoreTechnology ORACLE_ODP_MANAGED = new DataStoreTechnology(15, "Oracle ODP Managed");
        //public static readonly DataStoreTechnology PERVASIVE_ACTIAN = new DataStoreTechnology(16, "PervasiveSQL (Actian)");
        //public static readonly DataStoreTechnology POSTGRESQL = new DataStoreTechnology(17, "PostgreSQL");
        //public static readonly DataStoreTechnology SQL_CE__MICROSOFT = new DataStoreTechnology(18, "SQL CE (Microsoft)");
        public static readonly DataStoreTechnology SQLITE = new DataStoreTechnology(19, "SQLite");
        public static readonly DataStoreTechnology SQLSERVER__MICROSOFT = new DataStoreTechnology(20, "SQL Server (Microsoft)");
        //public static readonly DataStoreTechnology VISTADB = new DataStoreTechnology(21, "VistaDB");
        //public static readonly DataStoreTechnology VISTADB_5 = new DataStoreTechnology(22, "VistaDB 5");

        private readonly int id;
        private readonly string name;

        DataStoreTechnology(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }

        public static DataStoreTechnology[] AsArray
        {
            get
            {
                return new DataStoreTechnology[]
                {
                    ACCESS__MICROSOFT,
                    //ACCESS_MULTI_USER_THREAD_SAFE__MICROSOFT,
                    //ADAPTIVE_SERVER_ANYWHERE__SYBASE,
                    //ADAPTIVE_SERVER_ENTERPRISE__SYBASE,
                    //ADVANTAGE_DATABASE_SERVER__SAP,
                    // AMAZON REDSHIFT,
                    //DB2__IBM,
                    //FIREBIRD,
                    // GOOGLE BIGQUERY
                    //INFORMIX__IBM,
                    //MYSQL,
                    //NEXUSDB,
                    //ODBC,
                    //OLEDB,
                    //ORACLE,
                    //ORACLE_ODP,
                    //ORACLE_ODP_MANAGED,
                    //PERVASIVE_ACTIAN,
                    //POSTGRESQL,
                    SQLITE,
                    //SQL_CE__MICROSOFT,
                    SQLSERVER__MICROSOFT,
                    //VISTADB,
                    //VISTADB_5
                };

            }
        }

        public static IEnumerable<DataStoreTechnology> AsEnumerable
        {
            get
            {
                yield return ACCESS__MICROSOFT;
                //yield return ADVANTAGE_DATABASE_SERVER__SAP;
                //yield return ADAPTIVE_SERVER_ANYWHERE__SYBASE;
                //yield return ADAPTIVE_SERVER_ENTERPRISE__SYBASE;
                // AMAZON REDSHIFT
                //yield return DB2__IBM;
                //yield return FIREBIRD;
                // GOOGLE BIGQUERY
                //yield return INFORMIX__IBM;
                //yield return ACCESS_MULTI_USER_THREAD_SAFE__MICROSOFT;
                //yield return MYSQL;
                //yield return NEXUSDB;
                //yield return ODBC;
                //yield return OLEDB;
                //yield return ORACLE;
                //yield return ORACLE_ODP;
                //yield return ORACLE_ODP_MANAGED;
                //yield return PERVASIVE_ACTIAN;
                //yield return POSTGRESQL;
                yield return SQLITE;
                //yield return SQL_CE__MICROSOFT;
                yield return SQLSERVER__MICROSOFT;
                //yield return VISTADB_5;
                //yield return VISTADB;
            }
        }

        public int Id { get { return id; } }

        public string Name { get { return name; } }
    }
}
