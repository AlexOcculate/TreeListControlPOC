//using ActiveQueryBuilder.Core;
using ActiveQueryBuilder.View.WinForms;
//using System.Data.SqlClient;

namespace AQBTest
{
   public partial class Form1 : DevExpress.XtraEditors.XtraForm
   {
      private ActiveQueryBuilder.View.WinForms.QueryBuilder qb;
      public Form1()
      {
         InitializeComponent( );
      }
      public Form1( string connectionString, string filename, bool loadDefaultDatabaseOnly = true, bool loadSystemObjects = false, bool withFields = true )
      {
         InitializeComponent( );
         {
            ////connectionString = @"Data Source=D:\TEMP\SQLite\SQLITEDB1.db3;";
            //connectionString = @"Data Source=D:\TEMP\SQLite\chinook\chinook.db;";
            //filename = @"D:\TEMP\SQLite\MetadataSQLiteTestWithFields.xml";
            //this.qb = ExtractMetadataValues.CreateQueryBuilderSQLite( connectionString, loadDefaultDatabaseOnly, loadSystemObjects, withFields );
            //this.gridControl1.DataSource = ExtractMetadataValues.BuildBindingList( this.qb );
            ////this.gridControl1.DataSource = buildBindingListSQLite( this.qb );
         }
         {
            connectionString = @"Data Source=DBSRV\QWERTY;Database=Sales;User Id=user02;Password=8a0IucJ@Nx1Qy5HfFrX0Ob3m;";
            filename = @"D:\TEMP\SQLite\MetadataMSSQLTestWithFields.xml";
            this.qb = ExtractMetadataValues.CreateQueryBuilderMSSQL( connectionString, loadDefaultDatabaseOnly, loadSystemObjects, withFields );
            //this.gridControl1.DataSource = buildBindingListMSSQL( this.qb );
            this.gridControl1.DataSource = ExtractMetadataValues.BuildBindingList( this.qb );
            ExtractMetadataValues.ConfigGridControl( this.gridControl1, this.gridView1 );
         }
         //ExtractMetadataValues.serializeQueryBuilder( this.qb, filename );
         // QueryBuilder.ShowMetadataContainerLoadWizard( this.qb.MetadataContainer, this.qb.MetadataLoadingOptions );
         // MetadataEditorOptions o = MetadataEditorOptions.HideLoadDatabaseButton;
         // QueryBuilder.EditMetadataContainer( this.qb.MetadataContainer, this.qb.MetadataStructure, this.qb.MetadataLoadingOptions );
      }

   }
}


/*
         //{
         //   //this.gridControl1.ForceInitialize( );
         //   this.gridView1.OptionsBehavior.ReadOnly = true;
         //   this.gridView1.OptionsView.ShowFooter = true;
         //   this.gridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
         //   //
         //   this.gridView1.Columns[ ColumnQN.METADATA_PROVIDER_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.SYNTAX_PROVIDER_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.IS_SYSTEM_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.REFERENCED_OBJECT_NAME_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.SERVER_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.DATABASE_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.SCHEMA_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.OBJECT_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.NAMEQUOTED_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.ALTNAME_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.FIELD_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.EXPRESSION_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.FIELDTYPE_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.IS_PK_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.IS_READONLY_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.DESCRIPTION_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.TAG_FIELDNAME ].Visible = false;
         //   this.gridView1.Columns[ ColumnQN.USERDATA_FIELDNAME ].Visible = false;
         //   //
         //   this.gridView1.Columns[ ColumnQN.REFERENCED_CARDINALYTY_NAME_FIELDNAME ].Caption = ColumnQN.REFERENCED_CARDINALYTY_NAME_DISPLAYNAME;

         //}

   
   private void serializeQueryBuilder( string filename )
      {
         {
            string xML = this.qb.MetadataContainer.XML;
         }
         {
            this.qb.MetadataContainer.ExportToXML( filename );
         }
         //{
         //   this.qb.MetadataContainer.ImportFromXML( filename );
         //}
      }

      #region --- MSSQL... ---
      private QueryBuilder createQueryBuilderMSSQL(
         string connectionString,
         bool loadDefaultDatabaseOnly,
         bool loadSystemObjects,
         bool withFields
      )
      {
         QueryBuilder qb = new QueryBuilder( )
         {
            SyntaxProvider = new ActiveQueryBuilder.Core.MSSQLSyntaxProvider( ),
            MetadataProvider = new ActiveQueryBuilder.Core.MSSQLMetadataProvider( )
         };
         qb.MetadataProvider.Connection = new System.Data.SqlClient.SqlConnection( connectionString );
         {
            ActiveQueryBuilder.Core.MetadataLoadingOptions loadingOptions = qb.SQLContext.MetadataContainer.LoadingOptions;
            loadingOptions.LoadDefaultDatabaseOnly = loadDefaultDatabaseOnly;
            loadingOptions.LoadSystemObjects = loadSystemObjects;
            //loadingOptions.IncludeFilter.Types = MetadataType.Field;
            //loadingOptions.ExcludeFilter.Schemas.Add("dbo");
         }
         //qb.InitializeDatabaseSchemaTree();
         //qb.MetadataContainer.LoadAll(withFields);
         return qb;
      } // createQueryBuilder(...)
      #endregion

      #region --- SQLite... ---
      private QueryBuilder createQueryBuilderSQLite(
         string connectionString,
         bool loadDefaultDatabaseOnly,
         bool loadSystemObjects,
         bool withFields
      )
      {
         QueryBuilder qb = new QueryBuilder( )
         {
            SyntaxProvider = new ActiveQueryBuilder.Core.SQLiteSyntaxProvider( ),
            MetadataProvider = new ActiveQueryBuilder.Core.SQLiteMetadataProvider( )
         };
         qb.MetadataProvider.Connection = new System.Data.SQLite.SQLiteConnection( connectionString );
         {
            ActiveQueryBuilder.Core.MetadataLoadingOptions loadingOptions = qb.SQLContext.MetadataContainer.LoadingOptions;
            loadingOptions.LoadDefaultDatabaseOnly = loadDefaultDatabaseOnly;
            loadingOptions.LoadSystemObjects = loadSystemObjects;
            //loadingOptions.IncludeFilter.Types = MetadataType.Field;
            //loadingOptions.ExcludeFilter.Schemas.Add("dbo");
         }
         qb.InitializeDatabaseSchemaTree( );
         qb.MetadataContainer.LoadAll( withFields );
         return qb;
      } // createQueryBuilder(...)
      #endregion

*/
