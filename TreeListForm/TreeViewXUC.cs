using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPrinting;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace TreeListForm
{
    public partial class TreeViewXUC : DevExpress.XtraEditors.XtraUserControl
    {
        public TreeViewXUC()
        {
            PreInitializeComponent();
            AddEventHandlers();
            AddNodeOperators();
            AddColumnEditor();
            //InitializeComponent();
            this.treeList1.SaveLayoutToXml(@"D:\TEMP\SQLite\treeList.xml", DevExpress.Utils.OptionsLayoutBase.FullLayout);
            this.treeList1.Print();
        }
        //
        public DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        //
        public void SetDataSource( object ds )
        {
            if( this.treeList1.DataSource == ds)
            {
                return;
            }
            this.treeList1.DataSource = ds;
            this.treeList1.RefreshDataSource();
            this.treeList1.Print();
        }
        //
        public void Print(PrintingSystem ps)
        {
            // Create a link that will print a control. 
            PrintableComponentLink link = new PrintableComponentLink(ps);
            // Specify the control to be printed. 
            link.Component = this.treeList1;
            // Generate a report. 
            link.CreateDocument();
            // Export the report to a PDF file. 
            //string filePath = @"D:\TEMP\SQLite\gridcontrol.pdf";
            //link.PrintingSystem.ExportToPdf(filePath);
            //
            // Use the code below if you want the created file to be automatically 
            // opened in the appropriate application. 
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //process.StartInfo.FileName = filePath;
            //process.Start();
            this.treeList1.ShowRibbonPrintPreview();
        }
        //
        private void PreInitializeComponent()
        {
            this.Name = "XtraUserControl1";
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            {
                ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
                {
                    this.treeList1.ShowLoadingPanel();
                    {
                        this.treeList1.Name = "treeList1";
                        this.treeList1.Caption = "Data Stores Tree";
                        this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
                        //this.treeList1.FixedLineWidth = 2;
                        //this.treeList1.Location = new System.Drawing.Point(0, 0);
                        //this.treeList1.PreviewLineCount = 2;
                        //this.treeList1.Size = new System.Drawing.Size(632, 278);
                        this.treeList1.TabIndex = 0;
                        //this.treeList1.ActiveFilterEnabled = true;
                        //
                        #region --- General TreeList Configuration ---
                        //this.treeList1.LookAndFeel.UseDefaultLookAndFeel = false;
                        //this.treeList1.LookAndFeel.SkinName = "iMaginary";
                        //
                        this.treeList1.OptionsBehavior.AllowExpandOnDblClick = false;
                        this.treeList1.OptionsBehavior.AllowIndeterminateCheckState = true;
                        this.treeList1.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.Default;
                        this.treeList1.OptionsBehavior.AllowRecursiveNodeChecking = true;
                        this.treeList1.OptionsBehavior.EnableFiltering = true;
                        this.treeList1.OptionsBehavior.ReadOnly = false;
                        this.treeList1.OptionsBehavior.ShowToolTips = true;
                        //
                        this.treeList1.OptionsCustomization.AllowFilter = true;
                        this.treeList1.OptionsCustomization.AllowQuickHideColumns = true;
                        this.treeList1.OptionsCustomization.AllowSort = true;
                        this.treeList1.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
                        this.treeList1.OptionsCustomization.CustomizationFormSnapMode = DevExpress.Utils.Controls.SnapMode.OwnerControl;
                        this.treeList1.OptionsCustomization.ShowBandsInCustomizationForm = true;
                        //
                        this.treeList1.OptionsFind.AllowFindPanel = true;
                        this.treeList1.OptionsFind.AllowIncrementalSearch = true;
                        this.treeList1.OptionsFind.AlwaysVisible = true;
                        this.treeList1.OptionsFind.ClearFindOnClose = false;
                        this.treeList1.OptionsFind.ExpandNodesOnIncrementalSearch = true;
                        this.treeList1.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.Default;
                        //this.treeList1.OptionsFind.FindNullPrompt = "---ALEX---";
                        this.treeList1.OptionsFind.HighlightFindResults = true;
                        this.treeList1.OptionsFind.ShowClearButton = true;
                        this.treeList1.OptionsFind.ShowCloseButton = true;
                        this.treeList1.OptionsFind.ShowFindButton = true;
                        // ---------- AUTO FILTER...
                        this.treeList1.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.True;
                        this.treeList1.OptionsFilter.AllowColumnMRUFilterList = true;
                        this.treeList1.OptionsFilter.AllowFilterEditor = true;
                        this.treeList1.OptionsFilter.AllowMRUFilterList = true;
                        this.treeList1.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Extended;
                        this.treeList1.OptionsFilter.DefaultFilterEditorView = FilterEditorViewMode.VisualAndText;
                        this.treeList1.OptionsFilter.ShowAllValuesInCheckedFilterPopup = true;
                        this.treeList1.OptionsFilter.ShowAllValuesInFilterPopup = false;
                        //
                        this.treeList1.OptionsMenu.EnableColumnMenu = true;
                        this.treeList1.OptionsMenu.EnableFooterMenu = true;
                        this.treeList1.OptionsMenu.ShowAutoFilterRowItem = true;
                        this.treeList1.OptionsMenu.ShowConditionalFormattingItem = true;
                        this.treeList1.OptionsMenu.ShowFooterItem = true;
                        //
                        this.treeList1.OptionsPrint.AllowCancelPrintExport = true;
                        this.treeList1.OptionsPrint.AutoRowHeight = true;
                        this.treeList1.OptionsPrint.AutoWidth = false;
                        this.treeList1.OptionsPrint.PrintAllNodes = true;
                        this.treeList1.OptionsPrint.PrintBandHeader = true;
                        this.treeList1.OptionsPrint.PrintCheckBoxes = true;
                        this.treeList1.OptionsPrint.PrintFilledTreeIndent = true;
                        this.treeList1.OptionsPrint.PrintHorzLines = true;
                        this.treeList1.OptionsPrint.PrintImages = true;
                        this.treeList1.OptionsPrint.PrintPageHeader = true;
                        this.treeList1.OptionsPrint.PrintPreview = true;
                        this.treeList1.OptionsPrint.PrintReportFooter = true;
                        this.treeList1.OptionsPrint.PrintRowFooterSummary = true;

                        this.treeList1.OptionsPrint.PrintTree = true;
                        this.treeList1.OptionsPrint.PrintTreeButtons = false;
                        this.treeList1.OptionsPrint.PrintVertLines = false;
                        //
                        this.treeList1.OptionsSelection.EnableAppearanceFocusedCell = true;
                        this.treeList1.OptionsSelection.EnableAppearanceFocusedRow = true;
                        this.treeList1.OptionsSelection.InvertSelection = true;
                        this.treeList1.OptionsSelection.MultiSelect = false;
                        this.treeList1.OptionsSelection.MultiSelectMode = DevExpress.XtraTreeList.TreeListMultiSelectMode.RowSelect;
                        //
                        this.treeList1.OptionsView.AutoCalcPreviewLineCount = true;
                        this.treeList1.OptionsView.AutoWidth = true;
                        this.treeList1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
                        this.treeList1.OptionsView.ShowAutoFilterRow = true;
                        this.treeList1.OptionsView.ShowBandsMode = DevExpress.Utils.DefaultBoolean.Default;
                        this.treeList1.OptionsView.ShowButtons = true;
                        this.treeList1.OptionsView.ShowCaption = true;
                        this.treeList1.OptionsView.ShowColumns = true;
                        this.treeList1.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.ShowAlways;
                        this.treeList1.OptionsView.ShowHorzLines = false;
                        this.treeList1.OptionsView.ShowIndicator = false;
                        //this.treeList1.OptionsView.ShowPreview = true;
                        this.treeList1.OptionsView.ShowRowFooterSummary = true;
                        this.treeList1.OptionsView.ShowSummaryFooter = true;
                        this.treeList1.OptionsView.ShowVertLines = false;
                        #endregion
                        //
                        this.treeList1.ShowFindPanel();
                        //
                        this.AddMetadaDataValues();
                        this.AddDataValues();
                        //
                        this.Controls.Add(this.treeList1);
                        this.treeList1.ExpandAll();
                    }
                    this.treeList1.HideLoadingPanel();
                }
                ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            }
        }

        private void AddMetadaDataValues()
        {
            {
                this.treeList1.RootValue = -1;
                this.treeList1.ParentFieldName = "ParentId";
                this.treeList1.KeyFieldName = "Id";
                this.treeList1.PreviewFieldName = "Description";
                // TreeView emulation...
                //this.treeList1.TreeViewColumn = treeList1.Columns[0];
                this.treeList1.TreeViewFieldName = "Name";
            }
            this.treeList1.Columns.AddRange(
                new DevExpress.XtraTreeList.Columns.TreeListColumn[]
                    {
                        this.colParentId = createParentIdColumn(),
                        this.colId = createIdColumn(),
                        this.colName = createNameColumn(),
                        this.colDescription = createDescriptionColumn(),
                    }
            );
        }
        private void AddDataValues()
        {
            this.treeList1.DataSource = GetTreeListDataTable( /*10, 5*/ );
        }
        //
        private void AddColumnEditor()
        {
            {
                //Create a repository item corresponding to a combo box editor. 
                RepositoryItemComboBox riCombo = new RepositoryItemComboBox();
                riCombo.Items.AddRange(new string[] { "San Francisco", "Monterey", "Toronto", "Boston", "Kuaui", "Singapore", "Tokyo" });
                //Add the item to the internal repository 
                treeList1.RepositoryItems.Add(riCombo);
                //Now you can define the repository item as an in-place column editor 
                this.colName.ColumnEdit = riCombo;
                // this.treeList1.OptionsBehavior.ReadOnly = false;
                // this.colName.OptionsColumn.ReadOnly = false;
            }
            {
                //this.treeList1.CustomNodeCellEdit += new DevExpress.XtraTreeList.GetCustomNodeCellEditEventHandler(this.treeList1_GetCustomNodeCellEdit);
            }
            {
                //this.treeList1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.treeList1_ShowingEditor);
                //this.treeList1.ShownEditor += new System.EventHandler(this.treeList1_ShownEditor);
                //this.treeList1.HiddenEditor += new System.EventHandler(this.treeList1_HiddenEditor);
                //this.treeList1.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeList1_CellValueChanging);
                //this.treeList1.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeList1_CellValueChanged);
            }
        }
        //
        private void AddEventHandlers()
        {
            //this.treeList1.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeList1_NodeCellStyle);
            //this.treeList1.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.treeList1_PopupMenuShowing);
            //this.treeList1.TreeListMenuItemClick += new DevExpress.XtraTreeList.TreeListMenuItemClickEventHandler(this.treeList1_TreeListMenuItemClick);
            //this.treeList1.CustomRowFilter += new DevExpress.XtraTreeList.CustomRowFilterEventHandler(this.treeList1_CustomRowFilter);
            //
            //this.treeList1.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.treeList1_BeforeFocusNode);
            //this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            //this.treeList1.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList1_AfterFocusNode);
            //
            //this.treeList1.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeList1_CustomDrawNodeCell);
            //
            //this.treeList1.SelectionChanged += new System.EventHandler(this.treeList1_SelectionChanged);
            //
            //this.treeList1.StartSorting += new System.EventHandler(this.treeList1_StartSorting);
            //this.treeList1.EndSorting += new System.EventHandler(this.treeList1_EndSorting);
            //this.treeList1.CustomColumnSort += new DevExpress.XtraTreeList.CustomColumnSortEventHandler(this.treeList1_CustomColumnSort);
            //
            //this.treeList1.GetCustomSummaryValue += new DevExpress.XtraTreeList.GetCustomSummaryValueEventHandler(this.treeList1_GetCustomSummaryValue);
            //this.treeList1.GetPreviewText += new DevExpress.XtraTreeList.GetPreviewTextEventHandler(this.treeList1_GetPreviewText);
            //this.treeList1.CustomDrawNodePreview += new DevExpress.XtraTreeList.CustomDrawNodePreviewEventHandler(this.treeList1_CustomDrawNodePreview);
            //this.treeList1.GetPrintPreviewText += new DevExpress.XtraTreeList.GetPreviewTextEventHandler(this.treeList1_GetPrintPreviewText);
        }
        //
        private void AddNodeOperators()
        {
            {
                CustomNodeOperation operation = new CustomNodeOperation(1);
                treeList1.NodesIterator.DoLocalOperation(operation, treeList1.Nodes);
                int totalNodesAtSecondLevel = operation.NodeCount;
            }
            {
                treeList1.NodesIterator.DoOperation(new CollapseExceptSpecifiedOperation(treeList1.FocusedNode));
            }
        }
        //
        #region --- TreeList Event Handlers... ---
        private void treeList1_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {

        }
        private void treeList1_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {

        }
        private void treeList1_TreeListMenuItemClick(object sender, DevExpress.XtraTreeList.TreeListMenuItemClickEventArgs e)
        {

        }
        private void treeList1_CustomRowFilter(object sender, DevExpress.XtraTreeList.CustomRowFilterEventArgs e)
        {

        }
        private void treeList1_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
        }
        private void treeList1_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
        }
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
        }
        private void treeList1_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
        }
        private void treeList1_SelectionChanged(object sender, EventArgs e)
        {

        }
        private void treeList1_StartSorting(object sender, EventArgs e)
        {

        }
        private void treeList1_EndSorting(object sender, EventArgs e)
        {

        }
        private void treeList1_CustomColumnSort(object sender, DevExpress.XtraTreeList.CustomColumnSortEventArgs e)
        {

        }
        private void treeList1_GetCustomSummaryValue(object sender, DevExpress.XtraTreeList.GetCustomSummaryValueEventArgs e)
        {

        }
        private void treeList1_GetCustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (e.Column.FieldName != "Name")
            {
                object obj = e.Node.GetValue(0);
                if (obj != null)
                {
                    switch (obj.ToString())
                    {
                        case "Root 1":
                        default:
                            break;
                    }

                }
            }
        }
        private void treeList1_ShowingEditor(object sender, CancelEventArgs e)
        {

        }

        private void treeList1_ShownEditor(object sender, EventArgs e)
        {

        }

        private void treeList1_HiddenEditor(object sender, EventArgs e)
        {

        }

        private void treeList1_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {

        }

        private void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {

        }
        private void treeList1_GetPreviewText(object sender, DevExpress.XtraTreeList.GetPreviewTextEventArgs e)
        {

        }
        private void treeList1_CustomDrawNodePreview(object sender, DevExpress.XtraTreeList.CustomDrawNodePreviewEventArgs e)
        {

        }
        private void treeList1_GetPrintPreviewText(object sender, DevExpress.XtraTreeList.GetPreviewTextEventArgs e)
        {

        }

        #endregion
        //
        #region --- Node Operators... ---
        // Declaring the custom operation class. 
        private class CustomNodeOperation : TreeListOperation
        {
            int level;
            int nodeCount;
            public CustomNodeOperation(int level) : base()
            {
                this.level = level;
                this.nodeCount = 0;
            }
            public override void Execute(TreeListNode node)
            {
                if (node.Level == this.level)
                    this.nodeCount++;
            }
            public int NodeCount
            {
                get { return this.nodeCount; }
            }
        }
        //
        private class CollapseExceptSpecifiedOperation : TreeListOperation
        {
            TreeListNode visibleNode;
            public CollapseExceptSpecifiedOperation(TreeListNode visibleNode) : base()
            {
                this.visibleNode = visibleNode;
            }
            public override void Execute(TreeListNode node)
            {
                if (this.visibleNode == null)
                    return;
                if (!this.visibleNode.HasAsParent(node))
                    node.Expanded = false;
            }
            public override bool NeedsFullIteration { get { return false; } }
        }
        #endregion
        //
        #region --- Data Source, Data Sets and Data Columns ---
        DataTable GetTreeListDataTable(int count = 100, int rootNodesCount = 4)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("ParentId", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("DateTime", typeof(DateTime));
            dataTable.Columns.Add("Boolean", typeof(bool));
            dataTable.Columns.Add("Description", typeof(string));

            for (int i = 0; i < rootNodesCount; i++)
                dataTable.Rows.Add(i, -1, "Root " + i.ToString(), DateTime.Now.AddDays(i - count / 2), i % 2 == 0, "descreipiton");

            for (int i = rootNodesCount; i < count; i++)

                dataTable.Rows.Add(i, i % rootNodesCount, "Branch " + i.ToString(), DateTime.Now.AddDays(i - count / 2), i % 2 == 0, "DESCRIPTION");

            dataTable.AcceptChanges();

            return dataTable;
        }

        private TreeListColumn createParentIdColumn()
        {
            TreeListColumn o = new TreeListColumn();
            {
                o.FieldName = "ParentId";
                o.Name = "col" + o.FieldName;
                o.VisibleIndex = -1;
                o.Fixed = FixedStyle.None;
                // this.treeList1.FixedLineWidth = 2;
                //o.FieldNameSort = "";
                // o.SortIndex = 1;
                o.SortMode = DevExpress.XtraGrid.ColumnSortMode.Default;
                o.SortOrder = System.Windows.Forms.SortOrder.None;
                {
                    o.OptionsColumn.AllowEdit = true;
                    // this.treeList1.OptionsBehavior.Editable = true; <-- the whole tree
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

        private TreeListColumn createIdColumn()
        {
            TreeListColumn o = new TreeListColumn();
            {
                o.FieldName = "Id";
                o.Name = "col" + o.FieldName;
                o.VisibleIndex = -1;
                o.Fixed = FixedStyle.None;
                // this.treeList1.FixedLineWidth = 2;
                //o.FieldNameSort = "";
                // o.SortIndex = 1;
                o.SortMode = DevExpress.XtraGrid.ColumnSortMode.Default;
                o.SortOrder = System.Windows.Forms.SortOrder.None;
                {
                    o.OptionsColumn.AllowEdit = true;
                    // this.treeList1.OptionsBehavior.Editable = true; <-- the whole tree
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
        #endregion
    }
}
