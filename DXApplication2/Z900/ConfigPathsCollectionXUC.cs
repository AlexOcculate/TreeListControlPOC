using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Z900.Model;
using static Z900.Model.ConfigPath;

namespace Z900
{
   public partial class ConfigPathsCollectionXUC : DevExpress.XtraEditors.XtraUserControl
   {
      private ConfigPathCollection cpColl;
      public ConfigPathsCollectionXUC(ConfigPathCollection cpColl = null)
      {
         this.cpColl = cpColl;
         InitializeComponent();
         if (this.DesignMode)
         {
            this.gridControl.DataSource = ConfigPathCollection.NewCollectionTemplate().List;
         }
         else
         {
            this.gridControl.DataSource = this.cpColl?.List;
         }
         this.bsiRecordsCount.Caption = "RECORDS : " + ((BindingList<ConfigPath>)this.gridControl.DataSource).Count;
         {
            this.gridControl.UseEmbeddedNavigator = true;
            this.gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsBehavior.Editable = true;
            this.gridView.OptionsBehavior.ReadOnly = false;
            this.gridView.InitNewRow += new InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView.BestFitColumns();
         }
      }
      private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
      {
         GridView gv = sender as GridView;
         gv.SetRowCellValue(e.RowHandle, gv.Columns["Active?"], ConfigPathCollection.NewTemplate().IsActive);
         gv.SetRowCellValue(e.RowHandle, gv.Columns["Type"], ConfigPathCollection.NewTemplate().Type);
         gv.SetRowCellValue(e.RowHandle, gv.Columns["ShortCut"], ConfigPathCollection.NewTemplate().ShortCut);
         gv.SetRowCellValue(e.RowHandle, gv.Columns["Path"], ConfigPathCollection.NewTemplate().Path);
         gv.SetRowCellValue(e.RowHandle, gv.Columns["BaseDir"], ConfigPathCollection.NewTemplate().BaseDir);
      }

      private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
      {
         BindingList<Model.ConfigPath> dataSource = this.gridControl.DataSource as BindingList<Model.ConfigPath>;
         dataSource.Add(ConfigPathCollection.NewTemplate());
         this.gridView.BestFitColumns();
      }

      private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
      {

      }

      private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (MessageBox.Show("Delete row?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
            return;
         int focusedRowHandle = this.gridView.FocusedRowHandle;
         if (focusedRowHandle == int.MinValue)
            return;
         this.gridView.DeleteRow(focusedRowHandle);
      }

      private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.gridControl.RefreshDataSource();
      }

      private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
      {
         gridControl.ShowRibbonPrintPreview();
      }

      private void gridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
      {
         //ColumnView cv = sender as ColumnView;
         //GridColumn gc = (e as EditFormValidateEditorEventArgs)?.Column ?? cv.FocusedColumn;
         //if (gc.FieldName != "ShortCut")
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

      private void gridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
      {
         //GridView view = sender as GridView;
         //GridColumn shortCutCol = view.Columns["ShortCut"];
         //GridColumn pathCol = view.Columns["Path"];
         //GridColumn baseDirCol = view.Columns["BaseDir"];
         ////Get the value of the first column 
         //PathTypeShortCutEnum sc = (PathTypeShortCutEnum)view.GetRowCellValue(e.RowHandle, shortCutCol);
         ////if (Enum.IsDefined(typeof(PathTypeShortCutEnum), 3)) { ... }
         ////Get the value of the second column 
         //Int16 onOrd = (Int16)view.GetRowCellValue(e.RowHandle, onOrderCol);
         ////Validity criterion 
         //if (inSt < onOrd)
         //{
         //   e.Valid = false;
         //   //Set errors with specific descriptions for the columns 
         //   view.SetColumnError(inStockCol, "The value must be greater than Units On Order");
         //   view.SetColumnError(onOrderCol, "The value must be less than Units In Stock");
         //}
      }

      private void gridView_CellValueChanging(object sender, CellValueChangedEventArgs e)
      {

      }

      private void gridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
      {
         GridView gridview = sender as GridView;
         if (gridview == null) return;
         if (e.Column.FieldName == "ShortCut")
         {
            GridColumn shortCutCol = gridview.Columns["ShortCut"];
            var value = gridview.GetRowCellValue(e.RowHandle, shortCutCol);
            if (Enum.IsDefined(typeof(System.Environment.SpecialFolder), value))
            {
               string path = Environment.GetFolderPath((Environment.SpecialFolder)value);
               gridview.SetRowCellValue(e.RowHandle, gridview.Columns["Path"], path);
            }
            else
            {
               // Custom <Path>
               //OpenFileDialog a editor;
            }
         }
      }
   }
}
