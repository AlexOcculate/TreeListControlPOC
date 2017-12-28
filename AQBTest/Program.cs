namespace AQBTest
{
   static class Program
   {
      private static DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager tnm;

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [System.STAThread]
      static void Main()
      {
         System.Windows.Forms.Application.EnableVisualStyles( );
         System.Windows.Forms.Application.SetCompatibleTextRenderingDefault( false );

         DevExpress.UserSkins.BonusSkins.Register( );
         DevExpress.Skins.SkinManager.EnableFormSkins( );

         dsColl = DataStoreCollection.Load( DataStoreCollectionFileName );
         {
            DataStoreXtraForm o = new DataStoreXtraForm( dsColl );
            o.taskbarAssistant1.ProgressMode = DevExpress.Utils.Taskbar.Core.TaskbarButtonProgressMode.Error;
            //o.taskbarAssistant1.ProgressMode = DevExpress.Utils.Taskbar.Core.TaskbarButtonProgressMode.Indeterminate;
            //o.taskbarAssistant1.ProgressMode = DevExpress.Utils.Taskbar.Core.TaskbarButtonProgressMode.NoProgress;
            //o.taskbarAssistant1.ProgressMode = DevExpress.Utils.Taskbar.Core.TaskbarButtonProgressMode.Normal;
            //o.taskbarAssistant1.ProgressMode = DevExpress.Utils.Taskbar.Core.TaskbarButtonProgressMode.Paused;
            System.Windows.Forms.Application.Run( o );
            //o.taskbarAssistant1.ProgressMaximumValue = 10;
            //o.taskbarAssistant1.ProgressCurrentValue = 2;
            //o.taskbarAssistant1.Refresh( );
            //o.taskbarAssistant1.ProgressCurrentValue = 5;
            //o.taskbarAssistant1.Refresh( );
            //o.taskbarAssistant1.ProgressCurrentValue = 1;
            //o.taskbarAssistant1.Refresh( );
            //o.taskbarAssistant1.ProgressCurrentValue = 8;
            //o.taskbarAssistant1.Refresh( );
            //o.taskbarAssistant1.ProgressCurrentValue = 10;
            //o.taskbarAssistant1.Refresh( );
            {
               // Create a regular custom button. 
               var svgBitmap = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\db_red.svg" );
               DevExpress.XtraBars.Alerter.AlertButton btn1 = new DevExpress.XtraBars.Alerter.AlertButton( svgBitmap.Render( null, 0.5 ) );
               btn1.Hint = "Open file";
               btn1.Name = "buttonOpen";
               // Create a check custom button. 
               var svgBitmap1 = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\sch_red.svg" );

               DevExpress.XtraBars.Alerter.AlertButton btn2 = new DevExpress.XtraBars.Alerter.AlertButton( svgBitmap1.Render( null, 0.5 ) );
               btn2.Style = DevExpress.XtraBars.Alerter.AlertButtonStyle.CheckButton;
               btn2.Down = true;
               btn2.Hint = "Alert On";
               btn2.Name = "buttonAlert";
               // Add buttons to the AlertControl and subscribe to the events to process button clicks 
               o.alertControl1.Buttons.Add( btn1 );
               o.alertControl1.Buttons.Add( btn2 );
               o.alertControl1.ButtonClick += new DevExpress.XtraBars.Alerter.AlertButtonClickEventHandler( alertControl1_ButtonClick );
               o.alertControl1.ButtonDownChanged += new DevExpress.XtraBars.Alerter.AlertButtonDownChangedEventHandler( alertControl1_ButtonDownChanged );
            }
            // Show a sample alert window. 
            DevExpress.XtraBars.Alerter.AlertInfo info = new DevExpress.XtraBars.Alerter.AlertInfo( "New Window", "Text" );
            o.alertControl1.Show( o, info );
         }
         dsColl.Save( DataStoreCollectionFileName );
         CreateToastNotificationsManager( );
         PullRemotely( dsColl );
      }

      private static void alertControl1_ButtonDownChanged( object sender, DevExpress.XtraBars.Alerter.AlertButtonDownChangedEventArgs e )
      {
         if( e.ButtonName == "buttonOpen" )
         {
            //... 
         }
      }

      private static void alertControl1_ButtonClick( object sender, DevExpress.XtraBars.Alerter.AlertButtonClickEventArgs e )
      {
         if( e.ButtonName == "buttonAlert" )
         {
            //... 
         }
      }

      private static DataStoreCollection dsColl;
      private static string DataStoreCollectionFileName = @"D:\TEMP\SQLite\DataStoreCollection.xml";

      private static void CreateToastNotificationsManager()
      {
         tnm = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager( );
         ((System.ComponentModel.ISupportInitialize) (tnm)).BeginInit( );
         {
            tnm.ApplicationId = "74fdcbed-8893-48df-8872-10569d072e21";
            tnm.ApplicationName = "AQBTest";
            tnm.Notifications.AddRange( new DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties[ ] {
            new DevExpress.XtraBars.ToastNotifications.ToastNotification(
               "cf47cb4e-394e-4ac9-a978-111715c1fc56", // id
               null, // image
               "Pellentesque lacinia tellus eget volutpat", // header
               "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor i"
               + "ncididunt ut labore et dolore magna aliqua.", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor i"
               + "ncididunt ut labore et dolore magna aliqua.", // body
               DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.Text04 // template
            )
            } );
         }
         ((System.ComponentModel.ISupportInitialize) (tnm)).EndInit( );
      }

      public static void PullRemotely( DataStoreCollection dsColl )
      {
         dsColl = dsColl ?? throw new System.ArgumentNullException( nameof( dsColl ) );
         for( int i = 0; i < dsColl.List.Count; i++ )
         {
            DataStore ds = dsColl.List[ i ];
            if( !ds.IsActive )
            {
               continue;
            }
            if( ds.IsToPullRemotely )
            {
               #region --- ??? ---
               switch( (DataStore.SyntaxProviderEnum) ds.SyntaxProvider )
               {
                  case DataStore.SyntaxProviderEnum.SQLITE:
                     DumpSQLite( ds );
                     break;
                  case DataStore.SyntaxProviderEnum.MS_SQL_SERVER_2014:
                     DumpMSSQL( ds );
                     break;
                  case DataStore.SyntaxProviderEnum.AUTO:
                  case DataStore.SyntaxProviderEnum.GENERIC:
                  case DataStore.SyntaxProviderEnum.ANSI_SQL_2003:
                  case DataStore.SyntaxProviderEnum.ANSI_SQL_89:
                  case DataStore.SyntaxProviderEnum.ANSI_SQL_92:
                  case DataStore.SyntaxProviderEnum.FIREBIRD_1_0:
                  case DataStore.SyntaxProviderEnum.FIREBIRD_1_5:
                  case DataStore.SyntaxProviderEnum.FIREBIRD_2_0:
                  case DataStore.SyntaxProviderEnum.FIREBIRD_2_5:
                  case DataStore.SyntaxProviderEnum.IBM_DB2:
                  case DataStore.SyntaxProviderEnum.IBM_INFORMIX_10:
                  case DataStore.SyntaxProviderEnum.IBM_INFORMIX_8:
                  case DataStore.SyntaxProviderEnum.IBM_INFORMIX_9:
                  case DataStore.SyntaxProviderEnum.MS_ACCESS_2000_:
                  case DataStore.SyntaxProviderEnum.MS_ACCESS_2003_:
                  case DataStore.SyntaxProviderEnum.MS_ACCESS_97_:
                  case DataStore.SyntaxProviderEnum.MS_ACCESS_XP_:
                  case DataStore.SyntaxProviderEnum.MS_SQL_SERVER_2000:
                  case DataStore.SyntaxProviderEnum.MS_SQL_SERVER_2005:
                  case DataStore.SyntaxProviderEnum.MS_SQL_SERVER_2008:
                  case DataStore.SyntaxProviderEnum.MS_SQL_SERVER_2012:
                  case DataStore.SyntaxProviderEnum.MS_SQL_SERVER_7:
                  case DataStore.SyntaxProviderEnum.MS_SQL_SERVER_COMPACT_EDITION:
                  case DataStore.SyntaxProviderEnum.MYSQL_3_XX:
                  case DataStore.SyntaxProviderEnum.MYSQL_4_0:
                  case DataStore.SyntaxProviderEnum.MYSQL_4_1:
                  case DataStore.SyntaxProviderEnum.MYSQL_5_0:
                  case DataStore.SyntaxProviderEnum.ORACLE_10:
                  case DataStore.SyntaxProviderEnum.ORACLE_11:
                  case DataStore.SyntaxProviderEnum.ORACLE_7:
                  case DataStore.SyntaxProviderEnum.ORACLE_8:
                  case DataStore.SyntaxProviderEnum.ORACLE_9:
                  case DataStore.SyntaxProviderEnum.POSTGRESQL:
                  case DataStore.SyntaxProviderEnum.SYBASE_ASE:
                  case DataStore.SyntaxProviderEnum.SYBASE_SQL_ANYWHERE:
                  case DataStore.SyntaxProviderEnum.TERADATA:
                  case DataStore.SyntaxProviderEnum.VISTADB:
                  default:
                     break;
               } // switch(...) ...
               #endregion
            } // if( ... ) ...
         } // for( ;; ) ...
      } // public static void f( ... ) ...

      private static void Dump( ActiveQueryBuilder.View.WinForms.QueryBuilder qb, DataStore ds )
      {
         string TS_STR = @"D:\TEMP\SQLite\" + DataStore.TS_STR.Replace( ":", "" );
         {
            // Export AQB's Query Builder XML Structures...
            //string xmlStr = qb.MetadataContainer.XML;
            string filename = TS_STR + "." + ds.AqbQbFilename;
            qb.MetadataContainer.ExportToXML( filename );
            // qb.MetadataContainer.ImportFromXML( filename );
         }
         {
            // Export MetadataItem FQN Collection...
            MetadataItemFQNCollection o = new MetadataItemFQNCollection( );
            o.List = ExtractMetadataValues.BuildBindingList( qb );
            string filename = TS_STR + "." + ds.MiFqnFilename;
            o.Save( filename );
         }
         tnm.ShowNotification( tnm.Notifications[ 0 ] );
      }

      #region --- MSSQL... ---
      private static ActiveQueryBuilder.View.WinForms.QueryBuilder DumpMSSQL( DataStore ds )
      {
         ActiveQueryBuilder.View.WinForms.QueryBuilder qb = CreateQueryBuilderMSSQL( ds );
         Dump( qb, ds );
         return qb;
      }

      private static ActiveQueryBuilder.View.WinForms.QueryBuilder CreateQueryBuilderMSSQL( DataStore ds )
      {
         return CreateQueryBuilderMSSQL( ds.ConnectionString, ds.LoadDefaultDatabaseOnly, ds.LoadSystemObjects, ds.WithFields );
      }

      public static ActiveQueryBuilder.View.WinForms.QueryBuilder CreateQueryBuilderMSSQL(
         string connectionString,
         bool loadDefaultDatabaseOnly,
         bool loadSystemObjects,
         bool withFields
      )
      {
         ActiveQueryBuilder.View.WinForms.QueryBuilder qb = new ActiveQueryBuilder.View.WinForms.QueryBuilder( )
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
      private static ActiveQueryBuilder.View.WinForms.QueryBuilder DumpSQLite( DataStore ds )
      {
         ActiveQueryBuilder.View.WinForms.QueryBuilder qb = CreateQueryBuilderSQLite( ds );
         Dump( qb, ds );
         return qb;
      }

      private static ActiveQueryBuilder.View.WinForms.QueryBuilder CreateQueryBuilderSQLite( DataStore ds )
      {
         return CreateQueryBuilderSQLite( ds.ConnectionString, ds.LoadDefaultDatabaseOnly, ds.LoadSystemObjects, ds.WithFields );
      }

      public static ActiveQueryBuilder.View.WinForms.QueryBuilder CreateQueryBuilderSQLite(
         string connectionString,
         bool loadDefaultDatabaseOnly,
         bool loadSystemObjects,
         bool withFields
      )
      {
         ActiveQueryBuilder.View.WinForms.QueryBuilder qb = new ActiveQueryBuilder.View.WinForms.QueryBuilder( )
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
   }
}

/*
      //
      // //public const string ConnectionString = @"XpoProvider=MSSqlServer;data source=DBSRV\QWERTY;user id=user02;password=8a0IucJ@Nx1Qy5HfFrX0Ob3m;";
      public const string ConnectionString = @"Data Source=DBSRV\QWERTY;Database=Sales;User Id=user02;Password=8a0IucJ@Nx1Qy5HfFrX0Ob3m;";
      public const string filename = @"D:\TEMP\SQLite\MetadataMSSQLTestWithFields.xml";
      //
      //public const string ConnectionString = @"Data Source=D:\TEMP\SQLite\SQLITEDB1.db3;";
      //public const string ConnectionString = @"Data Source=D:\TEMP\SQLite\chinook\chinook.db;";
      //public const string filename = @"D:\TEMP\SQLite\MetadataSQLiteTestWithFields.xml";
      //

*/
