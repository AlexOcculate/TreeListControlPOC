using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Z900.Model
{
   public partial class DataStore
   {
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


      public const string IS_ACTIVE_DISPLAYNAME = "Active?";
      public const string IS_ACTIVE_FIELDNAME = "IsActive";
      public const string IS_ACTIVE_DESCRIPTION = null;
      [Display( Name = IS_ACTIVE_DISPLAYNAME, Description = IS_ACTIVE_DESCRIPTION )]
      [Required]
      [XmlAttribute]
      public bool IsActive { get; set; }

      public const string WAS_TESTED_DISPLAYNAME = "Tested?";
      public const string WAS_TESTED_FIELDNAME = "wasTested";
      public const string WAS_TESTED_DESCRIPTION = null;
      [Display( Name = WAS_TESTED_DISPLAYNAME, Description = WAS_TESTED_DESCRIPTION )]
      [ReadOnly( true )]
      [XmlAttribute]
      public bool wasTested { get; set; }

      public const string CREATION_DISPLAYNAME = "Creation";
      public const string CREATION_FIELDNAME = "Creation";
      public const string CREATION_DESCRIPTION = null;
      [Display( Name = CREATION_DISPLAYNAME, Description = CREATION_DESCRIPTION )]
      [ReadOnly( true )]
      [DataType( DataType.DateTime )]
      [XmlAttribute]
      public System.DateTime Creation { get; set; }
      public const string NAME_DISPLAYNAME = "Name";
      public const string NAME_FIELDNAME = "Name";
      public const string NAME_DESCRIPTION = null;
      [Display( Name = NAME_DISPLAYNAME, Description = NAME_DESCRIPTION )]
      [StringLength( 50, MinimumLength = 1 )]
      [Required]
      public string Name { get; set; }

      public const string CONNECTION_STRING_DISPLAYNAME = "Connection String";
      public const string CONNECTION_STRING_FIELDNAME = "ConnectionString";
      public const string CONNECTION_STRING_DESCRIPTION = ""
          + "String that specifies information about a data source and the means of connecting to it."
          + "\n"
          + "It is passed in code to an underlying driver or provider in order to initiate the connection."
          + "\n"
          + "Whilst commonly used for a database connection, the data source could also be a"
          + "\n"
          + "spreadsheet or text file."
         ;
      [Display( Name = CONNECTION_STRING_DISPLAYNAME, Description = CONNECTION_STRING_DESCRIPTION )]
      [StringLength( 100, MinimumLength = 1 )]
      [Required]
      public string ConnectionString { get; set; }

      public const string LOGIN_ID_DISPLAYNAME = "Login ID";
      public const string LOGIN_ID_FIELDNAME = "LoginID";
      public const string LOGIN_ID_DESCRIPTION = ""
          + "Login ID is the unique ID that you use in conjuction with"
          + "\n"
          + "your password to log in to Data Stores. The purpose of the"
          + "\n"
          + "Login ID is to identify you and distinguish you from other"
          + "\n"
          + "users."
         ;
      [Display( Name = LOGIN_ID_DISPLAYNAME, Description = LOGIN_ID_DESCRIPTION )]
      [StringLength( 50, MinimumLength = 1 )]
      public string LoginID { get; set; }

      public const string PASSWORD_DISPLAYNAME = "Password";
      public const string PASSWORD_FIELDNAME = "Password";
      public const string PASSWORD_DESCRIPTION = null;
      [Display( Name = PASSWORD_DISPLAYNAME, Description = PASSWORD_DESCRIPTION )]
      [DataType( DataType.Password )]
      [StringLength( 50, MinimumLength = 1 )]
      public string Password { get; set; }

      public const string FULLPATHNAME_DISPLAYNAME = "FullPathName";
      public const string FULLPATHNAME_FIELDNAME = "FullPathName";
      public const string FULLPATHNAME_DESCRIPTION = null;
      [Display( Name = FULLPATHNAME_DISPLAYNAME, Description = FULLPATHNAME_DESCRIPTION )]
      [ReadOnly( true )]
      [XmlIgnore]
      public string FullPathName { get; set; }

      public const string SYNTAX_PROVIDER_DISPLAYNAME = "Syntax Provider";
      public const string SYNTAX_PROVIDER_FIELDNAME = "SyntaxProvider";
      public const string SYNTAX_PROVIDER_DESCRIPTION = null;
      [Display( Name = SYNTAX_PROVIDER_DISPLAYNAME, Description = SYNTAX_PROVIDER_DESCRIPTION )]
      [EnumDataType( typeof( SyntaxProviderEnum ) )]
      [Required]
      public int SyntaxProvider { get; set; }

      public const string METADATA_PROVIDER_DISPLAYNAME = "Metadata Provider";
      public const string METADATA_PROVIDER_FIELDNAME = "MetadataProvider";
      public const string METADATA_PROVIDER_DESCRIPTION = null;
      [Display( Name = METADATA_PROVIDER_DISPLAYNAME, Description = METADATA_PROVIDER_DESCRIPTION )]
      [EnumDataType( typeof( MetadataProviderEnum ) )]
      [Required]
      public int MetadataProvider { get; set; }

      public const string PREVIEW_DISPLAYNAME = "Preview";
      public const string PREVIEW_FIELDNAME = "Preview";
      public const string PREVIEW_DESCRIPTION = null;
      [Display( Name = PREVIEW_DISPLAYNAME, Description = PREVIEW_DESCRIPTION )]
      [DataType( DataType.MultilineText )]
      public string Preview { get; set; }
      //
      public const string DESCRIPTION_DISPLAYNAME = "Description";
      public const string DESCRIPTION_FIELDNAME = "Description";
      public const string DESCRIPTION_DESCRIPTION = null;
      [Display( Name = DESCRIPTION_DISPLAYNAME, Description = DESCRIPTION_DESCRIPTION )]
      [DataType( DataType.MultilineText )]
      public string Description { get; set; }
   }
}
