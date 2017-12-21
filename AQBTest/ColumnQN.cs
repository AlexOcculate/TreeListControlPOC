namespace AQBTest
{
   public class ColumnQN
   {
      //private string root;
      //private string server;
      //private string database;
      //private string schema;
      //private string table;
      //private string column;
      //
      public ColumnQN( string db, string sch, string tbl, string col )
      {
         this.Database = db;
         this.Schema = sch;
         this.ObjectName = tbl;
         this.Field = col;
      }

      public ColumnQN()
      {
      }
      //
      public const string METADATA_PROVIDER_FIELDNAME = "MetadataProvider";
      public string MetadataProvider { get; set; }
      public const string SYNTAX_PROVIDER_FIELDNAME = "SyntaxProvider";
      public string SyntaxProvider { get; set; }

      public const string ID_FIELDNAME = "ID";
      public int ID { get; set; }
      public const string PARENT_ID_FIELDNAME = "ParentID";
      public int ParentID { get; set; }
      //
      public const string IS_SYSTEM_FIELDNAME = "IsSystem";
      public bool IsSystem { get; set; }
      //
      public const string TYPE_FIELDNAME = "Type";
      public string Type { get; set; }
      public const string PARENT_TYPE_FIELDNAME = "ParentType";
      public string ParentType { get; set; }
      //
      public const string CARDINALYTY_FIELDNAME = "Cardinality";
      public const string CARDINALYTY_DISPLAYNAME = "FK Cardinality";
      public string Cardinality { get; set; } // FK
      public const string FIELDSCOUNT_FIELDNAME = "FieldsCount";
      public const string FIELDSCOUNT_DISPLAYNAME = "FK Fields Count";
      public int FieldsCount { get; set; }
      public const string FIELDS_FIELDNAME = "Fields";
      public const string FIELDS_DISPLAYNAME = "FK Fields";
      public string Fields { get; set; }
      //
      public const string REFERENCED_CARDINALYTY_NAME_FIELDNAME = "ReferencedCardinality";
      public const string REFERENCED_CARDINALYTY_NAME_DISPLAYNAME = "TK Cardinality";
      public string ReferencedCardinality { get; set; } // FK
      public const string REFERENCED_OBJECT_FIELDNAME = "ReferencedObject";
      public const string REFERENCED_OBJECT_DISPLAYNAME = "TK Object";
      public string ReferencedObject { get; set; }
      public const string REFERENCED_OBJECT_NAME_FIELDNAME = "ReferencedObjectName";
      public const string REFERENCED_OBJECT_NAME_DISPLAYNAME = "TK Object Name";
      public string ReferencedObjectName { get; set; }
      public const string REFERENCED_FIELDS_COUNT_FIELDNAME = "ReferencedFieldsCount";
      public const string REFERENCED_FIELDS_COUNT_DISPLAYNAME = "TK Fields Count";
      public int ReferencedFieldsCount { get; set; }
      public const string REFERENCED_FIELDS_FIELDNAME = "ReferencedFields";
      public const string REFERENCED_FIELDS_DISPLAYNAME = "TK Fields";
      public string ReferencedFields { get; set; }
      //
      //public string Root { get; set; }
      public const string SERVER_FIELDNAME = "Server";
      public string Server { get; set; }
      public const string DATABASE_FIELDNAME = "Database";
      public string Database { get; set; }
      public const string SCHEMA_FIELDNAME = "Schema";
      public string Schema { get; set; }
      public const string OBJECT_FIELDNAME = "ObjectName";
      public string ObjectName { get; set; }
      //
      public const string NAMEFULLQUALIFIED_FIELDNAME = "NameFullQualified";
      public string NameFullQualified { get; set; }
      public const string NAMEQUOTED_FIELDNAME = "NameQuoted";
      public string NameQuoted { get; set; }
      public const string ALTNAME_FIELDNAME = "AltName";
      public string AltName { get; set; }
      public const string FIELD_FIELDNAME = "Field";
      public const string FIELD_DISPLAYNAME = "Name";
      public string Field { get; set; }
      //
      public bool HasDefault { get; set; }
      public const string EXPRESSION_FIELDNAME = "Expression";
      public string Expression { get; set; }
      public const string FIELDTYPE_FIELDNAME = "FieldType";
      public string FieldType { get; set; }
      public string FieldTypeName { get; set; }
      public bool IsNullable { get; set; }
      public int Precision { get; set; }
      public int Scale { get; set; }
      public long Size { get; set; }
      public const string IS_PK_FIELDNAME = "IsPK";
      public bool IsPK { get; set; }
      public const string IS_READONLY_FIELDNAME = "IsRO";
      public bool IsRO { get; set; }

      public const string DESCRIPTION_FIELDNAME = "Description"; 
      public string Description { get; set; }
      public const string TAG_FIELDNAME = "Tag";
      public object Tag { get; set; }
      public const string USERDATA_FIELDNAME = "UserData";
      public string UserData { get; set; }

      public override string ToString()
      {
         return string.Format( "0:{1}", this.Type, this.NameFullQualified );
      }
   }

}
