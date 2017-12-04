using DevExpress.Utils.Menu;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TreeListTest
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            this.ConfigTreeList();
            //{
            //    TreeListColumnCollection columns0 = this.treeList1.Columns;
            //    this.treeList1.RestoreLayoutFromXml(@"D:\TEMP\SQLite\treeListLayout.xml");
            //    TreeListColumnCollection columns = this.treeList1.Columns;
            //    TreeListColumn treeListColumn0 = columns[0];
            //    TreeListColumn treeListColumn1 = columns[1];
            //    TreeListColumn treeListColumn2 = columns[2];
            //    TreeListColumn treeListColumn3 = columns[3];
            //    this.colType = this.createTypeColumn();
            //    this.treeList1.ImportFromXml(@"D:\TEMP\SQLite\treeListData.xml");
            //}
        }

        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private void ConfigTreeList(bool x = true)
        {
            if (x)
            {
                this.treeList1.Columns.AddRange(
                    new DevExpress.XtraTreeList.Columns.TreeListColumn[]
                    {
                        this.colType = this.createTypeColumn(),
                        this.colName = this.createNameColumn(),
                        this.colDescription = this.createDescriptionColumn()
                    }
                );
            }
            TreeListColumnCollection columns = this.treeList1.Columns;
            {
                this.treeList1.PreviewFieldName = this.colDescription.FieldName;
                this.treeList1.OptionsView.AutoCalcPreviewLineCount = true;
                this.treeList1.OptionsView.AutoWidth = true;
                this.treeList1.OptionsView.ShowPreview = true;
                this.treeList1.OptionsView.ShowCheckBoxes = true;
                this.treeList1.OptionsBehavior.AllowBoundCheckBoxesInVirtualMode = true;
                this.treeList1.OptionsBehavior.AllowIndeterminateCheckState = true;
                this.treeList1.OptionsBehavior.AllowRecursiveNodeChecking = true;
                this.treeList1.OptionsBehavior.AllowExpandOnDblClick = true;
            }
            this.treeList1.BeginUnboundLoad();
            {
                this.treeList1.DataSource = new object();
                //this.treeList1.RefreshDataSource();
            }
            this.treeList1.EndUnboundLoad();
            this.ConfigureTreeListUnboundDataHandles();
            //{
            //    this.treeList1.RestoreLayoutFromXml(@"D:\TEMP\SQLite\treeListLayout.xml");
            //    this.treeList1.ImportFromXml(@"D:\TEMP\SQLite\treeListData.xml");
            //}
        }

        private void ConfigureTreeListUnboundDataHandles()
        {
            this.treeList1.VirtualTreeGetChildNodes += new VirtualTreeGetChildNodesEventHandler(this.treeList1_VirtualTreeGetChildNodes);
            this.treeList1.VirtualTreeGetCellValue += new VirtualTreeGetCellValueEventHandler(this.treeList1_VirtualTreeGetCellValue);
            this.treeList1.VirtualTreeSetCellValue += new VirtualTreeSetCellValueEventHandler(this.treeList1_VirtualTreeSetCellValue);
        }

        private TreeListColumn createTypeColumn()
        {
            //TreeListColumn o = this.treeList1.Columns[0];
            TreeListColumn o = new TreeListColumn();
            {
                o.Caption = "Type";
                o.FieldName = "Type";
                o.Name = "col" + o.FieldName;
                o.Visible = true;
                o.VisibleIndex = 0;
                o.Fixed = FixedStyle.None;
                // o.FieldNameSort = "";
                // o.SortIndex = 1;
                o.SortMode = DevExpress.XtraGrid.ColumnSortMode.Default;
                o.SortOrder = System.Windows.Forms.SortOrder.None;
                //this.treeList1.OptionsView.ShowSummaryFooter = true;
                o.SummaryFooter = SummaryItemType.Count;
                o.AllNodesSummary = true;
                o.RowFooterSummary = SummaryItemType.Count;
                //this.treeList1.OptionsView.ShowRowFooterSummary = true;
                {
                    o.OptionsColumn.AllowEdit = true;
                    o.OptionsColumn.AllowFocus = true;
                    o.OptionsColumn.AllowMove = true;
                    o.OptionsColumn.AllowMoveToCustomizationForm = true;
                    o.OptionsColumn.AllowSize = true;
                    o.OptionsColumn.AllowSort = true;
                    //o.OptionsColumn.FixedWidth = true;
                    o.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
                    o.OptionsColumn.ReadOnly = false;
                    o.OptionsColumn.ShowInCustomizationForm = true;
                    o.OptionsColumn.ShowInExpressionEditor = true;
                    //
                }
            }
            return o;
        }

        private TreeListColumn createNameColumn()
        {
            TreeListColumn o = new TreeListColumn();
            {
                o.FieldName = "Name";
                o.Name = "col" + o.FieldName;
                o.Visible = true;
                o.VisibleIndex = 0;
                o.Fixed = FixedStyle.None;
                // o.FieldNameSort = "";
                // o.SortIndex = 1;
                o.SortMode = DevExpress.XtraGrid.ColumnSortMode.Default;
                o.SortOrder = System.Windows.Forms.SortOrder.None;
                //this.treeList1.OptionsView.ShowSummaryFooter = true;
                o.SummaryFooter = SummaryItemType.Count;
                o.AllNodesSummary = true;
                o.RowFooterSummary = SummaryItemType.Count;
                //this.treeList1.OptionsView.ShowRowFooterSummary = true;
                {
                    o.OptionsColumn.AllowEdit = true;
                    o.OptionsColumn.AllowFocus = true;
                    o.OptionsColumn.AllowMove = true;
                    o.OptionsColumn.AllowMoveToCustomizationForm = true;
                    o.OptionsColumn.AllowSize = true;
                    o.OptionsColumn.AllowSort = true;
                    //o.OptionsColumn.FixedWidth = true;
                    o.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
                    o.OptionsColumn.ReadOnly = false;
                    o.OptionsColumn.ShowInCustomizationForm = true;
                    o.OptionsColumn.ShowInExpressionEditor = true;
                    //
                }
            }
            return o;
        }

        private TreeListColumn createDescriptionColumn()
        {
            TreeListColumn o = new TreeListColumn();
            {
                o.FieldName = "Description";
                o.Name = "col" + o.FieldName;
                o.VisibleIndex = -1;
                o.Width = 21;
                o.Fixed = FixedStyle.None;
                // this.treeList1.FixedLineWidth = 2;
                //o.FieldNameSort = "";
                // o.SortIndex = 1;
                o.SortMode = DevExpress.XtraGrid.ColumnSortMode.Default;
                o.SortOrder = System.Windows.Forms.SortOrder.None;
                {
                    o.OptionsColumn.AllowEdit = true;
                    o.OptionsColumn.AllowFocus = true;
                    o.OptionsColumn.AllowMove = true;
                    o.OptionsColumn.AllowMoveToCustomizationForm = true;
                    o.OptionsColumn.AllowSize = true;
                    o.OptionsColumn.AllowSort = true;
                    //o.OptionsColumn.FixedWidth = true;
                    o.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
                    o.OptionsColumn.ReadOnly = true;
                    o.OptionsColumn.ShowInCustomizationForm = true;
                    o.OptionsColumn.ShowInExpressionEditor = true;
                }
            }
            return o;
        }

        private bool driverLoaded = false;
        private void treeList1_VirtualTreeGetChildNodes(object sender, VirtualTreeGetChildNodesInfo e)
        {
            // METADATA...
            if (this.driverLoaded)
            {
                try
                {
                    string path = e.Node as string;
                    if (Directory.Exists(path))
                    {
                        string[] dirs = Directory.GetDirectories(path);
                        string[] files = Directory.GetFiles(path);
                        string[] arr = new string[dirs.Length + files.Length];
                        dirs.CopyTo(arr, 0);
                        files.CopyTo(arr, dirs.Length);
                        e.Children = arr;
                    }
                    else
                    {
                        e.Children = new object[] { };
                    }
                }
                catch (Exception ex)
                {
                    e.Children = new object[] { };
                }
                return;
            }
            e.Children = Directory.GetLogicalDrives();
            this.driverLoaded = true;
        }
        private void treeList1_VirtualTreeGetCellValue(object sender, VirtualTreeGetCellValueInfo e)
        {
            // DATAVALUE...
            DirectoryInfo di = new DirectoryInfo((string)e.Node);
            if (e.IsCheckState)
            {
                if ((di.Attributes & FileAttributes.Directory) == 0)
                {
                    e.CellData = true;
                }
                else
                {
                    e.CellData = false;
                }
                return;
            }
            if (e.Column == this.colType)
            {
                if ((di.Attributes & FileAttributes.Directory) == 0)
                {
                    e.CellData = "file";
                }
                else
                {
                    e.CellData = "Folder";
                }
                return;
            }
            if (e.Column == this.colName)
            {
                e.CellData = di.Name;
                return;
            }
            if (e.Column == this.colDescription)
            {
                e.CellData = di.CreationTimeUtc.ToLongDateString();
                return;
            }
        }

        private void treeList1_VirtualTreeSetCellValue(object sender, VirtualTreeSetCellValueInfo e)
        {

        }

        //--------------------------
        private void treeList1_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            e.NodeImageIndex = !e.Node.HasChildren ? 2 : (e.Node.Expanded ? 1 : 0);
        }

        private void treeList1_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {

        }

        private void treeList1_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            TreeList tL = sender as TreeList;
            TreeListHitInfo hitInfo = tL.CalcHitInfo(e.Point);
            if (hitInfo.HitInfoType == HitInfoType.SummaryFooter)
            {
                DXMenuItem menuItem = new DXMenuItem("Clear All", new EventHandler(this.clearAllMenuItemClick));
                menuItem.Tag = hitInfo.Column;
                e.Menu.Items.Add(menuItem);
            }
            if (hitInfo.HitInfoType == HitInfoType.Cell)
            {
                DXMenuItem menuItem = new DXMenuItem("Connect", new EventHandler(this.clearAllMenuItemClick));
                menuItem.Tag = hitInfo.Column;
                e.Menu.Items.Add(menuItem);
            }
            if (hitInfo.HitInfoType == HitInfoType.Column && hitInfo.Column.Caption == "Department")
            {
                e.Allow = false;
            }
        }
        private void clearAllMenuItemClick(object sender, EventArgs e)
        {
            TreeListColumn clickedColumn = (sender as DXMenuItem).Tag as TreeListColumn;
            if (clickedColumn == null) return;
            TreeList tl = clickedColumn.TreeList;
            foreach (TreeListColumn column in tl.Columns)
                column.SummaryFooter = SummaryItemType.None;
        }

        private void treeList1_TreeListMenuItemClick(object sender, TreeListMenuItemClickEventArgs e)
        {
            if (e.IsFooter) return;
            TreeList tl = (sender as TreeList);
            if (e.MenuItem.Caption == "Sort Ascending" || e.MenuItem.Caption == "Sort Descending")
            {
                tl.ClearSorting();
                if (e.MenuItem.Caption == "Sort Ascending")
                    e.Column.SortOrder = SortOrder.Ascending;
                else
                    e.Column.SortOrder = SortOrder.Descending;
                e.Handled = true;
            }
        }

        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if a node's indicator cell is clicked. 
            TreeListHitInfo hitInfo = (sender as TreeList).CalcHitInfo(e.Location);
            TreeListNode node = null;
            if (hitInfo.HitInfoType == HitInfoType.RowIndicator)
            {
                node = hitInfo.Node;
            }
            if (node == null) return;
            // Create a menu with a 'Delete Node' item. 
            TreeListMenu menu = new TreeListMenu(sender as TreeList);
            DXMenuItem menuItem = new DXMenuItem("Delete Node", new EventHandler(deleteNodeMenuItemClick));
            menuItem.Tag = node;
            menu.Items.Add(menuItem);
            // Show the menu. 
            menu.Show(e.Location);
        }

        // Deletes the node for which the command has been invoked. 
        private void deleteNodeMenuItemClick(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            if (item == null) return;
            TreeListNode node = item.Tag as TreeListNode;
            if (node == null) return;
            node.TreeList.DeleteNode(node);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.treeList1.RestoreLayoutFromXml(@"D:\TEMP\SQLite\treeListData.xml");
            //this.treeList1.ImportFromXml(@"D:\TEMP\SQLite\treeListData.xml");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            TreeListColumnCollection columns = this.treeList1.Columns;
            this.treeList1.ExportToXml(@"D:\TEMP\SQLite\treeListData.xml");
            this.treeList1.SaveLayoutToXml(@"D:\TEMP\SQLite\treeListLayout.xml");
        }
    }
}
