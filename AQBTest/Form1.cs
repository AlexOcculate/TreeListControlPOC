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
            {
               //MetadataItemFQNCollection o = new MetadataItemFQNCollection( );
               //o.List = ExtractMetadataValues.BuildBindingList( this.qb );
               //o.Save( @"D:\TEMP\SQLite\XXX.xml" );
               MetadataItemFQNCollection p = MetadataItemFQNCollection.Load( @"D:\TEMP\SQLite\XXX.xml" );
               this.gridControl1.DataSource = p.List; //  ExtractMetadataValues.BuildBindingList( this.qb );
            }
            ExtractMetadataValues.ConfigGridControl( this.gridControl1, this.gridView1 );
         }
         //ExtractMetadataValues.serializeQueryBuilder( this.qb, filename );
         // QueryBuilder.ShowMetadataContainerLoadWizard( this.qb.MetadataContainer, this.qb.MetadataLoadingOptions );
         // MetadataEditorOptions o = MetadataEditorOptions.HideLoadDatabaseButton;
         // QueryBuilder.EditMetadataContainer( this.qb.MetadataContainer, this.qb.MetadataStructure, this.qb.MetadataLoadingOptions );
      }
   }
}
