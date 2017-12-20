using ActiveQueryBuilder.Core;
using ActiveQueryBuilder.View.WinForms;
using DevExpress.XtraGrid;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

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
            //this.qb = createQueryBuilderSQLite( connectionString, loadDefaultDatabaseOnly, loadSystemObjects, withFields );
            //this.gridControl1.DataSource = buildBindingListSQLiteField2( this.qb );
            ////this.gridControl1.DataSource = buildBindingListSQLite( this.qb );
         }
         {
            connectionString = @"Data Source=DBSRV\QWERTY;Database=Sales;User Id=user02;Password=8a0IucJ@Nx1Qy5HfFrX0Ob3m;";
            filename = @"D:\TEMP\SQLite\MetadataMSSQLTestWithFields.xml";
            this.qb = createQueryBuilderMSSQL( connectionString, loadDefaultDatabaseOnly, loadSystemObjects, withFields );
            //this.gridControl1.DataSource = buildBindingListMSSQL( this.qb );
            this.gridControl1.DataSource = buildBindingListSQLiteField2( this.qb );
         }
         {
            this.gridControl1.ForceInitialize( );
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            //
            this.gridView1.Columns[ ColumnQN.IS_SYSTEM_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ ColumnQN.REFERENCED_OBJECT_NAME_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ ColumnQN.SERVER_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ ColumnQN.DATABASE_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ ColumnQN.SCHEMA_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ ColumnQN.OBJECT_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ ColumnQN.NAMEQUOTED_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ ColumnQN.ALTNAME_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ ColumnQN.FIELD_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ ColumnQN.EXPRESSION_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ ColumnQN.FIELDTYPE_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ ColumnQN.IS_PK_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ ColumnQN.IS_READONLY_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ ColumnQN.DESCRIPTION_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ ColumnQN.TAG_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ ColumnQN.USERDATA_FIELDNAME ].Visible = false;
         }
         //this.serializeQueryBuilder( filename );
         //QueryBuilder.ShowMetadataContainerLoadWizard( this.qb.MetadataContainer, this.qb.MetadataLoadingOptions );
         //MetadataEditorOptions o = MetadataEditorOptions.HideLoadDatabaseButton;

         //         QueryBuilder.EditMetadataContainer( this.qb.MetadataContainer, this.qb.MetadataStructure, this.qb.MetadataLoadingOptions );
      }
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
            SyntaxProvider = new MSSQLSyntaxProvider( ),
            MetadataProvider = new MSSQLMetadataProvider( )
         };
         qb.MetadataProvider.Connection = new SqlConnection( connectionString );
         {
            MetadataLoadingOptions loadingOptions = qb.SQLContext.MetadataContainer.LoadingOptions;
            loadingOptions.LoadDefaultDatabaseOnly = loadDefaultDatabaseOnly;
            loadingOptions.LoadSystemObjects = loadSystemObjects;
            //loadingOptions.IncludeFilter.Types = MetadataType.Field;
            //loadingOptions.ExcludeFilter.Schemas.Add("dbo");
         }
         //qb.InitializeDatabaseSchemaTree();
         //qb.MetadataContainer.LoadAll(withFields);
         return qb;
      } // createQueryBuilder(...)
      private BindingList<ColumnQN> buildBindingListMSSQL( ActiveQueryBuilder.View.WinForms.QueryBuilder qb )
      {
         BindingList<ColumnQN> listDataSource = new BindingList<ColumnQN>( );
         using( var sqlContext = new SQLContext( ) )
         {
            sqlContext.Assign( qb.SQLContext );
            //sqlContext.MetadataContainer.LoadingOptions.LoadDefaultDatabaseOnly = false;
            //sqlContext.MetadataContainer.LoadingOptions.LoadSystemObjects = false;

            using( var databasesList = new MetadataList( sqlContext.MetadataContainer ) )
            {
               databasesList.Load( MetadataType.Database, false );
               foreach( var db in databasesList )
               {
                  using( var schemasList = new MetadataList( db ) )
                  {
                     schemasList.Load( MetadataType.Schema, false );
                     foreach( var sch in schemasList )
                     {
                        using( var tablesList = new MetadataList( sch ) )
                        {
                           tablesList.Load( MetadataType.Table, false );
                           foreach( var tbl in tablesList )
                           {
                              using( var columnsList = new MetadataList( tbl ) )
                              {
                                 columnsList.Load( MetadataType.Field, false );
                                 foreach( var col in columnsList )
                                 {
                                    var colQN = new ColumnQN( db.Name, sch.Name, tbl.Name, col.Name );
                                    listDataSource.Add( colQN );
                                 }
                              }
                           }
                        }
                     }
                  }
               }
            }
         }
         return listDataSource;
      } // buildBindingList(...)
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
            MetadataLoadingOptions loadingOptions = qb.SQLContext.MetadataContainer.LoadingOptions;
            loadingOptions.LoadDefaultDatabaseOnly = loadDefaultDatabaseOnly;
            loadingOptions.LoadSystemObjects = loadSystemObjects;
            //loadingOptions.IncludeFilter.Types = MetadataType.Field;
            //loadingOptions.ExcludeFilter.Schemas.Add("dbo");
         }
         qb.InitializeDatabaseSchemaTree( );
         qb.MetadataContainer.LoadAll( withFields );
         return qb;
      } // createQueryBuilder(...)
      private BindingList<ColumnQN> buildBindingListSQLite( ActiveQueryBuilder.View.WinForms.QueryBuilder qb )
      {
         BindingList<ColumnQN> listDataSource = new BindingList<ColumnQN>( );
         using( var sqlContext = new SQLContext( ) )
         {
            sqlContext.Assign( qb.SQLContext );
            //sqlContext.MetadataContainer.LoadingOptions.LoadDefaultDatabaseOnly = false;
            //sqlContext.MetadataContainer.LoadingOptions.LoadSystemObjects = false;

            using( var databasesList = new MetadataList( sqlContext.MetadataContainer ) )
            {
               databasesList.Load( MetadataType.Database, false );
               foreach( var db in databasesList )
               {
                  //using( var schemasList = new MetadataList( db ) )
                  {
                     //schemasList.Load( MetadataType.Schema, false );
                     //foreach( var sch in schemasList )
                     {
                        //using( var tablesList = new MetadataList( sch ) )
                        using( var tablesList = new MetadataList( db ) )
                        {
                           tablesList.Load( MetadataType.Table, false );
                           foreach( var tbl in tablesList )
                           {
                              using( var columnsList = new MetadataList( tbl ) )
                              {
                                 columnsList.Load( MetadataType.Field, false );
                                 foreach( var col in columnsList )
                                 {
                                    //var colQN = new ColumnQN( db.Name, sch.Name, tbl.Name, col.Name );
                                    var colQN = new ColumnQN( db.Name, null, tbl.Name, col.Name );
                                    listDataSource.Add( colQN );
                                 }
                              }
                           }
                        }
                     }
                  }
               }
            }
         }
         return listDataSource;
      } // buildBindingList(...)

      class StackItem
      {
         public MetadataList list;
         public int index;
      }
      private BindingList<ColumnQN> buildBindingListSQLiteField2( ActiveQueryBuilder.View.WinForms.QueryBuilder qb )
      {
         BindingList<ColumnQN> listDataSource = new BindingList<ColumnQN>( );
         using( var sqlContext = new SQLContext( ) )
         {
            sqlContext.Assign( this.qb.SQLContext );
            //sqlContext.MetadataContainer.LoadingOptions.LoadDefaultDatabaseOnly = false;
            //sqlContext.MetadataContainer.LoadingOptions.LoadSystemObjects = false;

            using( MetadataList miList = new MetadataList( sqlContext.MetadataContainer ) )
            {
               miList.Load( MetadataType.All, true );
               Stack<StackItem> a = new Stack<StackItem>( );
               a.Push( new StackItem { list = miList, index = 0 } );
               do
               {
                  StackItem si = a.Pop( );
                  MetadataList actualMIList = si.list;
                  int actualIndex = si.index;
                  for( ; actualIndex < actualMIList.Count; actualIndex++ )
                  {
                     ExtractMetadataItem( listDataSource, actualMIList[ actualIndex ] );
                     if( actualMIList[ actualIndex ].Items.Count > 0 ) // branch...
                     {
                        // Push the "next" Item...
                        a.Push( new StackItem { list = actualMIList, index = actualIndex + 1 } );
                        // Reset the loop to process the "actual" Item...
                        actualMIList = actualMIList[ actualIndex ].Items;
                        actualIndex = -1;
                     }
                  } // for(;;)...
               } while( a.Count > 0 );
            } // using()...
         } // using()...
         return listDataSource;
      } // buildBindingList(...)
      private BindingList<ColumnQN> buildBindingListSQLiteField( ActiveQueryBuilder.View.WinForms.QueryBuilder qb )
      {
         BindingList<ColumnQN> listDataSource = new BindingList<ColumnQN>( );
         using( var sqlContext = new SQLContext( ) )
         {
            sqlContext.Assign( this.qb.SQLContext );
            //sqlContext.MetadataContainer.LoadingOptions.LoadDefaultDatabaseOnly = false;
            //sqlContext.MetadataContainer.LoadingOptions.LoadSystemObjects = false;

            using( MetadataList miList = new MetadataList( sqlContext.MetadataContainer ) )
            {
               miList.Load( MetadataType.All, true );
               Stack<StackItem> a = new Stack<StackItem>( );
               a.Push( new StackItem { list = miList, index = 0 } );
               do
               {
                  StackItem si = a.Pop( );
                  MetadataList actualMIList = si.list;
                  int actualIndex = si.index;
                  for( ; actualIndex < actualMIList.Count; actualIndex++ )
                  {
                     switch( actualMIList[ actualIndex ].Type )
                     {
                        case MetadataType.Root:
                           break;
                        case MetadataType.Server:
                           break;
                        case MetadataType.Database:
                           ExtractItem( listDataSource, actualMIList[ actualIndex ] );
                           if( actualMIList[ actualIndex ].Items.Count > 0 ) // branch...
                           {
                              a.Push( new StackItem { list = actualMIList, index = actualIndex + 1 } );
                              actualMIList = actualMIList[ actualIndex ].Items;
                              actualIndex = -1;
                           }
                           break;
                        case MetadataType.Schema:
                           break;
                        case MetadataType.Package:
                           break;
                        case MetadataType.Namespaces:
                           break;
                        case MetadataType.Table:
                           ExtractTable( listDataSource, actualMIList[ actualIndex ] );
                           if( actualMIList[ actualIndex ].Items.Count > 0 ) // branch...
                           {
                              a.Push( new StackItem { list = actualMIList, index = actualIndex + 1 } );
                              actualMIList = actualMIList[ actualIndex ].Items;
                              actualIndex = -1;
                           }
                           //a.Push( new StackItem { list = actualMIList, index = actualIndex + 1 } );
                           //actualMIList = actualMIList[ actualIndex ].Items;
                           //actualIndex = -1;
                           break;
                        case MetadataType.View:
                           break;
                        case MetadataType.Procedure:
                           break;
                        case MetadataType.Synonym:
                           break;
                        case MetadataType.Objects:
                           break;
                        case MetadataType.Aggregate:
                           break;
                        case MetadataType.Parameter:
                           break;
                        case MetadataType.Field:
                           ExtractField( listDataSource, actualMIList[ actualIndex ] );
                           if( actualMIList[ actualIndex ].Items.Count > 0 ) // branch...
                           {
                              a.Push( new StackItem { list = actualMIList, index = actualIndex + 1 } );
                              actualMIList = actualMIList[ actualIndex ].Items;
                              actualIndex = -1;
                           }
                           break;
                        case MetadataType.ForeignKey:
                           ExtractForeignKey( listDataSource, actualMIList[ actualIndex ] );
                           if( actualMIList[ actualIndex ].Items.Count > 0 ) // branch...
                           {
                              a.Push( new StackItem { list = actualMIList, index = actualIndex + 1 } );
                              actualMIList = actualMIList[ actualIndex ].Items;
                              actualIndex = -1;
                           }
                           break;
                        case MetadataType.ObjectMetadata:
                           break;
                        case MetadataType.UserQuery:
                           break;
                        case MetadataType.UserField:
                           break;
                        case MetadataType.All:
                           break;
                        default:
                           break;
                     } // switch()...
                  } // for(;;)...
               } while( a.Count > 0 );
            } // using()...
         } // using()...
         return listDataSource;
      } // buildBindingList(...)

      private void ExtractMetadataItem( BindingList<ColumnQN> list, MetadataItem mi )
      {
         if( mi == null ) return;
         switch( mi.Type )
         {
            case MetadataType.Root:
               break;
            case MetadataType.Server:
               break;
            case MetadataType.Database:
               ExtractNamespace( list, mi );
               break;
            case MetadataType.Schema:
               ExtractNamespace( list, mi );
               break;
            case MetadataType.Package:
               break;
            case MetadataType.Namespaces:
               break;
            case MetadataType.Table:
               ExtractTable( list, mi );
               break;
            case MetadataType.View:
               ExtractTable( list, mi );
               break;
            case MetadataType.Procedure:
               ExtractTable( list, mi );
               break;
            case MetadataType.Synonym:
               break;
            case MetadataType.Objects:
               break;
            case MetadataType.Aggregate:
               break;
            case MetadataType.Parameter:
               break;
            case MetadataType.Field:
               ExtractField( list, mi );
               break;
            case MetadataType.ForeignKey:
               ExtractForeignKey( list, mi );
               break;
            case MetadataType.ObjectMetadata:
               break;
            case MetadataType.UserQuery:
               break;
            case MetadataType.UserField:
               break;
            case MetadataType.All:
               break;
            default:
               break;
         } // switch()...
      }
      private static void ExtractNamespace( BindingList<ColumnQN> listDataSource, MetadataItem mi )
      {
         if( mi == null ) return;
         var o = ExtractItem( listDataSource, mi );
         {
            MetadataNamespace m = mi as MetadataNamespace;
         }
      }
      private static void ExtractTable( BindingList<ColumnQN> listDataSource, MetadataItem mi )
      {
         if( mi == null ) return;
         var o = ExtractItem( listDataSource, mi );
         {
            MetadataObject m = mi as MetadataObject;
         }
      }
      private static void ExtractForeignKey( BindingList<ColumnQN> listDataSource, MetadataItem mi )
      {
         if( mi == null ) return;
         var o = ExtractItem( listDataSource, mi );
         o.FieldType = null;
         {
            MetadataForeignKey m = mi as MetadataForeignKey;
            o.ReferencedObject = m.ReferencedObject.NameFull;
            //
            for( int i = 0; i < m.ReferencedObjectName.Count; i++ )
            {
               MetadataQualifiedNamePart x = m.ReferencedObjectName[ i ];
               o.ReferencedObjectName += "["
               + Enum.GetName( typeof( MetadataType ), x.Type )
               + ":"
               + x.Name
               + "]"
            ;
            }
            //
            o.ReferencedFieldsCount = m.ReferencedFields.Count;
            for( int i = 0; i < m.ReferencedFields.Count; i++ )
            {
               o.ReferencedFields += "[" + m.ReferencedFields[ i ] + "]"
            ;
            }
            //
            o.ReferencedCardinality = Enum.GetName( typeof( MetadataForeignKeyCardinality ), m.ReferencedCardinality );
            //
            o.FieldsCount = m.Fields.Count;
            for( int i = 0; i < m.Fields.Count; i++ )
            {
               o.Fields += "[" + m.Fields[ i ] + "]"
            ;
            }
            //
            o.Cardinality = Enum.GetName( typeof( MetadataForeignKeyCardinality ), m.Cardinality );
         }
      }
      private static void ExtractField( BindingList<ColumnQN> listDataSource, MetadataItem mi )
      {
         if( mi == null ) return;
         var o = ExtractItem( listDataSource, mi );
         {
            MetadataField m = mi as MetadataField;
            o.Expression = m.Expression;
            o.FieldType = Enum.GetName( typeof( System.Data.DbType ), m.FieldType );
            o.FieldTypeName = m.FieldTypeName;
            o.IsNullable = m.Nullable;
            o.Precision = m.Precision;
            o.Scale = m.Scale;
            o.Size = m.Size;
            o.IsPK = m.PrimaryKey;
            o.IsRO = m.ReadOnly;
         }
      }
      private static ColumnQN ExtractItem( BindingList<ColumnQN> listDataSource, MetadataItem mi )
      {
         var o = new ColumnQN( );
         {
            o.Type = Enum.GetName( typeof( MetadataType ), mi.Type );
            o.IsSystem = mi.System;
            //
            // o.RootName = item.Root?.Name;
            o.Server = mi.Server?.Name;
            o.Database = mi.Database?.Name;
            o.Schema = mi.Schema?.Name;
            o.ObjectName = mi.Object?.Name;
            //
            o.NameFullQualified = mi.NameFull;
            o.NameFullQualified += mi.NameFull.EndsWith( "." ) ? "<?>" : "";
            o.NameQuoted = mi.NameQuoted;
            o.AltName = mi.AltName;
            o.Field = mi.Name;
            //
            o.HasDefault = mi.Default;
            o.Description = mi.Description;
            o.Tag = mi.Tag;
            o.UserData = mi.UserData;
         }
         listDataSource.Add( o );
         return o;
      }
      #endregion
   }
}
