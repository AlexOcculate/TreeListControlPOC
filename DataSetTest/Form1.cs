using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Data;
using System.Linq;

namespace DataSetTest
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.treeList1.RestoreLayoutFromXml(@"D:\TEMP\SQLite\dataSet.treeListLayout.xml");
            ////this.ds.ReadXml(@"D:\TEMP\SQLite\dataSet.xml", XmlReadMode.Auto);
            this.treeList1.Columns.AddRange(
                new DevExpress.XtraTreeList.Columns.TreeListColumn[]
                {
                        this.colID = this.createIDColumn(),
                        this.colName = this.createNameColumn(),
                        this.colPreview = this.createPreviewColumn(),
                }
            );
            {
                this.treeList1.PreviewFieldName = this.colPreview.FieldName;
                this.treeList1.OptionsView.AutoCalcPreviewLineCount = true;
                this.treeList1.OptionsView.AutoWidth = true;
                this.treeList1.OptionsView.ShowPreview = true;
                // this.treeList1.OptionsView.ShowCheckBoxes = true;
                //this.treeList1.OptionsBehavior.AllowBoundCheckBoxesInVirtualMode = true;
                //this.treeList1.OptionsBehavior.AllowIndeterminateCheckState = true;
                this.treeList1.OptionsBehavior.AllowRecursiveNodeChecking = true;
                this.treeList1.OptionsBehavior.AllowExpandOnDblClick = true;
                this.treeList1.BeginUnboundLoad();
                {
                    this.treeList1.DataSource = new object();
                    //this.treeList1.RefreshDataSource();
                }
                this.treeList1.EndUnboundLoad();
                this.ConfigureTreeListUnboundDataHandles();
            }
            // -------------------------------------------------------------------
            this.loadConfigData();
            {
                //this.treeList1.DataSource = this.ds.Tables["DATASTORE"];
                //this.treeList1.ExpandAll();
            }
            this.gridControl1.DataSource = this.dataStoreTable;
        }
        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            this.ds.WriteXml(@"D:\TEMP\SQLite\dataSet.sch.xml", XmlWriteMode.WriteSchema);
            this.ds.WriteXml(@"D:\TEMP\SQLite\dataSet.xml", XmlWriteMode.IgnoreSchema);
            this.ds.WriteXml(@"D:\TEMP\SQLite\dataSet.diff.xml", XmlWriteMode.DiffGram);
            this.treeList1.SaveLayoutToXml(@"D:\TEMP\SQLite\dataSet.treeListLayout.xml");
        }
        private void ConfigureTreeListUnboundDataHandles()
        {
            this.treeList1.VirtualTreeGetChildNodes += new VirtualTreeGetChildNodesEventHandler(this.treeList1_VirtualTreeGetChildNodes);
            this.treeList1.VirtualTreeGetCellValue += new VirtualTreeGetCellValueEventHandler(this.treeList1_VirtualTreeGetCellValue);
            this.treeList1.VirtualTreeSetCellValue += new VirtualTreeSetCellValueEventHandler(this.treeList1_VirtualTreeSetCellValue);
        }
        private void treeList1_VirtualTreeGetChildNodes(object sender, VirtualTreeGetChildNodesInfo e)
        {
            // METADATA: ABOUT THE #1 SERVICE COLUMN AT LEFT...
            try
            {
                DataRow[] dr;
                if (e.Node == this.treeList1.DataSource)
                {
                    dr = this.dataStoreTable.Select("ParentID = -1 and ID <> -1", "Name ASC", DataViewRowState.CurrentRows);
                }
                else
                {
                    dr = this.dataStoreTable.Select("ParentID = " + e.Node, "Name ASC", DataViewRowState.CurrentRows);
                }
                int[] id = new int[dr.Length];
                for (int i = 0; i < dr.Length; i++)
                {
                    DataRow dataRow = dr[i];
                    id[i] = (int)dataRow["ID"];
                }
                e.Children = id;
                return;
            }
            catch (Exception ex)
            {
                
            }
            e.Children = new object[] { };
        }
        private void treeList1_VirtualTreeGetCellValue(object sender, VirtualTreeGetCellValueInfo e)
        {
            // DATAVALUE...
            if (e.IsCheckState)
            {
                return;
            }
            if (e.Column == this.colID)
            {
                e.CellData = e.Node;
                return;
            }
            if (e.Column == this.colName)
            {
                DataRow[] select = this.dataStoreTable.Select("ID = "+e.Node, "Name ASC", DataViewRowState.CurrentRows);
                e.CellData = select[0]["Name"];
                return;
            }
            if (e.Column == this.colPreview)
            {
                DataRow[] select = this.dataStoreTable.Select("ID = " + e.Node, "Name ASC", DataViewRowState.CurrentRows);
                e.CellData = select[0]["Preview"];
                return;
            }
        }

        private void treeList1_VirtualTreeSetCellValue(object sender, VirtualTreeSetCellValueInfo e)
        {

        }

        private DataSet ds = new DataSet();
        private DataTable dataStoreTable;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPreview;

        private void loadConfigData()
        {
            // Create a DataSet and put both tables in it.
            ds = new DataSet();
            {
                ds.DataSetName = "office";
                ds.Namespace = "y";
                ds.Prefix = "x";
                {
                    // Create two DataTable instances.
                    this.dataStoreTable = this.createDataStoreTable();
                    //DataRow[] select = dataStoreTable.Select("IsFolder = 1", "Name DESC", DataViewRowState.CurrentRows);
                    //DataRow dataRow = select[0];
                    ds.Tables.Add(dataStoreTable);
                    //this.createOtherTables();
                }
            }
        }
        //
        private DataTable createDataStoreTable()
        {
            DataTable o = new DataTable("DATASTORE");
            {
                o.Columns.Add("ID", typeof(int));
                o.Columns.Add("ParentID", typeof(int));
                o.Columns.Add("IsFolder", typeof(bool));
                o.Columns.Add("Name", typeof(string));
                o.Columns.Add("Preview", typeof(string));
                o.Columns.Add("Type", typeof(string));
                o.Columns.Add("ConfigFilePath", typeof(string));
                o.Columns.Add("Creation", typeof(DateTime));
                {
                    o.Rows.Add(-1, -1, false, "ROOT", "This is the [root] of al [branches]! Don't remove it!!!",null,null, DateTime.Now);
                    //
                    o.Rows.Add(1, -1, true, "Alex", "Alex Mello Occulate", null, null, DateTime.Now);
                    {
                        o.Rows.Add(10, 1, false, "Geraldo", "Geraldo Occulate", null, null, DateTime.Now);
                        o.Rows.Add(11, 1, false, "Eva", "Eva Mello Occulate", null, null, DateTime.Now);
                        o.Rows.Add(12, 1, false, "Andre", "Andre Mello Occulate", null, null, DateTime.Now);
                        o.Rows.Add(13, 1, false, "Fabiane", "Fabiane Mello Occulate", null, null, DateTime.Now);
                        o.Rows.Add(14, 1, false, "Marcos", "Marcos Antonio Occulate", null, null, DateTime.Now);
                    }
                    //
                    o.Rows.Add(2, -1, true, "Simone", "Simone Licnerski Occulate", null, null, DateTime.Now);
                    {
                        o.Rows.Add(20, 2, false, "Claudio", "Claudio Licnerski", null, null, DateTime.Now);
                        o.Rows.Add(21, 2, false, "Lucy", "Lucy de Almeida Licnerski", null, null, DateTime.Now);
                        o.Rows.Add(22, 2, false, "Fabio", "Fabio de Almeida Licnerski", null, null, DateTime.Now);
                    }
                }
            }
            return o;
        }
        //
        private void createOtherTables()
        {
            DataTable table1 = new DataTable("patients");
            {
                table1.Columns.Add("name");
                table1.Columns.Add("id");
                {
                    table1.Rows.Add("sam", 1);
                    table1.Rows.Add("mark", 2);
                }
                ds.Tables.Add(table1);
            }
            DataTable table2 = new DataTable("medications");
            {
                table2.Columns.Add("id");
                table2.Columns.Add("medication");
                {
                    table2.Rows.Add(1, "atenolol");
                    table2.Rows.Add(2, "amoxicillin");
                }
                ds.Tables.Add(table2);
            }

            DataTable table3 = new DataTable("Prescription");
            {
                table3.Columns.Add("Dosage", typeof(int));
                table3.Columns.Add("Drug", typeof(string));
                table3.Columns.Add("Patient", typeof(string));
                table3.Columns.Add("Date", typeof(DateTime));
                {

                    table3.Rows.Add(25, "Indocin", "David", DateTime.Now);
                    table3.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
                    table3.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
                    table3.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
                    table3.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
                }
                ds.Tables.Add(table3);
            }
        }

        private static void StartConnectionConfigDb()
        {
            // Retrieve the Data Store specific connection string.
            string connectionString = MSSqlConnectionProvider.GetConnectionString(@"DBSRV\QWERTY", @"user02", @"8a0IucJ@Nx1Qy5HfFrX0Ob3m", @"Sales");
            string connectionString1 = SQLiteConnectionProvider.GetConnectionString(@"D:\TEMP\SQLite\SQLITEDB1.db3");
            //
            IDataLayer dataLayer = XpoDefault.GetDataLayer(connectionString1, AutoCreateOption.DatabaseAndSchema);
            XpoDefault.DataLayer = dataLayer;
            //Session session = new Session();
        }

        private TreeListColumn createIDColumn()
        {
            TreeListColumn o = new TreeListColumn();
            {
                o.FieldName = "ID";
                o.Name = "col" + o.FieldName;
                o.Visible = false;
                o.VisibleIndex = -1;
                //o.Fixed = FixedStyle.None;
                // o.FieldNameSort = "";
                // o.SortIndex = 1;
                //o.SortMode = DevExpress.XtraGrid.ColumnSortMode.Default;
                //o.SortOrder = System.Windows.Forms.SortOrder.None;
                //this.treeList1.OptionsView.ShowSummaryFooter = true;
                //o.SummaryFooter = SummaryItemType.Count;
                //o.AllNodesSummary = true;
                //o.RowFooterSummary = SummaryItemType.Count;
                //this.treeList1.OptionsView.ShowRowFooterSummary = true;
                {
                    //o.OptionsColumn.AllowEdit = true;
                    //o.OptionsColumn.AllowFocus = true;
                    o.OptionsColumn.AllowMove = true;
                    o.OptionsColumn.AllowMoveToCustomizationForm = true;
                    o.OptionsColumn.AllowSize = true;
                    o.OptionsColumn.AllowSort = true;
                    //o.OptionsColumn.FixedWidth = true;
                    o.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
                    o.OptionsColumn.ReadOnly = true;
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
                //o.SortMode = DevExpress.XtraGrid.ColumnSortMode.Default;
                //o.SortOrder = System.Windows.Forms.SortOrder.None;
                //this.treeList1.OptionsView.ShowSummaryFooter = true;
                //o.SummaryFooter = SummaryItemType.Count;
                //o.AllNodesSummary = true;
                //o.RowFooterSummary = SummaryItemType.Count;
                //this.treeList1.OptionsView.ShowRowFooterSummary = true;
                {
                    //o.OptionsColumn.AllowEdit = true;
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
                    //
                }
            }
            return o;
        }
        private TreeListColumn createPreviewColumn()
        {
            TreeListColumn o = new TreeListColumn();
            {
                o.FieldName = "Preview";
                o.Name = "col" + o.FieldName;
                o.Visible = true;
                o.VisibleIndex = 0;
                o.Fixed = FixedStyle.None;
                // o.FieldNameSort = "";
                // o.SortIndex = 1;
                //o.SortMode = DevExpress.XtraGrid.ColumnSortMode.Default;
                //o.SortOrder = System.Windows.Forms.SortOrder.None;
                //this.treeList1.OptionsView.ShowSummaryFooter = true;
                //o.SummaryFooter = SummaryItemType.Count;
                //o.AllNodesSummary = true;
                //o.RowFooterSummary = SummaryItemType.Count;
                //this.treeList1.OptionsView.ShowRowFooterSummary = true;
                {
                    //o.OptionsColumn.AllowEdit = true;
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
                    //
                }
            }
            return o;
        }

    }
}
