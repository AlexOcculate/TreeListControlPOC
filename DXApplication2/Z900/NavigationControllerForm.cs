using ActiveQueryBuilder.Core;
using ActiveQueryBuilder.View.WinForms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Z900.Model;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.Xpo.DB;

namespace Z900
{
   public partial class NavigationControllerForm : DevExpress.XtraBars.Ribbon.RibbonForm
   {
      private XtraUserControl employeesUserControl;
      private XtraUserControl customersUserControl;
      private XtraUserControl dataStoresUserControl;
      private XtraUserControl configPathsUserControl;
      private ConfigPathCollection cpColl;
      private DataStoreCollection dsColl;
      public NavigationControllerForm()
      {
         InitializeComponent( );
      }

      #region --- GUI Events... ---
      private void NavigationControllerForm_Load( object sender, EventArgs e )
      {
         this.cpColl = ConfigPathCollection.Load( );
         this.dsColl = DataStoreCollection.Load( this.cpColl.GetDirList( ConfigPath.ConfigPathTypeEnum.DataStores ) );
         this.RecreateUserControls( );
      }

      private void NavigationControllerForm_FormClosing( object sender, System.Windows.Forms.FormClosingEventArgs e )
      {
         this.cpColl?.Save( );
         this.dsColl?.Save( );
      }
      private void NavigationControllerForm_FormClosed( object sender, System.Windows.Forms.FormClosedEventArgs e )
      {

      }
      private void accordionControl_SelectedElementChanged( object sender, SelectedElementChangedEventArgs e )
      {
         if( e.Element == null ) return;
         //XtraUserControl userControl = e.Element.Text == "Employees" ? employeesUserControl : customersUserControl;
         //tabbedView.AddDocument(userControl);
         //tabbedView.ActivateDocument(userControl);
         XtraUserControl uc; ;
         if( e.Element == this.dataStoresAccordionControlElement )
         {
            uc = this.dataStoresUserControl;
            //this.dataStoresUserControl.Focus();
         }
         else if( e.Element == this.configPathsAccordionControlElement )
         {
            uc = this.configPathsUserControl;
         }
         else if( e.Element == this.employeesAccordionControlElement )
         {
            uc = this.employeesUserControl;
         }
         else if( e.Element == this.customersAccordionControlElement )
         {
            uc = this.customersUserControl;
         }
         else
         {
            return;
         }
         this.tabbedView.AddDocument( uc );
         this.tabbedView.ActivateDocument( uc );
         RibbonControl mergedRibbon = this.ribbonControl.MergedRibbon;
         if( mergedRibbon == null )
            return;
         this.ribbonControl.SelectedPage = mergedRibbon.Pages[ "Home" ];
      }
      private void barButtonNavigation_ItemClick( object sender, ItemClickEventArgs e )
      {
         //int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
         //accordionControl.SelectedElement = mainAccordionGroup.Elements[barItemIndex];
         BarItem item = e.Item;
         if( item == this.dataStoresBarButtonItem )
         {
            this.accordionControl.SelectedElement = this.dataStoresAccordionControlElement;
         }
         else if( item == this.configPathsBarButtonItem )
         {
            this.accordionControl.SelectedElement = this.configPathsAccordionControlElement;
         }
         else if( item == this.employeesBarButtonItem )
         {
            this.accordionControl.SelectedElement = this.employeesAccordionControlElement;
         }
         else if( item == this.customersBarButtonItem )
         {
            this.accordionControl.SelectedElement = this.customersAccordionControlElement;
         }
      }
      private void tabbedView_DocumentClosed( object sender, DocumentEventArgs e )
      {
         RecreateUserControls( e );
         SetAccordionSelectedElement( e );
      }
      private void tabbedView_DocumentActivated( object sender, DocumentEventArgs e )
      {
         var control = e.Document.Control;
         var caption = e.Document.Caption;
         if( control as DataStoreCollectionXUC != null )
            this.accordionControl.SelectedElement = this.dataStoresAccordionControlElement;
         else if( control as ConfigPathsCollectionXUC != null )
            this.accordionControl.SelectedElement = this.configPathsAccordionControlElement;
         else if( control as XtraUserControl != null )
         {
            if( caption == "Employees" )
               this.accordionControl.SelectedElement = this.employeesAccordionControlElement;
            else if( caption == "Customers" )
               this.accordionControl.SelectedElement = this.customersAccordionControlElement;
         }
      }
      #endregion

      private void SetAccordionSelectedElement( DocumentEventArgs e )
      {
         if( this.tabbedView.Documents.Count == 0 )
         {
            this.accordionControl.SelectedElement = null;
         }
         else
         {
            var control = this.tabbedView.Documents[ 0 ].Control;
            if( control as DataStoreCollectionXUC != null )
               this.accordionControl.SelectedElement = this.dataStoresAccordionControlElement;
            else if( control as ConfigPathsCollectionXUC != null )
               this.accordionControl.SelectedElement = this.configPathsAccordionControlElement;
            else if( control as XtraUserControl != null )
            {
               if( this.tabbedView.Documents[ 0 ].Caption == "Employees" )
                  this.accordionControl.SelectedElement = this.employeesAccordionControlElement;
               else if( this.tabbedView.Documents[ 0 ].Caption == "Customers" )
                  this.accordionControl.SelectedElement = this.customersAccordionControlElement;
            }
         }
      }
      private void RecreateUserControls( DocumentEventArgs e = null )
      {
         if( e == null || e.Document.Caption == "Paths" )
         {
            this.configPathsUserControl = this.CreateConfigPathsUserControl( "Paths" );
         }
         if( e == null || e.Document.Caption == "DataStores" )
         {
            this.dataStoresUserControl = CreateDataStoreUserControl( "DataStores" );
         }
         if( e == null || e.Document.Caption == "Employees" )
         {
            this.employeesUserControl = CreateEmpregadoUserControl( "Employees" );
         }
         if( e == null || e.Document.Caption == "Customers" )
         {
            this.customersUserControl = CreateUserControl( "Customers" );
         }
         if( e == null )
         {
            this.accordionControl.SelectedElement = this.configPathsAccordionControlElement;
         }
      }
      private XtraUserControl CreateConfigPathsUserControl( string text )
      {
         XtraUserControl result = new ConfigPathsCollectionXUC( this.cpColl );
         result.Name = text.ToLower( ) + "UserControl";
         result.Text = text;
         LabelControl label = new LabelControl( );
         label.Parent = result;
         label.Appearance.Font = new Font( "Tahoma", 25.25F );
         label.Appearance.ForeColor = Color.Gray;
         label.Dock = System.Windows.Forms.DockStyle.Fill;
         label.AutoSizeMode = LabelAutoSizeMode.None;
         label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
         label.Text = text;
         return result;
      }
      private XtraUserControl CreateDataStoreUserControl( string text )
      {
         XtraUserControl result = new DataStoreCollectionXUC( this.dsColl );
         result.Name = text.ToLower( ) + "UserControl";
         result.Text = text;
         LabelControl label = new LabelControl( );
         label.Parent = result;
         label.Appearance.Font = new Font( "Tahoma", 25.25F );
         label.Appearance.ForeColor = Color.Gray;
         label.Dock = System.Windows.Forms.DockStyle.Fill;
         label.AutoSizeMode = LabelAutoSizeMode.None;
         label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
         label.Text = text;
         return result;
      }
      private XtraUserControl CreateUserControl( string text )
      {
         XtraUserControl result = new XtraUserControl( );
         result.Name = text.ToLower( ) + "UserControl";
         result.Text = text;
         LabelControl label = new LabelControl( );
         label.Parent = result;
         label.Appearance.Font = new Font( "Tahoma", 25.25F );
         label.Appearance.ForeColor = Color.Gray;
         label.Dock = System.Windows.Forms.DockStyle.Fill;
         label.AutoSizeMode = LabelAutoSizeMode.None;
         label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
         label.Text = text;
         return result;
      }
      private XtraUserControl CreateEmpregadoUserControl( string text )
      {
         BindingList<DataStore> dataStores = this.dsColl.GetDataStores( );
         this.createQueryBuilder( dataStores[ 0 ].ConnectionString );
         XtraUserControl result = new XtraUserControl( );
         result.Name = text.ToLower( ) + "UserControl";
         result.Text = text;
         LabelControl label = new LabelControl( );
         label.Parent = result;
         label.Appearance.Font = new Font( "Tahoma", 25.25F );
         label.Appearance.ForeColor = Color.Gray;
         label.Dock = System.Windows.Forms.DockStyle.Fill;
         label.AutoSizeMode = LabelAutoSizeMode.None;
         label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
         label.Text = text;
         return result;
      }

      private QueryBuilder _qb;
      private void createQueryBuilder( string connectionString, bool loadDefaultDatabaseOnly = false, bool loadSystemObjects = false, bool withFields = true )
      {
         this._qb = new QueryBuilder( )
         {
            SyntaxProvider = new SQLiteSyntaxProvider( ),
            MetadataProvider = new SQLiteMetadataProvider( )
         };
         SQLiteConnectionParameters connParms = new SQLiteConnectionParameters( );
         connParms.FileName = connectionString;
         connParms.Password = "password";
         //string cs = SQLiteConnectionProvider.GetConnectionString( connectionString );
         string cs = @"Data Source=" + connectionString;//+ ";Version=3;";
         this._qb.MetadataProvider.Connection = new System.Data.SQLite.SQLiteConnection( cs );
         {
            MetadataLoadingOptions loadingOptions = this._qb.SQLContext.MetadataContainer.LoadingOptions;
            loadingOptions.LoadDefaultDatabaseOnly = loadDefaultDatabaseOnly;
            loadingOptions.LoadSystemObjects = loadSystemObjects;
            //loadingOptions.IncludeFilter.Types = MetadataType.Field;
            //loadingOptions.ExcludeFilter.Schemas.Add("dbo");
         }
         //qb.InitializeDatabaseSchemaTree();
         this._qb.MetadataContainer.LoadAll( withFields );
      } // createQueryBuilder(...)

   }
}