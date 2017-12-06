using System;
using System.Data;
using System.Linq;

namespace DataSetTest
{
    public class ConfigDataSet
    {
        #region --- NAMES ---
        public const string PATH = @"D:\users\user01\source\repos\TreeListControlPOC\DataSetTest\";
        public const string PRVW = @"This is the[root] of al[branches]! Don't remove it!!!";
        //
        public const string CONFIG_FILE_NM_PREFIX = "config";
        public const string CONFIG_FILE_SCHEMA_SUFFIX = ".sch.xml";
        public const string CONFIG_FILE_DATAVALUES_SUFFIX = ".xml";
        public const string CONFIG_FILE_DIFFGRAM_SUFFIX = ".diff.xml";
        //
        public const string CONFIG_FILE_SCHEMA = PATH + CONFIG_FILE_NM_PREFIX + CONFIG_FILE_SCHEMA_SUFFIX;
        public const string CONFIG_DATAVALUE = PATH + CONFIG_FILE_NM_PREFIX + CONFIG_FILE_DATAVALUES_SUFFIX;
        public const string CONFIG_DIFFGRAM = PATH + CONFIG_FILE_NM_PREFIX + CONFIG_FILE_DIFFGRAM_SUFFIX;
        //
        public const string DATASET_NM = "CONFIG_DATASET";
        public const string DATASET_NAMESPACE = "y";
        public const string DATASET_PREFIX = "x";
        //
        public const string CONFIG_TBL_NM = "CONFIG";
        public const string DATASTORE_TBL_NM = "DATASTORE";
        //
        public const string ID_FIELD_NM = "ID";
        public const string PARENTID_FIELD_NM = "ParentID";
        public const string ISFOLDER_FIELD_NM = "IsFolder";
        public const string NAME_FIELD_NM = "Name";
        public const string PREVIEW_FIELD_NM = "Preview";
        public const string TYPE_FIELD_NM = "Type";
        public const string URI_FIELD_NM = "Uri";
        public const string CREATION_FIELD_NM = "Creation";
        #endregion
        //
        private DataSet ds = new DataSet();
        //
        public ConfigDataSet()
        {
            if (System.IO.File.Exists(CONFIG_FILE_SCHEMA))
            {
                this.ds.ReadXml(CONFIG_FILE_SCHEMA, XmlReadMode.Auto);
                return;
            }
            {
                ds.DataSetName = DATASET_NM;
                ds.Namespace = DATASET_NAMESPACE;
                ds.Prefix = DATASET_PREFIX;
                {
                    ds.Tables.Add(this.createConfigTable());
                 //   ds.Tables.Add(this.createDataStoreTable());
                }
            }
        }
        public void WriteXml()
        {
            this.ds.WriteXml(CONFIG_FILE_SCHEMA, XmlWriteMode.WriteSchema);
            //this.ds.ReadXml(CONFIG_FILE_SCHEMA, XmlReadMode.Auto);
            //
            //this.ds.WriteXml(CONFIG_DATAVALUE, XmlWriteMode.IgnoreSchema);
            //this.ds.WriteXml(CONFIG_DIFFGRAM, XmlWriteMode.DiffGram);
        }
        public DataTable getConfigTable()
        {
            return this.ds.Tables[CONFIG_TBL_NM];
        }
        public DataTable getDataStoreTable()
        {
            return this.ds.Tables[DATASTORE_TBL_NM];
        }

        private DataTable createConfigTableStructure(string tableName = null)
        {
            DataTable o = new DataTable();
            o.TableName = tableName;
            {
                o.Columns.Add(ID_FIELD_NM, typeof(int));
                o.Columns.Add(PARENTID_FIELD_NM, typeof(int));
                o.Columns.Add(ISFOLDER_FIELD_NM, typeof(bool));
                o.Columns.Add(NAME_FIELD_NM, typeof(string));
                o.Columns.Add(PREVIEW_FIELD_NM, typeof(string));
                o.Columns.Add(TYPE_FIELD_NM, typeof(string));
                o.Columns.Add(URI_FIELD_NM, typeof(string));
                o.Columns.Add(CREATION_FIELD_NM, typeof(DateTime));
            }
            return o;
        }

        private DataTable createConfigTable()
        {
            DataTable o = this.createConfigTableStructure(CONFIG_TBL_NM);
            {
                o.Rows.Add(-1, -1, false, "ROOT", PRVW, null, null, DateTime.Now);
                o.Rows.Add(1, -1, true, "DataStore", PRVW, "DataStore", null, DateTime.Now);
                {
                    o.Rows.Add(10000, 1, true, "Alex", "Alex Mello Occulate", null, null, DateTime.Now);
                    {
                        o.Rows.Add(10001, 10000, false, "Geraldo", "Geraldo Occulate", ConfigDataSet.DATASTORE_TBL_NM, null, DateTime.Now);
                        //o.Rows.Add(10001, 10000, false, "Geraldo", "Geraldo Occulate", null, null, DateTime.Now);
                        //o.Rows.Add(10002, 10000, false, "Eva", "Eva Mello Occulate", null, null, DateTime.Now);
                        //o.Rows.Add(10003, 10000, false, "Andre", "Andre Mello Occulate", null, null, DateTime.Now);
                        //o.Rows.Add(10004, 10000, false, "Fabiane", "Fabiane Mello Occulate", null, null, DateTime.Now);
                        //o.Rows.Add(10005, 10000, false, "Marcos", "Marcos Antonio Occulate", null, null, DateTime.Now);
                    }
                    //o.Rows.Add(20000, 1, true, "Simone", "Simone Licnerski Occulate", null, null, DateTime.Now);
                    //{
                    //    o.Rows.Add(20001, 20000, false, "Claudio", "Claudio Licnerski", null, null, DateTime.Now);
                    //    o.Rows.Add(20002, 20000, false, "Lucy", "Lucy de Almeida Licnerski", null, null, DateTime.Now);
                    //    o.Rows.Add(20003, 20000, false, "Fabio", "Fabio de Almeida Licnerski", null, null, DateTime.Now);
                    //}
                }
                o.Rows.Add(2, -1, true, "DataSource", PRVW, "DataSource", PATH + "DataSource.xml", DateTime.Now);
                o.Rows.Add(3, -1, true, "DataTarget", PRVW, "DataTarget", PATH + "DataTarget.xml", DateTime.Now);
            }
            return o;
        }

    }
}


//public const string TECHNOLOGY_ID_PROP_NAME = "TechnologyId";
//public const string TECHNOLOGY_ID_CAPTION_NAME = "Technology Id";
////
//public const string TECHNOLOGY_NAME_PROP_NAME = "TechnologyName";
//public const string TECHNOLOGY_NAME_CAPTION_NAME = "Technology Name";
////
//public const string METADATA_PROVIDER_PROP_NAME = "MetadataProvider";
//public const string METADATA_PROVIDER_CAPTION_NAME = "Metadata Provider";
////
//public const string SYNTAX_PROVIDER_ID_PROP_NAME = "SyntaxProviderId";
//public const string SYNTAX_PROVIDER_ID_CAPTION_NAME = "Syntax Provider Id";
////
//public const string SYNTAX_PROVIDER_NAME_PROP_NAME = "SyntaxProviderName";
//public const string SYNTAX_PROVIDER_NAME_CAPTION_NAME = "Syntax Provider Name";
////
//public const string CONNECTION_STRING_PROP_NAME = "ConnectionString";
//public const string CONNECTION_STRING_CAPTION_NAME = "ConnectionString";
////
//public const string CONNECTION_TESTED_PROP_NAME = "ConnectionTested";
//public const string SERVER_PROP_NAME = "Server";
////
//public const string AUTHENTICATION_TYPE_ID_PROP_NAME = "AuthenticationTypeId";
//public const string AUTHENTICATION_TYPE_ID_CAPTION_NAME = "Authentication Type Id";
////
//public const string AUTHENTICATION_TYPE_NAME_PROP_NAME = "AuthenticationTypeName";
//public const string AUTHENTICATION_TYPE_NAME_CAPTION_NAME = "Authentication Type Name";
////
//public const string PORT_NUMBER_PROP_NAME = "Port";
//public const string USER_ID_PROP_NAME = "UserId";
//public const string PASSWORD_PROP_NAME = "Password";
//public const string DATABASE_PROP_NAME = "Database";
//public const string DATABASE_FILE_PROP_NAME = "DatabaseFile";
//public const string ATTACH_DB_FILE_PROP_NAME = "AttachDbFile";
//public const string SERVICE_TYPE_PROP_NAME = "ServerType";
//public const string USER_INSTANCE_PROP_NAME = "UserInstance";
//public const string CHARSET_PROP_NAME = "CharSet";
//public const string ENCODING_PROP_NAME = "Encoding";

//private DataTable createDataStoreTable()
//{
//    DataTable o = new DataTable();
//    o.TableName = ConfigDataSet.DATASTORE_TBL_NM;
//    {
//        o.Columns.Add(ConfigDataSet.ID_FIELD_NM, typeof(int));
//        //o.Columns.Add(ConfigDataSet.TECHNOLOGY_ID_PROP_NAME, typeof(int));
//        //o.Columns.Add(ConfigDataSet.TECHNOLOGY_NAME_PROP_NAME, typeof(string));
//        //o.Columns.Add(ConfigDataSet.METADATA_PROVIDER_PROP_NAME, typeof(string));
//        //o.Columns.Add(ConfigDataSet.SYNTAX_PROVIDER_ID_PROP_NAME, typeof(string));
//        //o.Columns.Add(ConfigDataSet.SYNTAX_PROVIDER_NAME_PROP_NAME, typeof(string));
//        //o.Columns.Add(ConfigDataSet.CONNECTION_STRING_PROP_NAME, typeof(string));
//        //o.Columns.Add(ConfigDataSet.CONNECTION_TESTED_PROP_NAME, typeof(string));
//        //o.Columns.Add(ConfigDataSet.AUTHENTICATION_TYPE_ID_PROP_NAME, typeof(string));
//        //o.Columns.Add(ConfigDataSet.AUTHENTICATION_TYPE_NAME_PROP_NAME, typeof(string));
//        //
//        o.Columns.Add(ConfigDataSet.PORT_NUMBER_PROP_NAME, typeof(string));
//        o.Columns.Add(ConfigDataSet.USER_ID_PROP_NAME, typeof(string));
//        o.Columns.Add(ConfigDataSet.PASSWORD_PROP_NAME, typeof(string));
//        o.Columns.Add(ConfigDataSet.DATABASE_PROP_NAME, typeof(string));
//        o.Columns.Add(ConfigDataSet.DATABASE_FILE_PROP_NAME, typeof(string));
//        o.Columns.Add(ConfigDataSet.ATTACH_DB_FILE_PROP_NAME, typeof(string));
//        o.Columns.Add(ConfigDataSet.SERVICE_TYPE_PROP_NAME, typeof(string));
//        o.Columns.Add(ConfigDataSet.USER_INSTANCE_PROP_NAME, typeof(string));
//        o.Columns.Add(ConfigDataSet.CHARSET_PROP_NAME, typeof(string));
//        o.Columns.Add(ConfigDataSet.ENCODING_PROP_NAME, typeof(string));
//        //
//        o.Columns.Add(ConfigDataSet.CREATION_FIELD_NM, typeof(DateTime));
//    }
//    {
//        o.Rows.Add(10001, 3456, "user01", "*****", "localhost/db", null, null, null, null, null, null, DateTime.Now);
//    }
//    return o;
//}
