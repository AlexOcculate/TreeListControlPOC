using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Z900.Model;

namespace Z900
{
   public partial class DataStoreCollectionXUC : DevExpress.XtraEditors.XtraUserControl
   {
      //      private BindingList<ConfigPath> dirList;
      private DataStoreCollection dsColl;
      private RepositoryItemComboBox editorForDisplay, editorForEditing;

      public DataStoreCollectionXUC( DataStoreCollection dsColl = null )
      {
         this.dsColl = dsColl;
         InitializeComponent( );
         if( this.DesignMode )
         {
            //this.gridControl.DataSource = DataStoreCollection.NewCollectionTemplate( ).List;
         }
         else
         {
            this.gridControl.DataSource = this.dsColl?.List;
            this.gridControl.RefreshDataSource( );
            this.gridControl.Refresh( );
         }
         this.bsiRecordsCount.Caption = null;
         {
            this.gridControl.UseEmbeddedNavigator = true;
            this.gridControl.ForceInitialize( );
            this.gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.gridView.InitNewRow += new InitNewRowEventHandler( this.gridView_InitNewRow );
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsBehavior.Editable = true;
            this.gridView.OptionsBehavior.ReadOnly = false;
            {
               //this.gridView.Columns[ DataStore.IS_ACTIVE_FIELDNAME ].Visible = true;
               //this.gridView.Columns[ DataStore.WAS_TESTED_FIELDNAME ].Visible = false;
               //this.gridView.Columns[ DataStore.NAME_FIELDNAME ].Visible = true;
               //this.gridView.Columns[ DataStore.CONNECTION_STRING_FIELDNAME ].Visible = true;
               //this.gridView.Columns[ DataStore.LOGIN_ID_FIELDNAME ].Visible = true;
               //this.gridView.Columns[ DataStore.PASSWORD_FIELDNAME ].Visible = false;
               //this.gridView.Columns[ DataStore.FULLPATHNAME_FIELDNAME ].Visible = true;
               //this.gridView.Columns[ DataStore.CREATION_FIELDNAME ].Visible = false;
               //this.gridView.Columns[ DataStore.SYNTAX_PROVIDER_FIELDNAME ].Visible = true;
               //this.gridView.Columns[ DataStore.METADATA_PROVIDER_FIELDNAME ].Visible = true;
               //this.gridView.Columns[ DataStore.PREVIEW_FIELDNAME ].Visible = false;
               //this.gridView.Columns[ DataStore.DESCRIPTION_FIELDNAME ].Visible = false;
            }
            {
               this.gridView.Columns[ DataStore.WAS_TESTED_FIELDNAME ].OptionsColumn.AllowFocus = false;
               this.gridView.Columns[ DataStore.FULLPATHNAME_FIELDNAME ].OptionsColumn.AllowFocus = false;
               this.gridView.Columns[ DataStore.CREATION_FIELDNAME ].OptionsColumn.AllowFocus = false;
               this.gridView.Columns[ DataStore.PREVIEW_FIELDNAME ].OptionsColumn.AllowFocus = false;
            }
            {
               this.gridView.Columns[ DataStore.WAS_TESTED_FIELDNAME ].OptionsColumn.ReadOnly = true;
               this.gridView.Columns[ DataStore.FULLPATHNAME_FIELDNAME ].OptionsColumn.ReadOnly = false;
            }
            {
               // In-place editors used in display and edit modes respectively. 
               this.editorForDisplay = new RepositoryItemComboBox( );
               this.editorForEditing = new RepositoryItemComboBox( );
               {
                  foreach( ConfigPath cp in this.dsColl.DirList )
                  {
                     this.editorForEditing.Items.Add( cp.PathDir );
                  }
               }
               RepositoryItem[ ] ri = new RepositoryItem[ ] { this.editorForDisplay, this.editorForEditing };
               this.gridView.GridControl.RepositoryItems.AddRange( ri );
               this.gridView.Columns[ DataStore.DIRECTORYNAME_FIELDNAME ].ColumnEdit = this.editorForDisplay;
            }
         }
      }
      private void gridView_InitNewRow( object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e )
      {
         GridView gv = sender as GridView;
         var o = DataStore.NewTemplate( this.dsColl );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.CREATION_DISPLAYNAME ], o.Creation );
         //gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.FULLPATHNAME_DISPLAYNAME ], o.FullPathName );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.NAME_DISPLAYNAME ], o.Name );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.IS_ACTIVE_DISPLAYNAME ], o.IsActive );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.WAS_TESTED_DISPLAYNAME ], o.wasTested );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.CONNECTION_STRING_DISPLAYNAME ], o.ConnectionString );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.LOGIN_ID_DISPLAYNAME ], o.LoginID );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.PASSWORD_DISPLAYNAME ], o.Password );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.SYNTAX_PROVIDER_DISPLAYNAME ], o.SyntaxProvider );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.METADATA_PROVIDER_DISPLAYNAME ], o.MetadataProvider );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.PREVIEW_DISPLAYNAME ], o.Preview );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.DESCRIPTION_DISPLAYNAME ], o.Description );
         //this.bsiRecordsCount.Caption = "RECORDS : " + ((BindingList<ConfigPath>) this.gridControl.DataSource).Count;
      }
      private void DataStoreCollectionXUC_Load( object sender, EventArgs e )
      {
         this.gridView.Columns[ DataStore.CREATION_FIELDNAME ].BestFit( );
         this.gridView.Columns[ DataStore.FULLPATHNAME_FIELDNAME ].BestFit( );
         this.gridView.Columns[ DataStore.NAME_FIELDNAME ].BestFit( );
         this.gridView.Columns[ DataStore.IS_ACTIVE_FIELDNAME ].BestFit( );
         this.gridView.Columns[ DataStore.WAS_TESTED_FIELDNAME ].BestFit( );
         this.gridView.Columns[ DataStore.CONNECTION_STRING_FIELDNAME ].BestFit( );
         this.gridView.Columns[ DataStore.LOGIN_ID_FIELDNAME ].BestFit( );
         this.gridView.Columns[ DataStore.PASSWORD_FIELDNAME ].BestFit( );
         this.gridView.Columns[ DataStore.SYNTAX_PROVIDER_FIELDNAME ].BestFit( );
         this.gridView.Columns[ DataStore.METADATA_PROVIDER_FIELDNAME ].BestFit( );
         this.gridView.Columns[ DataStore.PREVIEW_FIELDNAME ].BestFit( );
         this.gridView.Columns[ DataStore.DESCRIPTION_FIELDNAME ].BestFit( );
      }

      private void bbiNew_ItemClick( object sender, ItemClickEventArgs e )
      {
         BindingList<DataStore> dataSource = this.gridControl.DataSource as BindingList<DataStore>;
         dataSource.Add( DataStore.NewTemplate(  this.dsColl ) );
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
      private void bbiPrintPreview_ItemClick( object sender, ItemClickEventArgs e )
      {
         this.gridControl.ShowRibbonPrintPreview( );
      }

      private void gridView_ValidatingEditor( object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e )
      {
         GridView gv = sender as GridView;
         GridColumn gcName = gv.Columns[ DataStore.NAME_FIELDNAME ];
         GridColumn gcPathName = gv.Columns[ DataStore.DIRECTORYNAME_FIELDNAME ];
         GridColumn gcFullPathName = gv.Columns[ DataStore.FULLPATHNAME_FIELDNAME ];
         if( gv.FocusedColumn == gcPathName )
         {
            string pathName = e.Value as string;
            string fileName = gv.GetRowCellValue( gv.FocusedRowHandle, gcName ) as string;
            if( fileName == null )
            {
               fileName = "<PLACEHOLDER>";
               gv.SetRowCellValue( gv.FocusedRowHandle, gcName, fileName );
            }
            string fileNameTrimmed = fileName.Trim( );
            string fullPathName = pathName + @"\" + fileNameTrimmed + ".ds.xml";
            gv.SetRowCellValue( gv.FocusedRowHandle, gcFullPathName, fullPathName );
            return;
         }
         if( gv.FocusedColumn == gcName )
         {
            //string fileName = gv.GetRowCellValue( gv.FocusedRowHandle, gcName ) as string;
            string fileName = e.Value as string;
            if( fileName == null )
               return;
            string fileNameTrimmed = fileName.Trim( );
            char[ ] invalidFileNameChars = Path.GetInvalidFileNameChars( );
            if( fileNameTrimmed.IndexOfAny( invalidFileNameChars ) >= 0 )
            {
               e.Valid = false;
               e.ErrorText = "[Name] should not have invalid filename chars!";
               return;
            }
            if( fileNameTrimmed.EndsWith( "." ) )
            {
               e.Valid = false;
               e.ErrorText = "[Name] should not finish with '.'!";
               return;
            }
            if( Path.HasExtension( fileNameTrimmed ) )
            {
               e.Valid = false;
               e.ErrorText = "[Name] should not have '" + Path.GetExtension( fileNameTrimmed ) + "' extension!";
               return;
            }
            string pathName = gv.GetRowCellValue( gv.FocusedRowHandle, gcPathName ) as string;
            string fullPathName = pathName + @"\" + fileNameTrimmed + ".ds.xml";
            gv.SetRowCellValue( gv.FocusedRowHandle, gcFullPathName, fullPathName );
            return;
         }
      }

      private void gridView_ValidateRow( object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e )
      {
         GridView gv = sender as GridView;
         GridColumn gcName = gv.Columns[ DataStore.NAME_FIELDNAME ];
         GridColumn gcPathName = gv.Columns[ DataStore.DIRECTORYNAME_FIELDNAME ];
//         GridColumn gcFullPathName = gv.Columns[ DataStore.FULLPATHNAME_FIELDNAME ];
      }

      private void gridView_CustomRowCellEditForEditing( object sender, CustomRowCellEditEventArgs e )
      {
         if( e.Column.FieldName == DataStore.DIRECTORYNAME_FIELDNAME )
            e.RepositoryItem = this.editorForEditing;
      }
   }
}
