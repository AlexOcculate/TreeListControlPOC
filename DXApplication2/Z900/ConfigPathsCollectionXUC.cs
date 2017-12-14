using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Z900.Model;

namespace Z900
{
   public partial class ConfigPathsCollectionXUC : DevExpress.XtraEditors.XtraUserControl
   {
      private ConfigPathCollection cpColl;
      public ConfigPathsCollectionXUC( ConfigPathCollection cpColl = null )
      {
         this.cpColl = cpColl;
         InitializeComponent( );
         if( this.DesignMode )
         {
            this.gridControl.DataSource = ConfigPathCollection.NewCollectionTemplate( ).List;
         }
         else
         {
            this.gridControl.DataSource = this.cpColl?.List;
            this.gridControl.RefreshDataSource( );
            this.gridControl.Refresh( );
         }
         this.bsiRecordsCount.Caption = "RECORDS : " + ((BindingList<ConfigPath>) this.gridControl.DataSource).Count;
         {
            this.gridControl.UseEmbeddedNavigator = true;
            this.gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.gridView.InitNewRow += new InitNewRowEventHandler( this.gridView1_InitNewRow );
            //this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsBehavior.Editable = true;
            this.gridView.OptionsBehavior.ReadOnly = false;
            {
               this.gridView.Columns[ ConfigPath.ISACTIVE_FIELDNAME ].Visible = false;
               this.gridView.Columns[ ConfigPath.ISVALID_FIELDNAME ].Visible = false;
               this.gridView.Columns[ ConfigPath.EXISTS_DIRFLAG_FIELDNAME ].Visible = false;
               this.gridView.Columns[ ConfigPath.READABLE_DIRFLAG_FIELDNAME ].Visible = false;
               this.gridView.Columns[ ConfigPath.WRITABLE_DIRFLAG_FIELDNAME ].Visible = false;
            }
            {
               this.gridView.Columns[ ConfigPath.ISVALID_FIELDNAME ].OptionsColumn.AllowFocus = false;
               this.gridView.Columns[ ConfigPath.EXISTS_DIRFLAG_FIELDNAME ].OptionsColumn.AllowFocus = false;
               this.gridView.Columns[ ConfigPath.READABLE_DIRFLAG_FIELDNAME ].OptionsColumn.AllowFocus = false;
               this.gridView.Columns[ ConfigPath.WRITABLE_DIRFLAG_FIELDNAME ].OptionsColumn.AllowFocus = false;
            }
            {
               this.gridView.Columns[ ConfigPath.PATHDIR_FIELDNAME ].OptionsColumn.ReadOnly = true;
            }
         }
      }
      private void gridView1_InitNewRow( object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e )
      {
         GridView gv = sender as GridView;
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ ConfigPath.ISACTIVE_DISPLAYNAME ], ConfigPathCollection.NewTemplate( ).IsActive );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ ConfigPath.TYPE_DISPLAYNAME ], ConfigPathCollection.NewTemplate( ).Type );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ ConfigPath.SHORTCUT_DISPLAYNAME ], ConfigPathCollection.NewTemplate( ).ShortCut );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ ConfigPath.PATHDIR_DISPLAYNAME ], ConfigPathCollection.NewTemplate( ).PathDir );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ ConfigPath.BASEDIR_DISPLAYNAME ], ConfigPathCollection.NewTemplate( ).BaseDir );
      }

      private void bbiNew_ItemClick( object sender, ItemClickEventArgs e )
      {
         BindingList<Model.ConfigPath> dataSource = this.gridControl.DataSource as BindingList<Model.ConfigPath>;
         dataSource.Add( ConfigPathCollection.NewTemplate( ) );
         this.gridView.BestFitColumns( );
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
         gridControl.ShowRibbonPrintPreview( );
      }

      private void gridView_ValidatingEditor( object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e )
      {
         //ColumnView cv = sender as ColumnView;
         //GridColumn gc = (e as EditFormValidateEditorEventArgs)?.Column ?? cv.FocusedColumn;
         //if (gc.FieldName != ConfigPath.SHORTCUT_FIELDNAME)
         //{
         //   if (Enum.IsDefined(typeof(System.Environment.SpecialFolder), e.Value))
         //   {
         //      System.Environment.SpecialFolder sf = (System.Environment.SpecialFolder)e.Value;
         //      Path = Environment.GetFolderPath(Environment.SpecialFolder.Templates),

         //   }


         //   PathTypeShortCutEnum sc = (PathTypeShortCutEnum)e.Value;
         //   if (!(sc == PathTypeShortCutEnum.Custom))
         //   {
         //      System.Environment.SpecialFolder sf = (System.Environment.SpecialFolder)sc;
         //   }
         //}
         //return;
         //if ((Convert.ToInt32(e.Value) < 0) || (Convert.ToInt32(e.Value) > 1000000))
         //   e.Valid = false;
      }

      private void gridView_ValidateRow( object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e )
      {
         GridView view = sender as GridView;
         ConfigPath row = (ConfigPath) e.Row;
         row.Normalize( );
         if( !row.IsValid )
         {
            e.Valid = false;
            {
               GridColumn col = view.Columns[ ConfigPath.PATHDIR_DISPLAYNAME ];
               view.SetColumnError( col, "Invalid [pathdir] or [basedir]" );
            }
            {
               GridColumn col = view.Columns[ ConfigPath.BASEDIR_DISPLAYNAME ];
               view.SetColumnError( col, "Invalid combination [pathdir] or [basedir]" );
            }
         }
      }

      private void gridView_CellValueChanging( object sender, CellValueChangedEventArgs e )
      {
         GridView gridview = sender as GridView;
         if( gridview == null )
            return;
         if( e.Column.FieldName == ConfigPath.SHORTCUT_DISPLAYNAME )
         {
            GridColumn shortCutCol = gridview.Columns[ ConfigPath.SHORTCUT_DISPLAYNAME ];
            var newValue = e.Value;
            var oldValue = gridview.GetRowCellValue( e.RowHandle, shortCutCol );
            string selectedPath = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
            if( Enum.IsDefined( typeof( System.Environment.SpecialFolder ), newValue ) )
            {
               selectedPath = Environment.GetFolderPath( (Environment.SpecialFolder) newValue );
            }
            else
            {
               // Custom <Path>
               this.xtraFolderBrowserDialog1.Description = "Select the directory that you want to use as the default.";
               this.xtraFolderBrowserDialog1.ShowNewFolderButton = true;
               this.xtraFolderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyDocuments;
               System.Windows.Forms.DialogResult result = this.xtraFolderBrowserDialog1.ShowDialog( );
               if( result == DialogResult.OK )
               {
                  selectedPath = this.xtraFolderBrowserDialog1.SelectedPath;
               }
            }
            gridview.SetRowCellValue( e.RowHandle, gridview.Columns[ "PathDir" ], selectedPath );
         }
      }

      private void gridView_CellValueChanged( object sender, CellValueChangedEventArgs e )
      {
      }

      private void gridControl_Load( object sender, EventArgs e )
      {
         //this.gridView.BestFitColumns( );
         this.gridView.Columns[ ConfigPath.ISACTIVE_FIELDNAME ].BestFit( );
         this.gridView.Columns[ ConfigPath.ISVALID_FIELDNAME ].BestFit( );
         this.gridView.Columns[ ConfigPath.EXISTS_DIRFLAG_FIELDNAME ].BestFit( );
         this.gridView.Columns[ ConfigPath.READABLE_DIRFLAG_FIELDNAME ].BestFit( );
         this.gridView.Columns[ ConfigPath.WRITABLE_DIRFLAG_FIELDNAME ].BestFit( );
         //
         this.gridView.Columns[ ConfigPath.TYPE_FIELDNAME ].BestFit( );
         this.gridView.Columns[ ConfigPath.SHORTCUT_FIELDNAME ].BestFit( );
         this.gridView.Columns[ ConfigPath.BASEDIR_FIELDNAME ].BestFit( );
      }
   }
}
