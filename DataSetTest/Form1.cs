using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DataSetTest
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        private DevExpress.Utils.ImageCollection imageCollection1;
        private ConfigDataSet _cfg;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPreview;

        public Form1()
        {
            this.InitializeComponent();
            this.InitializeStateImageCollection();
            this.InitializeTreeList();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this._cfg = new ConfigDataSet();
            this.gridControl1.DataSource = this._cfg.getConfigTable();
        }
        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            {
                this.treeList1.SaveLayoutToXml(@"D:\TEMP\SQLite\dataSet.treeListLayout.xml");
                //this.treeList1.RestoreLayoutFromXml(@"D:\TEMP\SQLite\dataSet.treeListLayout.xml");
            }
            this._cfg.WriteXml();
        }
        private void treeList1_VirtualTreeGetChildNodes(object sender, VirtualTreeGetChildNodesInfo e)
        {
            // METADATA: ABOUT THE #1 (HIERARCHICAL SERVICE) COLUMN AT LEFT...
            try
            {
                DataTable dt = _cfg.getConfigTable();
                DataRow[] dr;
                if (e.Node == this.treeList1.DataSource)
                {
                    dr = dt.Select("ParentID = -1 and ID <> -1", "Name ASC", DataViewRowState.CurrentRows);
                }
                else
                {
                    dr = dt.Select("ParentID = " + e.Node, "Name ASC", DataViewRowState.CurrentRows);
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
            // DATAVALUE: FOREACH COLUMN CONFIGED IN THE TREELIST...
            if (e.IsCheckState)
            {
                return;
            }
            if (e.Column == this.colID)
            {
                e.CellData = e.Node;
                return;
            }
            DataTable dt = _cfg.getConfigTable();
            if (e.Column == this.colName)
            {
                DataRow[] select = dt.Select("ID = " + e.Node, "Name ASC", DataViewRowState.CurrentRows);
                e.CellData = select[0]["Name"];
                return;
            }
            if (e.Column == this.colPreview)
            {
                DataRow[] select = dt.Select("ID = " + e.Node, "Name ASC", DataViewRowState.CurrentRows);
                e.CellData = select[0]["Preview"];
                return;
            }
        }
        private void treeList1_VirtualTreeSetCellValue(object sender, VirtualTreeSetCellValueInfo e)
        {

        }
        private void treeList1_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            e.NodeImageIndex = !e.Node.HasChildren ? 2 : (e.Node.Expanded ? 1 : 0);
        }
        private void treeList1_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {

        }
        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if a node's indicator cell is clicked. 
            TreeListHitInfo hitInfo = (sender as TreeList).CalcHitInfo(e.Location);
            TreeListNode node = null;
            if (hitInfo.HitInfoType != HitInfoType.Cell)
            {
                return;
            }
            node = hitInfo.Node;
            if (node == null) return;
            object id = node[this.colID];
            if (id == null) return;
            //
            DataTable dt = _cfg.getConfigTable();
            DataRow[] select = dt.Select("ID = " + id, "Name ASC", DataViewRowState.CurrentRows);
            DataRow dr = select[0];
            string type = (string)dr[ConfigDataSet.TYPE_FIELD_NM];
            bool rtn = type == ConfigDataSet.DATASTORE_TBL_NM;
            if (!rtn) return;
            //
            DataTable ds = _cfg.getDataStoreTable();
            DataRow[] select2 = ds.Select("ID = " + id, null, DataViewRowState.CurrentRows);
            DataRow dr2 = select2[0];
            string port = (string)dr2[ConfigDataSet.PORT_NUMBER_PROP_NAME];
            string userId = (string)dr2[ConfigDataSet.USER_ID_PROP_NAME];
            string password = (string)dr2[ConfigDataSet.PASSWORD_PROP_NAME];
            string database = (string)dr2[ConfigDataSet.DATABASE_PROP_NAME];
            DateTime creation = (DateTime)dr2[ConfigDataSet.CREATION_FIELD_NM];
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
                o.Visible = false;
                o.VisibleIndex = -1;
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
        private void InitializeStateImageCollection()
        {
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            {
                this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
                this.imageCollection1.InsertGalleryImage("bofolder_16x16.png", "images/business%20objects/bofolder_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bofolder_16x16.png"), 0);
                this.imageCollection1.Images.SetKeyName(0, "bofolder_16x16.png");
                this.imageCollection1.InsertGalleryImage("open_16x16.png", "images/actions/open_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/open_16x16.png"), 1);
                this.imageCollection1.Images.SetKeyName(1, "open_16x16.png");
                this.imageCollection1.InsertGalleryImage("database_16x16.png", "images/data/database_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/data/database_16x16.png"), 2);
                this.imageCollection1.Images.SetKeyName(2, "database_16x16.png");
            }
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
        }
        private void InitializeTreeList()
        {
            this.treeList1.Columns.AddRange(
                new DevExpress.XtraTreeList.Columns.TreeListColumn[]
                {
                        this.colID = this.createIDColumn(),
                        this.colName = this.createNameColumn(),
                        this.colPreview = this.createPreviewColumn(),
                }
            );
            this.treeList1.StateImageList = this.imageCollection1;
            this.treeList1.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeList1_GetStateImage);
            this.treeList1.GetSelectImage += new DevExpress.XtraTreeList.GetSelectImageEventHandler(this.treeList1_GetSelectImage);
            {
                this.treeList1.PreviewFieldName = this.colPreview.FieldName;
                this.treeList1.OptionsView.AutoCalcPreviewLineCount = true;
                this.treeList1.OptionsView.AutoWidth = true;
                this.treeList1.OptionsView.ShowPreview = false;
                // this.treeList1.OptionsView.ShowCheckBoxes = true;
                //this.treeList1.OptionsBehavior.AllowBoundCheckBoxesInVirtualMode = true;
                //this.treeList1.OptionsBehavior.AllowIndeterminateCheckState = true;
                this.treeList1.OptionsBehavior.AllowRecursiveNodeChecking = true;
                this.treeList1.OptionsBehavior.AllowExpandOnDblClick = true;
                this.treeList1.BeginUnboundLoad();
                {
                    this.treeList1.DataSource = new object();
                    this.treeList1.VirtualTreeGetChildNodes += new VirtualTreeGetChildNodesEventHandler(this.treeList1_VirtualTreeGetChildNodes);
                    this.treeList1.VirtualTreeGetCellValue += new VirtualTreeGetCellValueEventHandler(this.treeList1_VirtualTreeGetCellValue);
                    this.treeList1.VirtualTreeSetCellValue += new VirtualTreeSetCellValueEventHandler(this.treeList1_VirtualTreeSetCellValue);
                }
                this.treeList1.EndUnboundLoad();
            }
            this.treeList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDown);
            this.treeList1.ToolTipController = DevExpress.Utils.ToolTipController.DefaultController;
        }
        private void InitializeSuperToolTip()
        {
            // Create an object to initialize the SuperToolTip. 
            //SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
            //args.Title.Text = "Edit Popup Menu";
            //args.Contents.Text = "Show the Edit popup menu";
            //args.Contents.Image = resImage;
            //sTooltip2.Setup(args);
        }
    }
}

/*
        private DataSet ds = new DataSet();
        private DataTable configTable;
        private DataTable dataStoreTable;
 
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
                    ds.Tables.Add( this.configTable = this.createConfigTable() );
                    ds.Tables.Add( this.dataStoreTable = this.createDataStoreTable() );
                }
            }
        }

        //
        private DataTable createConfigTable()
        {
            const string path = @"D:\users\user01\source\repos\TreeListControlPOC\DataSetTest\";
            const string prvw = @"This is the[root] of al[branches]! Don't remove it!!!";
            const string nm = @"config";
            DataTable o = new DataTable("CONFIG");
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
                    o.Rows.Add(-1, -1, false, "ROOT", prvw, null, null, DateTime.Now);
                    o.Rows.Add(1, -1, true, "DataStore", prvw, null, path + "DataStore.xml", DateTime.Now);
                    o.Rows.Add(2, -1, true, "DataSource", prvw, null, path + "DataSource.xml", DateTime.Now);
                    o.Rows.Add(3, -1, true, "DataTarget", prvw, null, path + "DataTarget.xml", DateTime.Now);
                }
            }
            {
                this.ds.WriteXml(path + nm + ".sch.xml", XmlWriteMode.WriteSchema);
                this.ds.WriteXml(path + nm + ".xml", XmlWriteMode.IgnoreSchema);
                //this.ds.ReadXml(path + nm + ".xml", XmlReadMode.Auto);
                this.ds.WriteXml(path + nm + ".diff.xml", XmlWriteMode.DiffGram);
            }
            return o;
        }
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
                    o.Rows.Add(-1, -1, false, "ROOT", "This is the [root] of al [branches]! Don't remove it!!!", null, null, DateTime.Now);
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

 */
