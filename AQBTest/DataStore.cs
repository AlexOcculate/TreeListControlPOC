namespace AQBTest
{
   public partial class DataStore
   {
      [System.ComponentModel.DataAnnotations.Display( AutoGenerateField = false )]
      [System.Xml.Serialization.XmlIgnore]
      public static string TS_STR
      {
         [System.Diagnostics.DebuggerStepThrough]
         get
         {
            return string.Format( "{0:yyyyMMdd-HHmmss-ffffzzz}", System.DateTime.Now );
         }
      }

      #region --- Enums... ---
      public enum MetadataProviderEnum
      {
         AUTO = 0,
         GENERIC,
         MS_SQL_SERVER,
      }
      public enum SyntaxProviderEnum
      {
         AUTO = 0,
         GENERIC,
         ANSI_SQL_2003,
         ANSI_SQL_89,
         ANSI_SQL_92,
         FIREBIRD_1_0,
         FIREBIRD_1_5,
         FIREBIRD_2_0,
         FIREBIRD_2_5,
         IBM_DB2,
         IBM_INFORMIX_10,
         IBM_INFORMIX_8,
         IBM_INFORMIX_9,
         MS_ACCESS_2000_,
         MS_ACCESS_2003_,
         MS_ACCESS_97_,
         MS_ACCESS_XP_,
         MS_SQL_SERVER_2000,
         MS_SQL_SERVER_2005,
         MS_SQL_SERVER_2008,
         MS_SQL_SERVER_2012,
         MS_SQL_SERVER_2014,
         MS_SQL_SERVER_7,
         MS_SQL_SERVER_COMPACT_EDITION,
         MYSQL_3_XX,
         MYSQL_4_0,
         MYSQL_4_1,
         MYSQL_5_0,
         ORACLE_10,
         ORACLE_11,
         ORACLE_7,
         ORACLE_8,
         ORACLE_9,
         POSTGRESQL,
         SQLITE,
         SYBASE_ASE,
         SYBASE_SQL_ANYWHERE,
         TERADATA,
         VISTADB,
      }
      #endregion

      #region --- CREATION TIMESTAMP ----
      public const string CREATION_TS_FIELDNAME = "CreationTS";
      public const string CREATION_TS_DISPLAYNAME = "Creation TS";
      public const string CREATION_TS_DESCRIPTION = null;
      //[System.ComponentModel.DataAnnotations.Display( Name = CREATION_TS_DISPLAYNAME, Description = CREATION_TS_DESCRIPTION )]
      //[System.ComponentModel.DataAnnotations.DataType( System.ComponentModel.DataAnnotations.DataType.DateTime )]
      //[System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlAttribute("cts")]
      public System.DateTime CreationTS
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- ID ---
      public const string ID_FIELDNAME = "ID";
      public const string ID_DISPLAYNAME = "ID";
      public const string ID_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = ID_DISPLAYNAME, Description = ID_DESCRIPTION )]
      [System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlAttribute("id")]
      public int ID
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- PARENT ID ---
      public const string PARENT_ID_FIELDNAME = "ParentID";
      public const string PARENT_ID_DISPLAYNAME = "Parent ID";
      public const string PARENT_ID_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = PARENT_ID_DISPLAYNAME, Description = PARENT_ID_DESCRIPTION )]
      [System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlAttribute( "pid" )]
      public int ParentID
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- NAME ---
      public const string NAME_FIELDNAME = "Name";
      public const string NAME_DISPLAYNAME = "Name";
      public const string NAME_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = NAME_DISPLAYNAME, Description = NAME_DESCRIPTION )]
      [System.Xml.Serialization.XmlAttribute("nm")]
      public string Name
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- DESCRIPTION ---
      public const string DESCRIPTION_FIELDNAME = "Description";
      public const string DESCRIPTION_DISPLAYNAME = "Description";
      public const string DESCRIPTION_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = DESCRIPTION_DISPLAYNAME, Description = DESCRIPTION_DESCRIPTION )]
      [System.Xml.Serialization.XmlElement("dscr")]
      public string Description
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- PREVIEW ---
      public const string PREVIEW_FIELDNAME = "Preview";
      public const string PREVIEW_DISPLAYNAME = "Preview";
      public const string PREVIEW_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = PREVIEW_DISPLAYNAME, Description = PREVIEW_DESCRIPTION )]
      [System.Xml.Serialization.XmlElement("prvw")]
      public string Preview
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- IS ACTIVE ? ---
      public const string IS_ACTIVE_FIELDNAME = "IsActive";
      public const string IS_ACTIVE_DISPLAYNAME = "Is Active?";
      public const string IS_ACTIVE_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = IS_ACTIVE_DISPLAYNAME, Description = IS_ACTIVE_DESCRIPTION )]
      [System.Xml.Serialization.XmlAttribute("actv")]
      public bool IsActive
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- IS TO PULL REMOTELY ? ---
      public const string IS_PULL_REMOTELY_FIELDNAME = "IsToPullRemotely";
      public const string IS_PULL_REMOTELY_DISPLAYNAME = "Is To Pull Remotely?";
      public const string IS_PULL_REMOTELY_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = IS_PULL_REMOTELY_DISPLAYNAME, Description = IS_PULL_REMOTELY_DESCRIPTION )]
      [System.Xml.Serialization.XmlIgnore]
      public bool IsToPullRemotely
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- SYNTAX PROVIDER ---
      public const string SYNTAX_PROVIDER_FIELDNAME = "SyntaxProvider";
      public const string SYNTAX_PROVIDER_DISPLAYNAME = "Syntax Provider";
      public const string SYNTAX_PROVIDER_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = SYNTAX_PROVIDER_DISPLAYNAME, Description = SYNTAX_PROVIDER_DESCRIPTION )]
      [System.Xml.Serialization.XmlAttribute("sp")]
      [System.ComponentModel.DataAnnotations.EnumDataType( typeof( SyntaxProviderEnum ) )]
      [System.ComponentModel.DataAnnotations.Required]
      public int SyntaxProvider
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- METADATA PROVIDER ---
      public const string METADATA_PROVIDER_FIELDNAME = "MetadataProvider";
      public const string METADATA_PROVIDER_DISPLAYNAME = "Metadata Provider";
      public const string METADATA_PROVIDER_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = METADATA_PROVIDER_DISPLAYNAME, Description = METADATA_PROVIDER_DESCRIPTION )]
      [System.Xml.Serialization.XmlAttribute]
      [System.ComponentModel.DataAnnotations.EnumDataType( typeof( MetadataProviderEnum ) )]
      [System.ComponentModel.DataAnnotations.Required]
      [System.Xml.Serialization.XmlIgnore]
      public int MetadataProvider
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- LOAD DEFAULT DATABASE ONLY ? ---
      public const string LOAD_DEFAULT_DATABASE_ONLY_FIELDNAME = "LoadDefaultDatabaseOnly";
      public const string LOAD_DEFAULT_DATABASE_ONLY_DISPLAYNAME = "Load Default Database Only?";
      public const string LOAD_DEFAULT_DATABASE_ONLY_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = LOAD_DEFAULT_DATABASE_ONLY_DISPLAYNAME, Description = LOAD_DEFAULT_DATABASE_ONLY_DESCRIPTION )]
      [System.Xml.Serialization.XmlAttribute("lddo")]
      public bool LoadDefaultDatabaseOnly
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- LOAD SYSTEM OBJECTS ? ---
      public const string LOAD_SYSTEM_OBJECTS_FIELDNAME = "LoadSystemObjects";
      public const string LOAD_SYSTEM_OBJECTS_DISPLAYNAME = "Load System Objects?";
      public const string LOAD_SYSTEM_OBJECTS_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = LOAD_SYSTEM_OBJECTS_DISPLAYNAME, Description = LOAD_SYSTEM_OBJECTS_DESCRIPTION )]
      [System.Xml.Serialization.XmlAttribute("lso")]
      public bool LoadSystemObjects
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- WITH FIELDS ? ---
      public const string WITH_FIELDS_FIELDNAME = "WithFields";
      public const string WITH_FIELDS_DISPLAYNAME = "With Fields?";
      public const string WITH_FIELDS_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = WITH_FIELDS_DISPLAYNAME, Description = WITH_FIELDS_DESCRIPTION )]
      [System.Xml.Serialization.XmlAttribute("wf")]
      public bool WithFields
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- CONNECTION STRING ---
      public const string CONNECTION_STRING_FIELDNAME = "ConnectionString";
      public const string CONNECTION_STRING_DISPLAYNAME = "Connection String";
      public const string CONNECTION_STRING_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = CONNECTION_STRING_DISPLAYNAME, Description = CONNECTION_STRING_DESCRIPTION )]
      [System.Xml.Serialization.XmlElement("cs")]
      public string ConnectionString
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- AQB QB XML FILENAME ---
      public const string AQB_QB_XML_FILENAME_FIELDNAME = "AqbQbFilename";
      public const string AQB_QB_XML_FILENAME_DISPLAYNAME = "AqbQb Filename";
      public const string AQB_QB_XML_FILENAME_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = AQB_QB_XML_FILENAME_DISPLAYNAME, Description = AQB_QB_XML_FILENAME_DESCRIPTION )]
      [System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlIgnore]
      public string AqbQbFilename
      {
         [System.Diagnostics.DebuggerStepThrough]
         get { return string.Format( "{0}.AqbQb.ds", this.Name  );  }
         //[System.Diagnostics.DebuggerStepThrough]
         //set;
      }
      #endregion

      #region --- MI FQN XML FILENAME ---
      public const string MI_FQN_XML_FILENAME_FIELDNAME = "MiFqnFilename";
      public const string MI_FQN_XML_FILENAME_DISPLAYNAME = "MiFqn Filename";
      public const string MI_FQN_XML_FILENAME_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = MI_FQN_XML_FILENAME_DISPLAYNAME, Description = MI_FQN_XML_FILENAME_DESCRIPTION )]
      [System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlIgnore]
      public string MiFqnFilename
      {
         [System.Diagnostics.DebuggerStepThrough]
         get { return string.Format( "{0}.MiFqn.ds", this.Name ); }
         //[System.Diagnostics.DebuggerStepThrough]
         //set;
      }
      #endregion

      #region --- Ctors() ---
      public DataStore()
      {
      }
      #endregion
   }
}
