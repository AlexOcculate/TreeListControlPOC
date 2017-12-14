using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace Z900
{
   public partial class DataStoreCollectionXUC : DevExpress.XtraEditors.XtraUserControl
   {
      public DataStoreCollectionXUC()
      {
         InitializeComponent( );

         BindingList<DataStore4> dataSource = GetDataSource( );
         this.gridControl.DataSource = dataSource;
         this.bsiRecordsCount.Caption = "RECORDS : " + dataSource.Count;
      }
      void bbiPrintPreview_ItemClick( object sender, ItemClickEventArgs e )
      {
         this.gridControl.ShowRibbonPrintPreview( );
      }

      private void bbiNew_ItemClick( object sender, ItemClickEventArgs e )
      {
         BindingList<DataStore4> dataSource = this.gridControl.DataSource as BindingList<DataStore4>;
         dataSource.Add( new DataStore4( )
         {
            ID = 1,
            Name = System.DateTime.UtcNow + "="
         } );
      }

      private void bbiEdit_ItemClick( object sender, ItemClickEventArgs e )
      {
      }

      private void bbiDelete_ItemClick( object sender, ItemClickEventArgs e )
      {
         if( MessageBox.Show( "Delete row?", "Confirmation", MessageBoxButtons.YesNo ) != DialogResult.Yes )
            return;
         int focusedRowHandle = this.gridView.FocusedRowHandle;
         if( focusedRowHandle == int.MinValue )
            return;
         this.gridView.DeleteRow( focusedRowHandle );
      }

      private void bbiRefresh_ItemClick( object sender, ItemClickEventArgs e )
      {
         this.gridControl.RefreshDataSource( );
      }
      //
      #region --- DATASOURCE ---
      public BindingList<DataStore4> GetDataSource()
      {
         BindingList<DataStore4> result = new BindingList<DataStore4>( );
         result.Add( new DataStore4( )
         {
            ID = 1,
            Name = "ACME",
            Description = "Alex Mello Occulate!!!",
            Props = new List<Props>( )
                {
                    new Props("prop0", "value0"),
                    new Props("prop1", "value1"),
                    new Props("prop2", "value2"),
                    new Props("prop3", "value3"),
                    new Props("prop0", "value0"),
                    new Props("prop1", "value1"),
                    new Props("prop2", "value2"),
                    new Props("prop3", "value3"),
                }
         } );
         result.Add( new DataStore4( )
         {
            ID = 2,
            Name = "Electronics Depot",
            Description = "Alex da Silva Mello",
            Props = new List<Props>( )
                {
                    new Props("prop0", "value0"),
                    new Props("prop1", "value1"),
                    new Props("prop2", "value2"),
                    new Props("prop3", "value3"),
                    new Props("prop0", "value0"),
                    new Props("prop1", "value1"),
                    new Props("prop2", "value2"),
                    new Props("prop3", "value3"),
                }
         } );
         return result;
      }
      #endregion
   }
   public class DataStore4
   {
      public const string RootGroup = "<Root>";
      public const string MainContent = RootGroup + "/Data Store Connection";
      public const string TabbedGroup = MainContent + "/{Tabs}";
      public const string ConnectionGroup = TabbedGroup + "/Connection";
      public const string ConnectionFlagsGroup = ConnectionGroup + "/<ConnectionFlags->";
      public const string ProvidersGroup = TabbedGroup + "/Providers";
      public const string PreviewGroup = TabbedGroup + "/Preview";
      public const string DescriptionGroup = TabbedGroup + "/Description";
      public const string ServerGroup = TabbedGroup + "/Server";
      //
      [Display( Name = "Creation:", AutoGenerateField = false )]
      [ReadOnly( true )]
      [DataType( DataType.DateTime )]
      public System.DateTime Creation { get; set; }
      //
      [Display( Name = "ID:", AutoGenerateField = false )]
      public int ID { get; set; }
      //
      [Display( Name = "ParentID:", AutoGenerateField = false )]
      public int ParentID { get; set; }
      //
      [Display( Name = "Is a Folder?", AutoGenerateField = false ) /*, Required*/ ]
      public bool IsFolder { get; set; }
      //
      [Display( Name = "Name:", GroupName = MainContent, Order = 1 )]
      [StringLength( 100, MinimumLength = 1 )]
      [Required]
      public string Name { get; set; }
      //
      [Display( Name = "Connection String:"
          , GroupName = ConnectionGroup
          , Order = 1
          , Description =
          "String that specifies information about a data source and the means of connecting to it."
          + "\n"
          + "It is passed in code to an underlying driver or provider in order to initiate the connection."
          + "\n"
          + "Whilst commonly used for a database connection, the data source could also be a"
          + "\n"
          + "spreadsheet or text file."
          )]
      [StringLength( 100, MinimumLength = 1 )]
      [Required]
      public string ConnectionString { get; set; }
      //
      [Display( Name = "Login ID:"
          , GroupName = ConnectionGroup
          , Order = 2
          , Description = "Login ID is the unique ID that you use in conjuction with"
          + "\n"
          + "your password to log in to Data Stores. The purpose of the"
          + "\n"
          + "Login ID is to identify you and distinguish you from other"
          + "\n"
          + "users."
          )]
      [StringLength( 100, MinimumLength = 1 )]
      public string Login { get; set; }
      //
      [Display( Name = "Password:", GroupName = ConnectionGroup, Order = 3 )]
      [DataType( DataType.Password )]
      [StringLength( 100, MinimumLength = 8 )]
      public string Password { get; set; }
      //
      [Display( Name = "Active?", GroupName = ConnectionFlagsGroup, Order = 6 )]
      public bool IsActive { get; set; }
      //
      [Display( Name = "Connection Tested?", GroupName = ConnectionFlagsGroup, Order = 5 )]
      [ReadOnly( true )]
      public bool ConnectionWasTested { get; set; }
      //
      [Display( Name = "Server:", GroupName = ServerGroup )]
      [DataType( DataType.Url )]
      [StringLength( 4096, MinimumLength = 1 )]
      public string Server { get; set; }
      //
      [Display( Name = "Port:", GroupName = ServerGroup )]
      [Range( 0, 65535 )]
      public int Port { get; set; }
      //
      [Display( Name = "Syntax Provider:", GroupName = ProvidersGroup ), Required]
      [EnumDataType( typeof( SyntaxProviderEnum ) )]
      public int SyntaxProvider { get; set; }
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
      //
      [Display( Name = "Metadata Provider:", GroupName = ProvidersGroup ), Required]
      [EnumDataType( typeof( MetadataProviderEnum ) )]
      public int MetadataProvider { get; set; }
      public enum MetadataProviderEnum
      {
         AUTO = 0,
         GENERIC,
         MS_SQL_SERVER,
      }
      //
      [Display( Name = "Preview:", GroupName = PreviewGroup )]
      [DataType( DataType.MultilineText )]
      public string Preview { get; set; }
      //
      [Display( Name = "Description:", GroupName = DescriptionGroup )]
      [DataType( DataType.MultilineText )]
      public string Description { get; set; }

      [Display( Name = "Properties:", GroupName = ConnectionGroup, Order = 4 )]
      public List<Props> Props { get; set; }

      public DataStore4()
      {
      }
   }

   [Serializable( )]
   public class Props
   {
      [Display( Name = "Key:" )]
      [StringLength( 100, MinimumLength = 1 )]
      public string Key { get; set; }
      [Display( Name = "Value:" )]
      [StringLength( 100, MinimumLength = 1 )]
      public string Value { get; set; }
      [Display( Name = "Active?" )]
      public bool IsActive { get; set; }

      public Props()
      {
      }

      public Props( string key, string value )
      {
         Key = key ?? throw new ArgumentNullException( nameof( key ) );
         Value = value ?? throw new ArgumentNullException( nameof( value ) );
      }
   }
}
