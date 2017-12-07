using System;

using System.Linq;

namespace DataSetTest
{
    public class DataStore : BaseTable
    {
        #region --- CONSTANTS ---
        public const string TABLE_NAME = "DataStore";
        //
        public const string TECHNOLOGY_ID_FIELD_NM = "TechnologyId";
        public const string TECHNOLOGY_NAME_FIELD_NM = "TechnologyName";
        //
        public const string METADATA_PROVIDER_NAME_FIELD_NM = "MetadataProvider";
        //
        public const string SYNTAX_PROVIDER_ID_FIELD_NM = "SyntaxProviderId";
        public const string SYNTAX_PROVIDER_NAME_FIELD_NM = "SyntaxProviderName";
        //
        public const string CONNECTION_STRING_FIELD_NM = "ConnectionString";
        //
        public const string CONNECTION_TESTED_FIELD_NM = "ConnectionTested";
        public const string SERVER_FIELD_NM = "Server";
        //
        public const string AUTHENTICATION_TYPE_ID_FIELD_NM = "AuthenticationTypeId";
        public const string AUTHENTICATION_TYPE_NAME_FIELD_NM = "AuthenticationTypeName";
        //
        public const string PORT_NUMBER_FIELD_NM = "Port";
        public const string USER_ID_FIELD_NM = "UserId";
        public const string PASSWORD_FIELD_NM = "Password";
        public const string DATABASE_FIELD_NM = "Database";
        public const string DATABASE_FILE_FIELD_NM = "DatabaseFile";
        public const string ATTACH_DB_FILE_FIELD_NM = "AttachDbFile";
        public const string SERVICE_TYPE_FIELD_NM = "ServerType";
        public const string USER_INSTANCE_FIELD_NM = "UserInstance";
        public const string CHARSET_FIELD_NM = "CharSet";
        public const string ENCODING_FIELD_NM = "Encoding";
        #endregion
        //
        public DataStore(string filePathName, string xmlNamespace = null, string xmlPrefix = null, string tableName = TABLE_NAME)
            : base(filePathName, xmlNamespace, xmlPrefix, tableName)
        {
            if (!this.WasLoadedFromFile)
            {
                this.Columns.Add(PORT_NUMBER_FIELD_NM, typeof(string));
                this.Columns.Add(USER_ID_FIELD_NM, typeof(string));
                this.Columns.Add(PASSWORD_FIELD_NM, typeof(string));
                this.Columns.Add(DATABASE_FIELD_NM, typeof(string));
                this.Columns.Add(DATABASE_FILE_FIELD_NM, typeof(string));
                this.Columns.Add(ATTACH_DB_FILE_FIELD_NM, typeof(string));
                this.Columns.Add(SERVICE_TYPE_FIELD_NM, typeof(string));
                this.Columns.Add(USER_INSTANCE_FIELD_NM, typeof(string));
                this.Columns.Add(CHARSET_FIELD_NM, typeof(string));
                this.Columns.Add(ENCODING_FIELD_NM, typeof(string));
                //
                this.Columns.Add(TECHNOLOGY_NAME_FIELD_NM, typeof(string));
                this.Columns.Add(METADATA_PROVIDER_NAME_FIELD_NM, typeof(string));
                this.Columns.Add(SYNTAX_PROVIDER_NAME_FIELD_NM, typeof(string));
                this.Columns.Add(CONNECTION_STRING_FIELD_NM, typeof(string));
                this.Columns.Add(CONNECTION_TESTED_FIELD_NM, typeof(bool));
                this.Columns.Add(AUTHENTICATION_TYPE_NAME_FIELD_NM, typeof(string));
            }
        }

        public new void CreateBuiltInDataValues()
        {
            const bool fldr = false;
            const int tp = 0;
            const object URI = null;
            const object PVW = null;
            const object DSC = null;
            DateTime now = DateTime.Now;
            this.Rows.Add(now, 1000, -1, fldr, tp, "Auto", URI, PVW, DSC,
                3456, "user01", "*****", "localhost/db"
            );
        }
    }
}
