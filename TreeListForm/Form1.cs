using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeListForm
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            StartConnectionConfigDb();
            InitializeComponent();
            XPCollection collection = Q0001.DataStore.getCollection("[Name] <> 'ROOT'");
            this.treeViewXUC1.SetDataSource(collection);
            //this.treeViewXUC1.Print(this.ps);
        }
        private DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();
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
    }
}

/*
//private DevExpress.XtraPrinting.PrintableComponentLink link;
    {
        // Create a PrintingSystem component. 
        ps = new DevExpress.XtraPrinting.PrintingSystem();

        // Create a link that will print a control. 
        link = new PrintableComponentLink(ps);

        // Specify the control to be printed. 
        link.Component = this.treeViewXUC1.treeList1;

        // Generate a report. 
        link.CreateDocument();

        // Export the report to a PDF file. 
        //string filePath = @"D:\TEMP\SQLite\gridcontrol.pdf";
        //link.PrintingSystem.ExportToPdf(filePath);

        // Use the code below if you want the created file to be automatically 
        // opened in the appropriate application. 
        //System.Diagnostics.Process process = new System.Diagnostics.Process();
        //process.StartInfo.FileName = filePath;
        //process.Start();
    }
//  this.treeViewXUC1.treeList1.Print();
    this.treeViewXUC1.treeList1.ShowRibbonPrintPreview();

 */
