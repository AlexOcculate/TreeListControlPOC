using System;
using DevExpress.Xpo;

namespace Q0001
{
    public partial class DataStore : XPObject
    {
        public const int ROOT_ID_DATAVALUE = -1;
        public const string ROOT_NAME_DATAVALUE = "ROOT";
        public const string ROOT_DESCRIPTION_DATAVALUE = "This is the [root] of al [branches]! Don't remove it!!!";
        //
        public const int ROOT_PARENT_ID_DATAVALUE = ROOT_ID_DATAVALUE;
        public const string ROOT_PARENT_NAME_DATAVALUE = ROOT_NAME_DATAVALUE;
        //
        public const string EXAMPLE_FOLDER_NAME_DATAVALUE = "Example Folder";
        public const string EXAMPLE_FOLDER_DESCRIPTION_DATAVALUE = "This is an example folder.";
        //
        public const string NEW_FOLDER_NAME_DATAVALUE = "<NEW FOLDER NAME>";
        public const string NEW_NODE_NAME_DATAVALUE = "<NEW NODE NAME>";
        //
        public const string ID_PROP_NAME = "Id";
        //
        public const string PARENT_ID_PROP_NAME = "ParentId";
        public const string PARENT_ID_CAPTION_NAME = "Parent Id";
        //
        public const string PARENT_NAME_PROP_NAME = "ParentName";
        public const string PARENT_NAME_CAPTION_NAME = "Parent Name";
        //
        public const string IS_FOLDER_PROP_NAME = "IsFolder";
        public const string IS_FOLDER_CAPTION_NAME = "Is a Folder?";
        //
        public const string NAME_PROP_NAME = "Name";
        public const string DESCRIPTION_PROP_NAME = "Description";
        //
        public const string TECHNOLOGY_ID_PROP_NAME = "TechnologyId";
        public const string TECHNOLOGY_ID_CAPTION_NAME = "Technology Id";
        //
        public const string TECHNOLOGY_NAME_PROP_NAME = "TechnologyName";
        public const string TECHNOLOGY_NAME_CAPTION_NAME = "Technology Name";
        //
        public const string METADATA_PROVIDER_PROP_NAME = "MetadataProvider";
        public const string METADATA_PROVIDER_CAPTION_NAME = "Metadata Provider";
        //
        public const string SYNTAX_PROVIDER_ID_PROP_NAME = "SyntaxProviderId";
        public const string SYNTAX_PROVIDER_ID_CAPTION_NAME = "Syntax Provider Id";
        //
        public const string SYNTAX_PROVIDER_NAME_PROP_NAME = "SyntaxProviderName";
        public const string SYNTAX_PROVIDER_NAME_CAPTION_NAME = "Syntax Provider Name";
        //
        public const string CONNECTION_STRING_PROP_NAME = "ConnectionString";
        public const string CONNECTION_STRING_CAPTION_NAME = "ConnectionString";
        //
        public const string CONNECTION_TESTED_PROP_NAME = "ConnectionTested";
        public const string SERVER_PROP_NAME = "Server";
        //
        public const string AUTHENTICATION_TYPE_ID_PROP_NAME = "AuthenticationTypeId";
        public const string AUTHENTICATION_TYPE_ID_CAPTION_NAME = "Authentication Type Id";
        //
        public const string AUTHENTICATION_TYPE_NAME_PROP_NAME = "AuthenticationTypeName";
        public const string AUTHENTICATION_TYPE_NAME_CAPTION_NAME = "Authentication Type Name";
        //
        public const string PORT_NUMBER_PROP_NAME = "Port";
        public const string USER_ID_PROP_NAME = "UserId";
        public const string PASSWORD_PROP_NAME = "Password";
        public const string DATABASE_PROP_NAME = "Database";
        public const string DATABASE_FILE_PROP_NAME = "DatabaseFile";
        public const string ATTACH_DB_FILE_PROP_NAME = "AttachDbFile";
        public const string SERVICE_TYPE_PROP_NAME = "ServerType";
        public const string USER_INSTANCE_PROP_NAME = "UserInstance";
        public const string CHARSET_PROP_NAME = "CharSet";
        public const string ENCODING_PROP_NAME = "Encoding";
        //
        #region --- "Service Fields" ---
        public int Id
        {
            get { return GetPropertyValue<Int32>(ID_PROP_NAME); }
            set { SetPropertyValue(ID_PROP_NAME, value); }
        }
        public int ParentId
        {
            get { return GetPropertyValue<Int32>(PARENT_ID_PROP_NAME); }
            set { SetPropertyValue(PARENT_ID_PROP_NAME, value); }
        }
        #endregion
        //
        #region --- FIELDS ---
        public string ParentName
        {
            get { return GetPropertyValue<string>(PARENT_NAME_PROP_NAME); }
            set { SetPropertyValue(PARENT_NAME_PROP_NAME, value); }
        }
        public bool IsFolder
        {
            get { return GetPropertyValue<Boolean>(IS_FOLDER_PROP_NAME); }
            set { SetPropertyValue(IS_FOLDER_PROP_NAME, value); }
        }
        public string Name
        {
            get { return GetPropertyValue<String>(NAME_PROP_NAME); }
            set { SetPropertyValue(NAME_PROP_NAME, value); }
        }
        [Delayed(true)]
        public string Description
        {
            get { return GetPropertyValue<String>(DESCRIPTION_PROP_NAME); }
            set { SetPropertyValue(DESCRIPTION_PROP_NAME, value); }
        }
        public int TechnologyId
        {
            get { return GetPropertyValue<int>(TECHNOLOGY_ID_PROP_NAME); }
            set { SetPropertyValue(TECHNOLOGY_ID_PROP_NAME, value); }
        }
        public string TechnologyName
        {
            get { return GetPropertyValue<string>(TECHNOLOGY_NAME_PROP_NAME); }
            set { SetPropertyValue(TECHNOLOGY_NAME_PROP_NAME, value); }
        }
        public string MetadataProvider
        {
            get { return GetPropertyValue<String>(METADATA_PROVIDER_PROP_NAME); }
            set { SetPropertyValue(METADATA_PROVIDER_PROP_NAME, value); }
        }
        //
        [NonPersistent]
        public static string[] AvailableSyntaxProviderList = new string[]
        {
            "Auto",
            "Generic",
            "ANSI SQL-2003",
            "ANSI SQL-89",
            "ANSI SQL-92",
            "Firebird 1.0",
            "Firebird 1.5",
            "Firebird 2.0",
            "Firebird 2.5",
            "IBM DB2",
            "IBM Informix 10",
            "IBM Informix 8",
            "IBM Informix 9",
            "MS Access 2000 (MS Jet 4.0)",
            "MS Access 2003 (MS Jet 4.0)",
            "MS Access 97 (MS Jet 3.0)",
            "MS Access XP (MS Jet 4.0)",
            "MS SQL Server 2000",
            "MS SQL Server 2005",
            "MS SQL Server 2008",
            "MS SQL Server 2012",
            "MS SQL Server 2014",
            "MS SQL Server 7",
            "MS SQL Server Compact Edition",
            "MySQL 3.xx",
            "MySQL 4.0",
            "MySQL 4.1",
            "MySQL 5.0",
            "Oracle 10",
            "Oracle 11",
            "Oracle 7",
            "Oracle 8",
            "Oracle 9",
            "PostgreSQL",
            "SQLite",
            "Sybase ASE",
            "Sybase SQL Anywhere",
            "Teradata",
            "VistaDB"
        };
        //
        public int SyntaxProviderId
        {
            get { return GetPropertyValue<int>(SYNTAX_PROVIDER_ID_PROP_NAME); }
            set { SetPropertyValue(SYNTAX_PROVIDER_ID_PROP_NAME, value); }
        }
        public string SyntaxProviderName
        {
            get { return GetPropertyValue<string>(SYNTAX_PROVIDER_NAME_PROP_NAME); }
            set { SetPropertyValue(SYNTAX_PROVIDER_NAME_PROP_NAME, value); }
        }
        // ---------------------------------------------------
        public bool ConnectionTested
        {
            get { return GetPropertyValue<bool>(CONNECTION_TESTED_PROP_NAME); }
            set { SetPropertyValue(CONNECTION_TESTED_PROP_NAME, value); }
        }
        public string ConnectionString
        {
            get { return GetPropertyValue<String>(CONNECTION_STRING_PROP_NAME); }
            set { SetPropertyValue(CONNECTION_STRING_PROP_NAME, value); }
        }
        public string Server
        {
            get { return GetPropertyValue<String>(SERVER_PROP_NAME); }
            set { SetPropertyValue(SERVER_PROP_NAME, value); }
        }
        public int Port
        {
            get { return GetPropertyValue<int>(PORT_NUMBER_PROP_NAME); }
            set { SetPropertyValue(PORT_NUMBER_PROP_NAME, value); }
        }
        public int AuthenticationTypeId
        {
            get { return GetPropertyValue<int>(AUTHENTICATION_TYPE_ID_PROP_NAME); }
            set { SetPropertyValue(AUTHENTICATION_TYPE_ID_PROP_NAME, value); }
        }
        public string AuthenticationTypeName
        {
            get { return GetPropertyValue<string>(AUTHENTICATION_TYPE_NAME_PROP_NAME); }
            set { SetPropertyValue(AUTHENTICATION_TYPE_NAME_PROP_NAME, value); }
        }
        public string UserId
        {
            get { return GetPropertyValue<String>(USER_ID_PROP_NAME); }
            set { SetPropertyValue(USER_ID_PROP_NAME, value); }
        }
        public string Password
        {
            get { return GetPropertyValue<String>(PASSWORD_PROP_NAME); }
            set { SetPropertyValue(PASSWORD_PROP_NAME, value); }
        }
        public string Database
        {
            get { return GetPropertyValue<String>(DATABASE_PROP_NAME); }
            set { SetPropertyValue(DATABASE_PROP_NAME, value); }
        }
        public string DatabaseFile
        {
            get { return GetPropertyValue<String>(DATABASE_FILE_PROP_NAME); }
            set { SetPropertyValue(DATABASE_FILE_PROP_NAME, value); }
        }
        public string AttachDbFile
        {
            get { return GetPropertyValue<String>(ATTACH_DB_FILE_PROP_NAME); }
            set { SetPropertyValue(ATTACH_DB_FILE_PROP_NAME, value); }
        }
        public string ServerType
        {
            get { return GetPropertyValue<String>(SERVICE_TYPE_PROP_NAME); }
            set { SetPropertyValue(SERVICE_TYPE_PROP_NAME, value); }
        }
        public bool UserInstance
        {
            get { return GetPropertyValue<bool>(USER_INSTANCE_PROP_NAME); }
            set { SetPropertyValue(USER_INSTANCE_PROP_NAME, value); }
        }
        public string CharSet
        {
            get { return GetPropertyValue<String>(CHARSET_PROP_NAME); }
            set { SetPropertyValue(CHARSET_PROP_NAME, value); }
        }
        public string Encoding
        {
            get { return GetPropertyValue<String>(ENCODING_PROP_NAME); }
            set { SetPropertyValue(ENCODING_PROP_NAME, value); }
        }
        #endregion
        //
        #region --- Icon Imagens ---
        [NonPersistent]
        public int StateImageIndex
        {
            get { return IsFolder ? 0 : 2; }
        }
        [NonPersistent]
        public int SelectImageIndex
        {
            get { return 0; }
        }
        #endregion
    }
}
