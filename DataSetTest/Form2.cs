using DevExpress.XtraTreeList;
using System;
using System.Data;
using System.Linq;

namespace DataSetTest
{
    public partial class Form2 : DevExpress.XtraEditors.XtraForm
    {
        public Form2()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);
            this._ds = new TreeDataSet(
                @"D:\TEMP\SQLite\SyntaxProviderTypeXYZ.xml",
                @"D:\TEMP\SQLite\BranchTypeXYZ.xml",
                @"D:\TEMP\SQLite\ConfigXYZ.xml",
                @"D:\TEMP\SQLite\DataStoreXYZ.xml"
            );
            InitializeTreeList();
            this.gridControl1.DataSource = this._ds.DataStoreTbl;

        }
        private TreeDataSet _ds;

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void Form2_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            this._ds.DataStoreTbl.WriteXml();
        }

        #region  --- TREELIST METHODS ---
        private void InitializeTreeList()
        {
            this._ds.ConfigTbl.InitializeTreeList(this.treeList1);
            this._ds.BranchTypeTbl.InitializeStateImageCollection(this.imageCollection1);
            //
            this.treeList1.BeginUnboundLoad();
            {
                this.treeList1.StateImageList = this.imageCollection1;
                this.treeList1.VirtualTreeGetChildNodes += new VirtualTreeGetChildNodesEventHandler(this.treeList1_VirtualTreeGetChildNodes);
                this.treeList1.VirtualTreeGetCellValue += new VirtualTreeGetCellValueEventHandler(this.treeList1_VirtualTreeGetCellValue);
                this.treeList1.VirtualTreeSetCellValue += new VirtualTreeSetCellValueEventHandler(this.treeList1_VirtualTreeSetCellValue);
                this.treeList1.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeList1_GetStateImage);
                this.treeList1.GetSelectImage += new DevExpress.XtraTreeList.GetSelectImageEventHandler(this.treeList1_GetSelectImage);
            }
            this.treeList1.EndUnboundLoad();
        }
        private void treeList1_VirtualTreeGetChildNodes(object sender, VirtualTreeGetChildNodesInfo e)
        {
            // METADATA: ABOUT THE #1 (HIERARCHICAL SERVICE) COLUMN AT LEFT...
            this._ds.ConfigTbl.VirtualTreeGetChildNodes(sender, e);
        }
        private void treeList1_VirtualTreeGetCellValue(object sender, VirtualTreeGetCellValueInfo e)
        {
            // DATAVALUE: FOREACH COLUMN CONFIGED IN THE TREELIST...
            this._ds.ConfigTbl.VirtualTreeGetCellValue(sender, e);
        }
        private void treeList1_VirtualTreeSetCellValue(object sender, VirtualTreeSetCellValueInfo e)
        {
            this._ds.ConfigTbl.VirtualTreeSetCellValue(sender, e);
        }
        private void treeList1_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            int id = (int)e.Node[this._ds.ConfigTbl.TypeTreeListColumn];
            this._ds.BranchTypeTbl.GetStateImage(sender, e, id);
            //e.NodeImageIndex = !e.Node.HasChildren ? 2 : (e.Node.Expanded ? 1 : 0);
        }
        private void treeList1_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
        }
        #endregion

        private void folderBrowserBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Set the help text description for the FolderBrowserDialog.
            this.xtraFolderBrowserDialog1.Description = "Select the directory that you want to use as the default.";
            // Do not allow the user to create new files via the FolderBrowserDialog.
            this.xtraFolderBrowserDialog1.ShowNewFolderButton = false;
            // Default to the My Documents folder.
            this.xtraFolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;
            this.xtraFolderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            System.Windows.Forms.DialogResult result = this.xtraFolderBrowserDialog1.ShowDialog();

            string selectedPath = this.xtraFolderBrowserDialog1.SelectedPath;
            //if (!fileOpened)
            //{
                // No file is opened, bring up openFileDialog in selected path.
                xtraOpenFileDialog1.InitialDirectory = selectedPath;
            //xtraOpenFileDialog1.FileName = null;
            //xtraOpenFileDialog1.PerformClick();
            //}
            flyoutPanel1.Options.CloseOnOuterClick = true;
            flyoutPanel1.ShowPopup();
        }

        private void openFileDialogBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraOpenFileDialog1.InitialDirectory = "c:\\";
            xtraOpenFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            xtraOpenFileDialog1.FilterIndex = 2;

            if (xtraOpenFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
        }

        private void fileDialogBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            xtraSaveFileDialog1.FilterIndex = 2;

            if (xtraSaveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
        }

        private void defaultToolTipController1_DefaultController_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {

        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

        }
    }
}
