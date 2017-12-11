namespace DataSetTest
{
    partial class DataGridBindXtraUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataSet = new System.Data.DataSet();
            this.dataStore = new System.Data.DataTable();
            this.creationDataColumn = new System.Data.DataColumn();
            this.idDataColumn = new System.Data.DataColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCREATION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSetNAME";
            this.dataSet.Locale = new System.Globalization.CultureInfo("en");
            this.dataSet.Namespace = "NMSPC_DATASET";
            this.dataSet.Prefix = "PRFX_DATASET";
            this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.dataStore});
            // 
            // dataStore
            // 
            this.dataStore.Columns.AddRange(new System.Data.DataColumn[] {
            this.creationDataColumn,
            this.idDataColumn});
            this.dataStore.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "idColumn"}, false)});
            this.dataStore.Namespace = "nmspc";
            this.dataStore.Prefix = "prfx";
            this.dataStore.TableName = "DataStore";
            // 
            // creationDataColumn
            // 
            this.creationDataColumn.AllowDBNull = false;
            this.creationDataColumn.Caption = "Creation";
            this.creationDataColumn.ColumnName = "CREATION";
            this.creationDataColumn.DataType = typeof(System.DateTime);
            this.creationDataColumn.DateTimeMode = System.Data.DataSetDateTime.Utc;
            this.creationDataColumn.Namespace = "NMSPC_COLUMN";
            this.creationDataColumn.Prefix = "PRFX_COLUMN";
            // 
            // idDataColumn
            // 
            this.idDataColumn.AllowDBNull = false;
            this.idDataColumn.AutoIncrement = true;
            this.idDataColumn.AutoIncrementSeed = ((long)(1));
            this.idDataColumn.Caption = "ID";
            this.idDataColumn.ColumnName = "idColumn";
            this.idDataColumn.DataType = typeof(int);
            this.idDataColumn.Namespace = "NMSPC_COLUMN";
            this.idDataColumn.Prefix = "PRFX_COLUMN";
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "DataStore";
            this.gridControl1.DataSource = this.dataSet;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1112, 678);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCREATION,
            this.colidColumn});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colCREATION
            // 
            this.colCREATION.FieldName = "CREATION";
            this.colCREATION.Name = "colCREATION";
            this.colCREATION.Visible = true;
            this.colCREATION.VisibleIndex = 0;
            // 
            // colidColumn
            // 
            this.colidColumn.FieldName = "idColumn";
            this.colidColumn.Name = "colidColumn";
            this.colidColumn.Visible = true;
            this.colidColumn.VisibleIndex = 1;
            // 
            // DataGridBindXtraUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "DataGridBindXtraUserControl";
            this.Size = new System.Drawing.Size(1112, 678);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Data.DataSet dataSet;
        private System.Data.DataTable dataStore;
        private System.Data.DataColumn creationDataColumn;
        private System.Data.DataColumn idDataColumn;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCREATION;
        private DevExpress.XtraGrid.Columns.GridColumn colidColumn;
    }
}
