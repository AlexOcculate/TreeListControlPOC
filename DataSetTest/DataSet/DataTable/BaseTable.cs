using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Data;
using System.Linq;

namespace DataSetTest
{
    public class BaseTable : System.Data.DataTable
    {
        #region --- CONSTANTS ---
        public const string CREATION_FIELD_NM = "Creation";
        public const string ID_FIELD_NM = "ID";
        public const string PARENTID_FIELD_NM = "ParentID";
        public const string ISFOLDER_FIELD_NM = "IsFolder";
        public const string TYPE_FIELD_NM = "Type";
        public const string NAME_FIELD_NM = "Name";
        public const string URI_FIELD_NM = "Uri";
        public const string PREVIEW_FIELD_NM = "Preview";
        public const string DESCRIPTION_FIELD_NM = "Description";
        #endregion
        //
        #region --- PROPERTIES ---
        private string _fileFullPathName;
        public string FileFullPathName
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return _fileFullPathName; }
            [System.Diagnostics.DebuggerStepThrough]
            set { _fileFullPathName = value; }
        }
        //private string _xmlNamespace;
        //public string XmlNamespace
        //{
        //    [System.Diagnostics.DebuggerStepThrough]
        //    get { return _xmlNamespace; }
        //    [System.Diagnostics.DebuggerStepThrough]
        //    set { _xmlNamespace = value; }
        //}
        //private string _xmlPrefix;
        //public string XmlPrefix
        //{
        //    [System.Diagnostics.DebuggerStepThrough]
        //    get { return _xmlPrefix; }
        //    [System.Diagnostics.DebuggerStepThrough]
        //    set { _xmlPrefix = value; }
        //}
        bool _wasLoadedFromFile;
        public bool WasLoadedFromFile
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return _wasLoadedFromFile; }
            [System.Diagnostics.DebuggerStepThrough]
            set { _wasLoadedFromFile = value; }
        }
        #endregion
        //
        public BaseTable(string filePathName, string xmlNamespace = null, string xmlPrefix = null, string tableName = "BASETABLE")
        {
            this.FileFullPathName = filePathName ?? throw new ArgumentNullException(nameof(filePathName));
            if (System.IO.File.Exists(this.FileFullPathName))
            {
                this.WasLoadedFromFile = true;
                this.BeginLoadData();
                System.Data.XmlReadMode readXml = this.ReadXml(this.FileFullPathName);
                this.EndLoadData();
            }
            else
            {
                this.WasLoadedFromFile = false;
                this.Namespace = xmlNamespace;
                this.Prefix = xmlPrefix;
                this.TableName = tableName;
                {
                    this.Columns.Add(CREATION_FIELD_NM, typeof(DateTime));
                    {
                        System.Data.DataColumn pk = this.Columns.Add(ID_FIELD_NM, typeof(int));
                        this.PrimaryKey = new System.Data.DataColumn[] { pk };
                    }
                    this.Columns.Add(PARENTID_FIELD_NM, typeof(int));
                    this.Columns.Add(ISFOLDER_FIELD_NM, typeof(bool));
                    this.Columns.Add(TYPE_FIELD_NM, typeof(int));
                    this.Columns.Add(NAME_FIELD_NM, typeof(string));
                    this.Columns.Add(URI_FIELD_NM, typeof(string));
                    this.Columns.Add(PREVIEW_FIELD_NM, typeof(string));
                    this.Columns.Add(DESCRIPTION_FIELD_NM, typeof(string));
                }
            }
            this.createTreeListColumns();
        }
        public void WriteXml()
        {
            this.WriteXml(this.FileFullPathName, System.Data.XmlWriteMode.WriteSchema);
        }
        public void CreateBuiltInDataValues() { }

        public System.Data.DataRow[] Roots
        {
            get
            {
                return this.Select("ParentID = -1 and ID <> -1", "Name ASC", System.Data.DataViewRowState.CurrentRows);
            }
        }
        public System.Data.DataRow[] Children(int id)
        {
            return this.Select("ParentID = " + id, "Name ASC", System.Data.DataViewRowState.CurrentRows);
        }
        public System.Data.DataRow[] RowByID(int id)
        {
            return this.Select("ID = " + id, null, DataViewRowState.CurrentRows); ;
        }
        //
        //
        //
        private TreeListColumn _creationTreeListColumn;
        public TreeListColumn CreationTreeListColumn
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this._creationTreeListColumn; }
        }
        private TreeListColumn _idTreeListColumn;
        public TreeListColumn IDTreeListColumn
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this._idTreeListColumn; }
        }
        private TreeListColumn _parentIDTreeListColumn;
        public TreeListColumn ParentIDTreeListColumn
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this._parentIDTreeListColumn; }
        }
        private TreeListColumn _isFolderTreeListColumn;
        public TreeListColumn IsFolderTreeListColumn
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this._isFolderTreeListColumn; }
        }
        private TreeListColumn _typeTreeListColumn;
        public TreeListColumn TypeTreeListColumn
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this._typeTreeListColumn; }
        }
        private TreeListColumn _nameTreeListColumn;
        public TreeListColumn NameTreeListColumn
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this._nameTreeListColumn; }
        }
        private TreeListColumn _uriTreeListColumn;
        public TreeListColumn UriTreeListColumn
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this._uriTreeListColumn; }
        }
        private TreeListColumn _previewTreeListColumn;
        public TreeListColumn PreviewTreeListColumn
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this._previewTreeListColumn; }
        }
        private TreeListColumn _descriptionTreeListColumn;
        public TreeListColumn DescriptionTreeListColumn
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this._descriptionTreeListColumn; }
        }
//
        public TreeListColumn[] TreeListColumnRange;
        private void createTreeListColumns()
        {
            this.TreeListColumnRange = new TreeListColumn[]
            {
                this._creationTreeListColumn = this.createCreationColumn(),
                this._idTreeListColumn = this.createIDColumn(),
                this._parentIDTreeListColumn = this.createParentIDColumn(),
                this._isFolderTreeListColumn = this.createIsFolderColumn(),
                this._typeTreeListColumn = this.createTypeColumn(),
                this._nameTreeListColumn = this.createNameColumn(),
                this._uriTreeListColumn = this.createUriColumn(),
                this._previewTreeListColumn = this.createPreviewColumn(),
                this._descriptionTreeListColumn = this.createDescriptionColumn(),
            };
        }
        private TreeListColumn createCreationColumn()
        {
            TreeListColumn o = new TreeListColumn();
            {
                o.FieldName = CREATION_FIELD_NM;
                o.Name = "col" + o.FieldName;
                o.Visible = true;
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
                    o.OptionsColumn.AllowEdit = false;
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
        private TreeListColumn createIDColumn()
        {
            TreeListColumn o = new TreeListColumn();
            {
                o.FieldName = ID_FIELD_NM;
                o.Name = "col" + o.FieldName;
                o.Visible = true;
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
                    o.OptionsColumn.AllowEdit = false;
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
        private TreeListColumn createParentIDColumn()
        {
            TreeListColumn o = new TreeListColumn();
            {
                o.FieldName = PARENTID_FIELD_NM;
                o.Name = "col" + o.FieldName;
                o.Visible = true;
                o.VisibleIndex = -1;
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
                    o.OptionsColumn.AllowEdit = false;
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
        private TreeListColumn createIsFolderColumn()
        {
            TreeListColumn o = new TreeListColumn();
            {
                o.FieldName = ISFOLDER_FIELD_NM;
                o.Name = "col" + o.FieldName;
                o.Visible = true;
                o.VisibleIndex = -1;
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
                    o.OptionsColumn.AllowEdit = false;
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
        private TreeListColumn createTypeColumn()
        {
            TreeListColumn o = new TreeListColumn();
            {
                o.FieldName = TYPE_FIELD_NM;
                o.Name = "col" + o.FieldName;
                o.Visible = true;
                o.VisibleIndex = -1;
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
                    o.OptionsColumn.AllowEdit = false;
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
                o.FieldName = NAME_FIELD_NM;
                o.Name = "col" + o.FieldName;
                o.Visible = true;
                o.VisibleIndex = 0;
                //o.Fixed = FixedStyle.None;
                // o.FieldNameSort = "";
                // o.SortIndex = 1;
                //o.SortMode = DevExpress.XtraGrid.ColumnSortMode.Default;
                //o.SortOrder = System.Windows.Forms.SortOrder.None;
                //this.treeList1.OptionsView.ShowSummaryFooter = true;
                o.SummaryFooter = SummaryItemType.Count;
                o.AllNodesSummary = true;
                o.RowFooterSummary = SummaryItemType.Count;
                //this.treeList1.OptionsView.ShowRowFooterSummary = true;
                {
                    o.OptionsColumn.AllowEdit = false;
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
        private TreeListColumn createUriColumn()
        {
            TreeListColumn o = new TreeListColumn();
            {
                o.FieldName = URI_FIELD_NM;
                o.Name = "col" + o.FieldName;
                o.Visible = true;
                o.VisibleIndex = -1;
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
                    o.OptionsColumn.AllowEdit = false;
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
                o.FieldName = PREVIEW_FIELD_NM;
                o.Name = "col" + o.FieldName;
                o.Visible = true;
                o.VisibleIndex = -1;
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
                    o.OptionsColumn.AllowEdit = false;
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
        private TreeListColumn createDescriptionColumn()
        {
            TreeListColumn o = new TreeListColumn();
            {
                o.FieldName = "Description";
                o.Name = "col" + o.FieldName;
                o.VisibleIndex = -1;
                o.Fixed = FixedStyle.None;
                // this.treeList1.FixedLineWidth = 2;
                //o.FieldNameSort = "";
                // o.SortIndex = 1;
                o.SortMode = DevExpress.XtraGrid.ColumnSortMode.Default;
                o.SortOrder = System.Windows.Forms.SortOrder.None;
                {
                    o.OptionsColumn.AllowEdit = false;
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
        //
        public void VirtualTreeGetChildNodes(object sender, VirtualTreeGetChildNodesInfo e)
        {
            // METADATA: ABOUT THE #1 (HIERARCHICAL SERVICE) COLUMN AT LEFT...
            try
            {
                TreeList treeList = (TreeList)sender;
                DataRow[] dr;
                if (e.Node == treeList.DataSource)
                {
                    dr = this.Roots;
                }
                else
                {
                    dr = this.Children((int)e.Node);
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
        public void VirtualTreeGetCellValue(object sender, VirtualTreeGetCellValueInfo e)
        {
            // DATAVALUE: FOREACH COLUMN CONFIGED IN THE TREELIST...
            if (e.IsCheckState)
            {
                return;
            }
            DataRow[] row = this.RowByID( (int) e.Node );
            if (e.Column == this.CreationTreeListColumn)
            {
                e.CellData = row[0][CREATION_FIELD_NM];
                return;
            }
            if (e.Column == this.IDTreeListColumn)
            {
                e.CellData = row[0][ID_FIELD_NM];
                return;
            }
            if (e.Column == this.ParentIDTreeListColumn)
            {
                e.CellData = row[0][PARENTID_FIELD_NM];
                return;
            }
            if (e.Column == this.IsFolderTreeListColumn)
            {
                e.CellData = row[0][ISFOLDER_FIELD_NM];
                return;
            }
            if (e.Column == this.NameTreeListColumn)
            {
                e.CellData = row[0][NAME_FIELD_NM];
                return;
            }
            if (e.Column == this.TypeTreeListColumn)
            {
                e.CellData = row[0][TYPE_FIELD_NM];
                return;
            }
            if (e.Column == this.UriTreeListColumn)
            {
                e.CellData = row[0][URI_FIELD_NM];
                return;
            }
            if (e.Column == this.PreviewTreeListColumn)
            {
                e.CellData = row[0][PREVIEW_FIELD_NM];
                return;
            }
            if (e.Column == this.DescriptionTreeListColumn)
            {
                e.CellData = row[0][DESCRIPTION_FIELD_NM];
                return;
            }
        }
        public void VirtualTreeSetCellValue(object sender, VirtualTreeSetCellValueInfo e)
        {

        }
        public void InitializeTreeList(TreeList o)
        {
            o.BeginUnboundLoad();
            {
                o.OptionsBehavior.ReadOnly = true;
                o.OptionsBehavior.AllowExpandOnDblClick = true;
                o.OptionsView.AutoCalcPreviewLineCount = true;
                o.OptionsView.AutoWidth = true;
                o.OptionsView.ShowPreview = true;
                //
                o.Columns.AddRange(this.TreeListColumnRange);
                o.TreeViewColumn = this.NameTreeListColumn;
                o.PreviewFieldName = this.PreviewTreeListColumn.Name;
                //
                o.DataSource = new object();
            }
            o.EndUnboundLoad();
        }
    }
}
