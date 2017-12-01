using DevExpress.Utils.Menu;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Linq;
using System.Windows.Forms;

namespace TreeListTest
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

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
    }
}
