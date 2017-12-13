using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace DataSetTest
{
   public partial class XXX : DevExpress.XtraEditors.XtraForm
   {
      public XXX()
      {
         InitializeComponent();
         //
         DataStore2 dataSource = this.createDataSource();
         {
            this.bindingSource1.DataSource = typeof(DataStore2);
            this.bindingSource1.Add(dataSource);
            //
            this.dataLayoutControl1.DataSource = bindingSource1;
            this.dataLayoutControl1.AllowGeneratingCollectionProperties = DevExpress.Utils.DefaultBoolean.True;
            this.dataLayoutControl1.RetrieveFields();
            this.dataLayoutControl1.BestFit();
            //dataLayoutControl1.AutoRetrieveFields = true;
         }
         {
            this.gridControl1.DataSource = bindingSource1;
            this.gridControl1.UseEmbeddedNavigator = true;

            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.OptionsBehavior.Editable = true;
            this.gridView1.OptionsBehavior.ReadOnly = false;
         }
         this.dataLayoutControl1.SaveLayoutToXml(@"D:\TEMP\SQLite\layout");
         BaseLayoutItem baseLayoutItem = this.dataLayoutControl1.Root[0];
         {
            #region Save the object
            // Create a new XmlSerializer instance with the type of the test class
            XmlSerializer SerializerObj = new XmlSerializer(typeof(DataStore2));

            // Create a new file stream to write the serialized object to a file
            TextWriter WriteFileStream = new StreamWriter(@"D:\TEMP\SQLite\DataStore2.xml");
            SerializerObj.Serialize(WriteFileStream, dataSource);

            // Cleanup
            WriteFileStream.Close();

            #endregion
         }
         BaseView mainView = this.gc.MainView;
      }
      private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
      {
         GridView view = sender as GridView;
         //view.SetRowCellValue(e.RowHandle, view.Columns["Creation:"], DateTime.Now);
         //view.SetRowCellValue(e.RowHandle, view.Columns["ID:"], 0);
         //view.SetRowCellValue(e.RowHandle, view.Columns["ParentID:"], -1);
         //view.SetRowCellValue(e.RowHandle, view.Columns["IsFolder"], false);
         view.SetRowCellValue(e.RowHandle, view.Columns["Name"], "Example Name");
         view.SetRowCellValue(e.RowHandle, view.Columns["ConnectionString"], "jdbc:oracle://");
         view.SetRowCellValue(e.RowHandle, view.Columns["Login"], null);
         view.SetRowCellValue(e.RowHandle, view.Columns["Password"], null);
         view.SetRowCellValue(e.RowHandle, view.Columns["IsActive"], false);

         var x = new List<Props>()
                {
                    new Props("prop0", "value0"),
                    new Props("prop1", "value1"),
                    new Props("prop2", "value2"),
                    new Props("prop3", "value3"),
                    new Props("prop0", "value0"),
                    new Props("prop1", "value1"),
                    new Props("prop2", "value2"),
                    new Props("prop3", "value3"),
                };
         view.SetRowCellValue(e.RowHandle, view.Columns["Props"], x);
      }
      private void gridView2_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
      {
         GridView view = sender as GridView;
         view.SetRowCellValue(e.RowHandle, view.Columns["Name"], "Example Name");
         view.SetRowCellValue(e.RowHandle, view.Columns["ConnectionString"], "jdbc:oracle://");
         view.SetRowCellValue(e.RowHandle, view.Columns["Login"], null);
         view.SetRowCellValue(e.RowHandle, view.Columns["Password"], null);
         view.SetRowCellValue(e.RowHandle, view.Columns["IsActive"], false);

         var x = new List<Props>()
                {
                    new Props("prop0", "value0"),
                    new Props("prop1", "value1"),
                    new Props("prop2", "value2"),
                    new Props("prop3", "value3"),
                    new Props("prop0", "value0"),
                    new Props("prop1", "value1"),
                    new Props("prop2", "value2"),
                    new Props("prop3", "value3"),
                };
         view.SetRowCellValue(e.RowHandle, view.Columns["Props"], x);
      }

      public List<DataStore2> createDataSourceList()
      {
         List<DataStore2> o = new List<DataStore2>();
         return o;
      }
      public DataStore2 createDataSource()
      {
         DataStore2 o = new DataStore2()
         {
            Name = "alex",
            Description = "Alex Mello Occulate!!!",
            Props = new List<Props>()
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
         };
         return o;
      }

      private void dataLayoutControl1_FieldRetrieving(object sender, DevExpress.XtraDataLayout.FieldRetrievingEventArgs e)
      {
         if (e.FieldName == "Port")
         {
            e.EditorType = typeof(DevExpress.XtraEditors.SpinEdit);
            e.Handled = true;
         }
      }

      private DevExpress.XtraGrid.GridControl gc;
      private DevExpress.XtraGrid.Views.Grid.GridView gv;

      private void dataLayoutControl1_FieldRetrieved(object sender, DevExpress.XtraDataLayout.FieldRetrievedEventArgs e)
      {
         if (e.FieldName == "ConnectionWasTested" || e.FieldName == "IsFolder")
         {
            (e.Control as DevExpress.XtraEditors.CheckEdit).Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Item.TextVisible = false;
            return;
         }
         if (e.FieldName == "Description" || e.FieldName == "Preview")
         {
            e.Item.TextLocation = DevExpress.Utils.Locations.Top;
            return;
         }
         if (e.FieldName == "Props")
         {
            this.gc = e.Item.Control as DevExpress.XtraGrid.GridControl;
            if (this.gc == null) return;
            this.gc.UseEmbeddedNavigator = true;
            this.gc.ForceInitialize();
            this.gv = (DevExpress.XtraGrid.Views.Grid.GridView)this.gc.MainView;
            this.gv.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView2_InitNewRow);
            var ob = this.gv.OptionsBehavior;
            ob.Editable = true;
            ob.ReadOnly = false;
            var ov = this.gv.OptionsView;
            ov.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            ov.ShowFooter = true;
         }
      }
   }

   [Serializable()]
   public class DataStore2
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
      [Display(Name = "Creation:", AutoGenerateField = false)]
      [ReadOnly(true)]
      [DataType(DataType.DateTime)]
      public DateTime Creation { get; set; }
      //
      [Display(Name = "ID:", AutoGenerateField = false)]
      public int ID { get; set; }
      //
      [Display(Name = "ParentID:", AutoGenerateField = false)]
      public int ParentID { get; set; }
      //
      [Display(Name = "Is a Folder?", AutoGenerateField = false) /*, Required*/ ]
      public bool IsFolder { get; set; }
      //
      [Display(Name = "Name:", GroupName = MainContent, Order = 1)]
      [StringLength(100, MinimumLength = 1)]
      [Required]
      public string Name { get; set; }
      //
      [Display(Name = "Connection String:"
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
      [StringLength(100, MinimumLength = 1)]
      [Required]
      public string ConnectionString { get; set; }
      //
      [Display(Name = "Login ID:"
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
      [StringLength(100, MinimumLength = 1)]
      public string Login { get; set; }
      //
      [Display(Name = "Password:", GroupName = ConnectionGroup, Order = 3)]
      [DataType(DataType.Password)]
      [StringLength(100, MinimumLength = 8)]
      public string Password { get; set; }
      //
      [Display(Name = "Active?", GroupName = ConnectionFlagsGroup, Order = 6)]
      public bool IsActive { get; set; }
      //
      [Display(Name = "Connection Tested?", GroupName = ConnectionFlagsGroup, Order = 5)]
      [ReadOnly(true)]
      public bool ConnectionWasTested { get; set; }
      //
      [Display(Name = "Server:", GroupName = ServerGroup)]
      [DataType(DataType.Url)]
      [StringLength(4096, MinimumLength = 1)]
      public string Server { get; set; }
      //
      [Display(Name = "Port:", GroupName = ServerGroup)]
      [Range(0, 65535)]
      public int Port { get; set; }
      //
      [Display(Name = "Syntax Provider:", GroupName = ProvidersGroup), Required]
      [EnumDataType(typeof(SyntaxProviderEnum))]
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
      [Display(Name = "Metadata Provider:", GroupName = ProvidersGroup), Required]
      [EnumDataType(typeof(MetadataProviderEnum))]
      public int MetadataProvider { get; set; }
      public enum MetadataProviderEnum
      {
         AUTO = 0,
         GENERIC,
         MS_SQL_SERVER,
      }
      //
      [Display(Name = "Preview:", GroupName = PreviewGroup)]
      [DataType(DataType.MultilineText)]
      public string Preview { get; set; }
      //
      [Display(Name = "Description:", GroupName = DescriptionGroup)]
      [DataType(DataType.MultilineText)]
      public string Description { get; set; }

      [Display(Name = "Properties:", GroupName = ConnectionGroup, Order = 4)]
      public List<Props> Props { get; set; }

      public DataStore2()
      {
         Props = new List<Props>()
                {
                    new Props("propA1", "valueB1"),
                    new Props("propA2", "valueB2"),
                    new Props("propA3", "valueB3"),
                };

      }
   }

   [Serializable()]
   public class Props
   {
      [Display(Name = "Key:")]
      [StringLength(100, MinimumLength = 1)]
      public string Key { get; set; }
      [Display(Name = "Value:")]
      [StringLength(100, MinimumLength = 1)]
      public string Value { get; set; }
      [Display(Name = "Active?")]
      public bool IsActive { get; set; }

      public Props()
      {
      }

      public Props(string key, string value)
      {
         Key = key ?? throw new ArgumentNullException(nameof(key));
         Value = value ?? throw new ArgumentNullException(nameof(value));
      }
   }
}