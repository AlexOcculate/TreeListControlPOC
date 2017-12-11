using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

namespace DataSetTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.Run(new XXX());
            //NewMethod();
        }

        private static void NewMethod()
        {
            DataSet ds = new DataSet("XYZ");
            {
                try
                {
                    BranchType o = new BranchType(@"D:\TEMP\SQLite\BranchTypeXYZ.xml");
                    if (o.Rows.Count == 0)
                    {
                        o.CreateBuiltInDataValues();
                        o.WriteXml();
                    }
                    ds.Tables.Add(o);
                }
                catch (System.Data.ConstraintException ex)
                {

                }
                try
                {
                    Config o = new Config(@"D:\TEMP\SQLite\ConfigXYZ.xml");
                    if (o.Rows.Count == 0)
                    {
                        o.CreateBuiltInDataValues();
                        o.WriteXml();
                    }
                    ds.Tables.Add(o);
                }
                catch (System.Data.ConstraintException ex)
                {

                }
                try
                {
                    SyntaxProviderType o = new SyntaxProviderType(@"D:\TEMP\SQLite\SyntaxProviderTypeXYZ.xml");
                    if (o.Rows.Count == 0)
                    {
                        o.CreateBuiltInDataValues();
                        o.WriteXml();
                    }
                    ds.Tables.Add(o);
                }
                catch (System.Data.ConstraintException ex)
                {

                }
                try
                {
                    DataStore o = new DataStore(@"D:\TEMP\SQLite\DataStoreXYZ.xml");
                    if (o.Rows.Count == 0)
                    {
                        o.CreateBuiltInDataValues();
                        o.WriteXml();
                    }
                    ds.Tables.Add(o);
                }
                catch (System.Data.ConstraintException ex)
                {

                }
            }
            ds.WriteXml(@"D:\TEMP\SQLite\DataSetXYZ.xml", XmlWriteMode.WriteSchema);
        }
    }
}
