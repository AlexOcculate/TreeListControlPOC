namespace AQBTest
{
   public partial class MetadataItemFQNForm : DevExpress.XtraEditors.XtraForm
   {
      private ActiveQueryBuilder.View.WinForms.QueryBuilder qb;
      private DataStoreCollection dsColl;
      public MetadataItemFQNForm()
      {
         InitializeComponent( );
      }

      public MetadataItemFQNForm( DataStoreCollection dsColl )
         : this()
      {
         this.dsColl = dsColl ?? throw new System.ArgumentNullException( nameof( dsColl ) );
         for( int i = 0; i < this.dsColl.List.Count; i++ )
         {
            DataStore ds = this.dsColl.List[ i ];
            if( !ds.IsActive )
            {
               continue;
            }
            if( ds.IsToPullRemotely )
            {
               DataStore.SyntaxProviderEnum x = (DataStore.SyntaxProviderEnum) ds.SyntaxProvider;
               switch( x )
               {
                  case DataStore.SyntaxProviderEnum.SQLITE:
                     this.qb = CreateQueryBuilderSQLite( ds );
                     break;
                  case DataStore.SyntaxProviderEnum.MS_SQL_SERVER_2014:
                     this.qb = CreateQueryBuilderMSSQL( ds );
                     break;
                  case DataStore.SyntaxProviderEnum.AUTO:
                     break;
                  case DataStore.SyntaxProviderEnum.GENERIC:
                     break;
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
               }
               { // Export AQB's Query Builder XML Structures...
                  ExtractMetadataValues.SerializeQueryBuilder( this.qb, ds.AqbQbFilename );
               }
               MetadataItemFQNCollection o = new MetadataItemFQNCollection( );
               o.List = ExtractMetadataValues.BuildBindingList( this.qb );
               { // Export MetadataItem FQN Collection...
                  o.Save( ds.MiFqnFilename );
               }
               this.gridControl1.DataSource = o.List;
            }
            else
            {
               MetadataItemFQNCollection o = MetadataItemFQNCollection.Load( ds.MiFqnFilename );
               this.gridControl1.DataSource = o.List;
            }
         }
      }

      public MetadataItemFQNForm( string connectionString, string aqbQbXmlFilename, bool loadDefaultDatabaseOnly = true, bool loadSystemObjects = false, bool withFields = true )
      {
         bool isToPullRemotelly = false;
         bool isMSSQL = false;
         InitializeComponent( );
         {
            if( !isMSSQL )
            { // IT IS A SQLITE DBMS...
               //connectionString = @"Data Source=D:\TEMP\SQLite\SQLITEDB1.db3;";
               connectionString = @"Data Source=D:\TEMP\SQLite\chinook\chinook.db;";
               aqbQbXmlFilename = @"D:\TEMP\SQLite\MetadataSQLiteTestWithFields.xml";
               string miFqnXmlFilename = @"D:\TEMP\SQLite\SqliteMiFqn.xml";
               if( isToPullRemotelly )
               {
                  this.qb = CreateQueryBuilderSQLite( connectionString, loadDefaultDatabaseOnly, loadSystemObjects, withFields );
                  { // Export AQB's Query Builder XML Structures...
                     ExtractMetadataValues.SerializeQueryBuilder( this.qb, aqbQbXmlFilename );
                  }
                  MetadataItemFQNCollection o = new MetadataItemFQNCollection( );
                  o.List = ExtractMetadataValues.BuildBindingList( this.qb );
                  { // Export MetadataItem FQN Collection...
                     o.Save( miFqnXmlFilename );
                  }
                  this.gridControl1.DataSource = o.List;
               }
               else
               {
                  MetadataItemFQNCollection p = MetadataItemFQNCollection.Load( miFqnXmlFilename );
                  this.gridControl1.DataSource = p.List;
               }
            }
            else
            {  // IS MSSQL DBMS...
               connectionString = @"Data Source=DBSRV\QWERTY;Database=Sales;User Id=user02;Password=8a0IucJ@Nx1Qy5HfFrX0Ob3m;";
               aqbQbXmlFilename = @"D:\TEMP\SQLite\MetadataMSSQLTestWithFields.xml";
               string miFqnXmlFilename = @"D:\TEMP\SQLite\MssqlMiFqn.xml";
               if( isToPullRemotelly )
               {
                  this.qb = CreateQueryBuilderMSSQL( connectionString, loadDefaultDatabaseOnly, loadSystemObjects, withFields );
                  { // Export AQB's Query Builder XML Structures...
                     ExtractMetadataValues.SerializeQueryBuilder( this.qb, aqbQbXmlFilename );
                  }
                  MetadataItemFQNCollection o = new MetadataItemFQNCollection( );
                  o.List = ExtractMetadataValues.BuildBindingList( this.qb );
                  { // Export MetadataItem FQN Collection...
                     o.Save( miFqnXmlFilename );
                  }
                  this.gridControl1.DataSource = o.List;
               }
               else
               {
                  MetadataItemFQNCollection p = MetadataItemFQNCollection.Load( miFqnXmlFilename );
                  this.gridControl1.DataSource = p.List;
               }
            }
         }
         ExtractMetadataValues.ConfigGridControl( this.gridControl1, this.gridView1 );
         // QueryBuilder.ShowMetadataContainerLoadWizard( this.qb.MetadataContainer, this.qb.MetadataLoadingOptions );
         // MetadataEditorOptions o = MetadataEditorOptions.HideLoadDatabaseButton;
         // QueryBuilder.EditMetadataContainer( this.qb.MetadataContainer, this.qb.MetadataStructure, this.qb.MetadataLoadingOptions );
      }

      #region --- MSSQL... ---
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

         //   this.dsColl = dsColl;
         //   InitializeComponent( );
         //   //bool isToPullRemotelly = false;
         //   //bool isMSSQL = false;
         //   {
         //      if( !isMSSQL )
         //      { // IT IS A SQLITE DBMS...
         //         //connectionString = @"Data Source=D:\TEMP\SQLite\SQLITEDB1.db3;";
         //         connectionString = @"Data Source=D:\TEMP\SQLite\chinook\chinook.db;";
         //         aqbQbXmlFilename = @"D:\TEMP\SQLite\MetadataSQLiteTestWithFields.xml";
         //         string miFqnXmlFilename = @"D:\TEMP\SQLite\SqliteMiFqn.xml";
         //         if( isToPullRemotelly )
         //         {
         //            this.qb = CreateQueryBuilderSQLite( connectionString, loadDefaultDatabaseOnly, loadSystemObjects, withFields );
         //            { // Export AQB's Query Builder XML Structures...
         //               ExtractMetadataValues.SerializeQueryBuilder( this.qb, aqbQbXmlFilename );
         //            }
         //            MetadataItemFQNCollection o = new MetadataItemFQNCollection( );
         //            o.List = ExtractMetadataValues.BuildBindingList( this.qb );
         //            { // Export MetadataItem FQN Collection...
         //               o.Save( miFqnXmlFilename );
         //            }
         //            this.gridControl1.DataSource = o.List;
         //         }
         //         else
         //         {
         //            MetadataItemFQNCollection p = MetadataItemFQNCollection.Load( miFqnXmlFilename );
         //            this.gridControl1.DataSource = p.List;
         //         }
         //      }
         //      else
         //      {  // IS MSSQL DBMS...
         //         connectionString = @"Data Source=DBSRV\QWERTY;Database=Sales;User Id=user02;Password=8a0IucJ@Nx1Qy5HfFrX0Ob3m;";
         //         aqbQbXmlFilename = @"D:\TEMP\SQLite\MetadataMSSQLTestWithFields.xml";
         //         string miFqnXmlFilename = @"D:\TEMP\SQLite\MssqlMiFqn.xml";
         //         if( isToPullRemotelly )
         //         {
         //            this.qb = CreateQueryBuilderMSSQL( connectionString, loadDefaultDatabaseOnly, loadSystemObjects, withFields );
         //            { // Export AQB's Query Builder XML Structures...
         //               ExtractMetadataValues.SerializeQueryBuilder( this.qb, aqbQbXmlFilename );
         //            }
         //            MetadataItemFQNCollection o = new MetadataItemFQNCollection( );
         //            o.List = ExtractMetadataValues.BuildBindingList( this.qb );
         //            { // Export MetadataItem FQN Collection...
         //               o.Save( miFqnXmlFilename );
         //            }
         //            this.gridControl1.DataSource = o.List;
         //         }
         //         else
         //         {
         //            MetadataItemFQNCollection p = MetadataItemFQNCollection.Load( miFqnXmlFilename );
         //            this.gridControl1.DataSource = p.List;
         //         }
         //      }
         //   }
         //   ExtractMetadataValues.ConfigGridControl( this.gridControl1, this.gridView1 );
         //   // QueryBuilder.ShowMetadataContainerLoadWizard( this.qb.MetadataContainer, this.qb.MetadataLoadingOptions );
         //   // MetadataEditorOptions o = MetadataEditorOptions.HideLoadDatabaseButton;
         //   // QueryBuilder.EditMetadataContainer( this.qb.MetadataContainer, this.qb.MetadataStructure, this.qb.MetadataLoadingOptions );



      public Form1( string connectionString, string filename, bool loadDefaultDatabaseOnly = true, bool loadSystemObjects = false, bool withFields = true )
      {
         InitializeComponent( );
         {
            ////connectionString = @"Data Source=D:\TEMP\SQLite\SQLITEDB1.db3;";
            //connectionString = @"Data Source=D:\TEMP\SQLite\chinook\chinook.db;";
            //filename = @"D:\TEMP\SQLite\MetadataSQLiteTestWithFields.xml";
            //this.qb = ExtractMetadataValues.CreateQueryBuilderSQLite( connectionString, loadDefaultDatabaseOnly, loadSystemObjects, withFields );
            this.gridControl1.DataSource = ExtractMetadataValues.BuildBindingList( this.qb );
            //this.gridControl1.DataSource = buildBindingListSQLite( this.qb );
         }
         {
            connectionString = @"Data Source=DBSRV\QWERTY;Database=Sales;User Id=user02;Password=8a0IucJ@Nx1Qy5HfFrX0Ob3m;";
            filename = @"D:\TEMP\SQLite\MetadataMSSQLTestWithFields.xml";
            this.qb = CreateQueryBuilderMSSQL( connectionString, loadDefaultDatabaseOnly, loadSystemObjects, withFields );
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

*/
