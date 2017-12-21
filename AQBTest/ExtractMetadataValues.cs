namespace AQBTest
{
   public class ExtractMetadataValues
   {
      private class StackItem
      {
         public ActiveQueryBuilder.Core.MetadataList list;
         public int index;
         public int parentID;
         public int grandParentID;
      }
      public static void ConfigGridControl( DevExpress.XtraGrid.GridControl gc, DevExpress.XtraGrid.Views.Grid.GridView gv )
      {
         gv.ShowLoadingPanel( );
         ((System.ComponentModel.ISupportInitialize) (gc)).BeginInit( );
         ((System.ComponentModel.ISupportInitialize) (gv)).BeginInit( );
         {
            //gridControl1.ForceInitialize( );
            gv.OptionsBehavior.ReadOnly = true;
            //
            gv.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
            gv.OptionsClipboard.PasteMode = DevExpress.Export.PasteMode.None;
            gv.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsClipboard.AllowCsvFormat = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsClipboard.AllowExcelFormat = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsClipboard.AllowHtmlFormat = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsClipboard.AllowRtfFormat = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsClipboard.AllowTxtFormat = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsClipboard.ShowProgress = DevExpress.Export.ProgressMode.Automatic;
            //
            gv.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsMenu.ShowAutoFilterRowItem = true;
            gv.OptionsMenu.ShowConditionalFormattingItem = true;
            gv.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
            gv.OptionsMenu.ShowFooterItem = true;
            gv.OptionsMenu.ShowGroupSortSummaryItems = true;
            gv.OptionsMenu.ShowGroupSummaryEditorItem = true;
            gv.OptionsMenu.ShowSplitItem = true;
            //
            gv.OptionsView.ShowFooter = true;
            gv.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            gv.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            gv.OptionsSelection.MultiSelect = true;
            //
            gv.Columns[ ColumnQN.METADATA_PROVIDER_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.SYNTAX_PROVIDER_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.IS_SYSTEM_FIELDNAME ].Visible = false;
            //
            gv.Columns[ ColumnQN.CARDINALYTY_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.FIELDSCOUNT_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.FIELDS_FIELDNAME ].Visible = false;
            //
            gv.Columns[ ColumnQN.REFERENCED_CARDINALYTY_NAME_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.REFERENCED_OBJECT_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.REFERENCED_OBJECT_NAME_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.REFERENCED_FIELDS_COUNT_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.REFERENCED_FIELDS_FIELDNAME ].Visible = false;
            //
            gv.Columns[ ColumnQN.REFERENCED_OBJECT_NAME_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.SERVER_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.DATABASE_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.SCHEMA_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.OBJECT_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.NAMEQUOTED_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.ALTNAME_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.FIELD_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.EXPRESSION_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.FIELDTYPE_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.IS_PK_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.IS_READONLY_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.DESCRIPTION_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.TAG_FIELDNAME ].Visible = false;
            gv.Columns[ ColumnQN.USERDATA_FIELDNAME ].Visible = false;
            //
            gv.Columns[ ColumnQN.FIELD_FIELDNAME ].Caption = ColumnQN.FIELD_DISPLAYNAME;
            //
            gv.Columns[ ColumnQN.CARDINALYTY_FIELDNAME ].Caption = ColumnQN.CARDINALYTY_DISPLAYNAME;
            gv.Columns[ ColumnQN.FIELDSCOUNT_FIELDNAME ].Caption = ColumnQN.FIELDSCOUNT_DISPLAYNAME;
            gv.Columns[ ColumnQN.FIELDS_FIELDNAME ].Caption = ColumnQN.FIELDS_DISPLAYNAME;
            //
            gv.Columns[ ColumnQN.REFERENCED_CARDINALYTY_NAME_FIELDNAME ].Caption = ColumnQN.REFERENCED_CARDINALYTY_NAME_DISPLAYNAME;
            gv.Columns[ ColumnQN.REFERENCED_OBJECT_FIELDNAME ].Caption = ColumnQN.REFERENCED_OBJECT_DISPLAYNAME;
            gv.Columns[ ColumnQN.REFERENCED_OBJECT_NAME_FIELDNAME ].Caption = ColumnQN.REFERENCED_OBJECT_NAME_DISPLAYNAME;
            gv.Columns[ ColumnQN.REFERENCED_FIELDS_COUNT_FIELDNAME ].Caption = ColumnQN.REFERENCED_FIELDS_COUNT_DISPLAYNAME;
            gv.Columns[ ColumnQN.REFERENCED_FIELDS_FIELDNAME ].Caption = ColumnQN.REFERENCED_FIELDS_DISPLAYNAME;
            //
            gv.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler( gridView1_RowCellStyle );
            gv.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler( gridView1_CustomDrawCell );
         }
         ((System.ComponentModel.ISupportInitialize) (gc)).EndInit( );
         ((System.ComponentModel.ISupportInitialize) (gv)).EndInit( );
         // gv.ShowEditForm( );
         // gv.HideEditForm( );
         gv.HideLoadingPanel( );
      }
      private static void gridView1_RowCellStyle( object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e )
      {
         DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
         if( view == null ) return;

         object cellValue = e.CellValue;
         if( cellValue == null )
         {
            e.Appearance.BackColor = System.Drawing.Color.LightYellow; //.NavajoWhite;
            return;
         }
         if( cellValue is string )
         {
            if( string.IsNullOrWhiteSpace( cellValue as string ) )
            {
               if( (cellValue as string) == string.Empty )
               {
                  e.Appearance.BackColor = System.Drawing.Color.NavajoWhite;
                  return;
               }
               // WhiteSpace 
               e.Appearance.BackColor = System.Drawing.Color.MistyRose;
               return;
            }
         }

         //if( e.RowHandle != view.FocusedRowHandle &&
         //   ((e.RowHandle % 2 == 0 && e.Column.VisibleIndex % 2 == 1) ||
         //   (e.Column.VisibleIndex % 2 == 0 && e.RowHandle % 2 == 1)) )
         //{
         //}

      }
      private static void gridView1_CustomDrawCell( object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e )
      {
         if( e.RowHandle != DevExpress.XtraGrid.GridControl.NewItemRowHandle )
         {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo gci = e.Cell as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo;
            DevExpress.XtraEditors.ViewInfo.TextEditViewInfo info = gci.ViewInfo as DevExpress.XtraEditors.ViewInfo.TextEditViewInfo;
            if( info == null )
               return;
            info.ContextImageAlignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            //
            if( e.Column.FieldName == ColumnQN.TYPE_FIELDNAME || e.Column.FieldName == ColumnQN.PARENT_TYPE_FIELDNAME )
            {
               if( e.CellValue == null )
               {
                  e.Appearance.BackColor = System.Drawing.Color.LightYellow; //.NavajoWhite;
                  return;
               }
               if( e.CellValue.ToString( ) == "Field" )
               {
                  info.ContextImage = DevExpress.Images.ImageResourceCache.Default.GetImage( "devav/view/sales_16x16.png" );
                  info.CalcViewInfo( );
               }
               return;
            }
         }
      }

      //
      public static void SerializeQueryBuilder(
         ActiveQueryBuilder.View.WinForms.QueryBuilder qb,
         string filename
         )
      {
         {
            string xML = qb.MetadataContainer.XML;
         }
         {
            qb.MetadataContainer.ExportToXML( filename );
         }
         //{
         //   qb.MetadataContainer.ImportFromXML( filename );
         //}
      }

      #region --- MSSQL... ---
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

      public static System.ComponentModel.BindingList<ColumnQN> BuildBindingList(
         ActiveQueryBuilder.View.WinForms.QueryBuilder qb
         )
      {
         System.ComponentModel.BindingList<ColumnQN> list = new System.ComponentModel.BindingList<ColumnQN>( );
         using( var sqlContext = new ActiveQueryBuilder.Core.SQLContext( ) )
         {
            sqlContext.Assign( qb.SQLContext );
            //sqlContext.MetadataContainer.LoadingOptions.LoadDefaultDatabaseOnly = false;
            //sqlContext.MetadataContainer.LoadingOptions.LoadSystemObjects = false;

            using( ActiveQueryBuilder.Core.MetadataList miList = new ActiveQueryBuilder.Core.MetadataList( sqlContext.MetadataContainer ) )
            {
               miList.Load( ActiveQueryBuilder.Core.MetadataType.All, true );
               System.Collections.Generic.Stack<StackItem> stack = new System.Collections.Generic.Stack<StackItem>( );
               stack.Push( new StackItem { list = miList, index = 0, parentID = -1, grandParentID = -1 } );
               do
               {
                  StackItem si = stack.Pop( );
                  ActiveQueryBuilder.Core.MetadataList actualMIList = si.list;
                  int actualIndex = si.index;
                  int actualParentID = si.grandParentID; // IMPORTANT!!!
                  {
                     for( ; actualIndex < actualMIList.Count; actualIndex++ )
                     {
                        ExtractMetadataItem( list, actualMIList[ actualIndex ], actualParentID );
                        if( actualMIList[ actualIndex ].Items.Count > 0 ) // branch...
                        {
                           // Push the "next" Item...
                           stack.Push( new StackItem
                           {
                              list = actualMIList,
                              index = actualIndex + 1,
                              parentID = list[ list.Count - 1 ].ID,
                              grandParentID = actualParentID
                           } );
                           // Reset the loop to process the "actual" Item...
                           actualParentID = list[ list.Count - 1 ].ID;
                           actualMIList = actualMIList[ actualIndex ].Items;
                           actualIndex = -1;
                        }
                     } // for(;;)...
                  }
               } while( stack.Count > 0 );
            } // using()...
         } // using()...
         return list;
      } // buildBindingList(...)

      private static void ExtractMetadataItem(
         System.ComponentModel.BindingList<ColumnQN> list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         switch( mi.Type )
         {
            case ActiveQueryBuilder.Core.MetadataType.Root:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Server:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Database:
               ExtractNamespace( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Schema:
               ExtractNamespace( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Package:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Namespaces:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Table:
               ExtractTable( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.View:
               ExtractTable( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Procedure:
               ExtractProcedure( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Synonym:
               ExtractSynonym( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Objects:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Aggregate:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Parameter:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Field:
               ExtractField( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.ForeignKey:
               ExtractForeignKey( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.ObjectMetadata:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.UserQuery:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.UserField:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.All:
               ExtractItem( list, mi, parentID );
               break;
            default:
               ExtractItem( list, mi, parentID );
               break;
         } // switch()...
      }
      private static void ExtractProcedure(
         System.ComponentModel.BindingList<ColumnQN> list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         {
            ActiveQueryBuilder.Core.MetadataObject m = mi as ActiveQueryBuilder.Core.MetadataObject;
         }
      }
      private static void ExtractSynonym(
         System.ComponentModel.BindingList<ColumnQN> list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         {
            ActiveQueryBuilder.Core.MetadataObject m = mi as ActiveQueryBuilder.Core.MetadataObject;
            o.ReferencedObject = m.ReferencedObject?.NameFull;
            //
            for( int i = 0; i < m.ReferencedObjectName.Count; i++ )
            {
               ActiveQueryBuilder.Core.MetadataQualifiedNamePart x = m.ReferencedObjectName[ i ];
               o.ReferencedObjectName += "["
               + System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), x.Type )
               + ":"
               + x.Name
               + "]"
            ;
            }
         }
      }
      private static void ExtractNamespace(
         System.ComponentModel.BindingList<ColumnQN> list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         {
            ActiveQueryBuilder.Core.MetadataNamespace m = mi as ActiveQueryBuilder.Core.MetadataNamespace;
         }
      }
      private static void ExtractTable(
         System.ComponentModel.BindingList<ColumnQN> list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         {
            ActiveQueryBuilder.Core.MetadataObject m = mi as ActiveQueryBuilder.Core.MetadataObject;
         }
      }
      private static void ExtractForeignKey(
         System.ComponentModel.BindingList<ColumnQN> list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         o.FieldType = null;
         {
            ActiveQueryBuilder.Core.MetadataForeignKey m = mi as ActiveQueryBuilder.Core.MetadataForeignKey;
            o.ReferencedObject = m.ReferencedObject.NameFull;
            //
            for( int i = 0; i < m.ReferencedObjectName.Count; i++ )
            {
               ActiveQueryBuilder.Core.MetadataQualifiedNamePart x = m.ReferencedObjectName[ i ];
               o.ReferencedObjectName += "["
               + System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), x.Type )
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
            o.ReferencedCardinality = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataForeignKeyCardinality ), m.ReferencedCardinality );
            //
            o.FieldsCount = m.Fields.Count;
            for( int i = 0; i < m.Fields.Count; i++ )
            {
               o.Fields += "[" + m.Fields[ i ] + "]"
            ;
            }
            //
            o.Cardinality = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataForeignKeyCardinality ), m.Cardinality );
         }
      }
      private static void ExtractField(
         System.ComponentModel.BindingList<ColumnQN> list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         {
            ActiveQueryBuilder.Core.MetadataField m = mi as ActiveQueryBuilder.Core.MetadataField;
            o.Expression = m.Expression;
            o.FieldType = System.Enum.GetName( typeof( System.Data.DbType ), m.FieldType );
            o.FieldTypeName = m.FieldTypeName;
            o.IsNullable = m.Nullable;
            o.Precision = m.Precision;
            o.Scale = m.Scale;
            o.Size = m.Size;
            o.IsPK = m.PrimaryKey;
            o.IsRO = m.ReadOnly;
         }
      }
      private static ColumnQN ExtractItem(
         System.ComponentModel.BindingList<ColumnQN> list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         var o = new ColumnQN( );
         {
            o.MetadataProvider = mi.SQLContext?.MetadataProvider.Description;
            o.SyntaxProvider = mi.SQLContext?.SyntaxProvider.Description;
            o.ID = list.Count;
            o.ParentID = parentID;
            if( mi.Parent != null )
            {
               o.ParentType = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), mi.Parent.Type );
            }
            o.Type = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), mi.Type );
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
            o.Field = mi.Name != null ? mi.Name : "<?>";
            //
            //
            o.HasDefault = mi.Default;
            o.Description = mi.Description;
            o.Tag = mi.Tag;
            o.UserData = mi.UserData;
         }
         list.Add( o );
         return o;
      }
   }
}

/*
      public static BindingList<ColumnQN> buildBindingListMSSQL( ActiveQueryBuilder.View.WinForms.QueryBuilder qb )
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

      public static BindingList<ColumnQN> buildBindingListSQLite( ActiveQueryBuilder.View.WinForms.QueryBuilder qb )
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

      public static BindingList<ColumnQN> buildBindingListSQLiteField( ActiveQueryBuilder.View.WinForms.QueryBuilder qb )
      {
         BindingList<ColumnQN> listDataSource = new BindingList<ColumnQN>( );
         using( var sqlContext = new SQLContext( ) )
         {
            sqlContext.Assign( qb.SQLContext );
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


*/
