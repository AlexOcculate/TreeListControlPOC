using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.Generators;
using DevExpress.Xpo.Metadata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0001
{
    public partial class DataStore
    {
        #region --- Ctors... ---
        public DataStore() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public DataStore(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }
        #endregion
        //
        public static XPCollection getCollection(string criteria = null)
        {
            XPCollection xpc = new XPCollection(new Session(), typeof(Q0001.DataStore), true);
            // XPCollection xpc = new XPCollection(typeof(DataStore));
            if (criteria != null)
            {
                xpc.CriteriaString = criteria;
            }
            return xpc;
        }
        public static void VerifyBuiltinDataValues(Session session = null)
        {
            if (session == null)
            {
                session = new Session();
            }
            XPCollection dsColl = new XPCollection(session, typeof(Q0001.DataStore), true);
            if (dsColl.Count == 0)
            {
                DataStore.createBuiltInDataValues();
                return;
            }
            string filter = string.Format(
                "[{1}] = '{0}' and [{2}] = '{0}'"
                , DataStore.ROOT_NAME_DATAVALUE    // #00
                , DataStore.NAME_PROP_NAME         // #01
                , DataStore.PARENT_NAME_PROP_NAME  // #02
                );
            dsColl.CriteriaString = filter;
            dsColl.Reload();
            if (dsColl.Count == 0)
            {
                DataStore rootFolder = createRootFolder();
                rootFolder.Save();
                return;
            }
        }
        private static void createBuiltInDataValues()
        {
            DataStore rootFolder = createRootFolder();
            rootFolder.Save();
            DataStore exampleFolder1 = createExampleFolder(rootFolder);
            exampleFolder1.Save();
            DataStore exampleFolder2 = createExampleFolder(exampleFolder1);
            exampleFolder2.Id = 2;
            exampleFolder2.Save();
        }

        private static DataStore createExampleFolder(DataStore dsRoot)
        {
            DataStore ds = new DataStore();
            {
                ds.Id = 1;
                ds.ParentId = dsRoot.Id;
                ds.ParentName = dsRoot.ParentName;
                ds.IsFolder = true;
                ds.Name = DataStore.EXAMPLE_FOLDER_NAME_DATAVALUE;
                ds.Description = DataStore.EXAMPLE_FOLDER_DESCRIPTION_DATAVALUE;
            }
            return ds;
        }

        private static DataStore createRootFolder()
        {
            DataStore dsRoot = new DataStore();
            {
                dsRoot.ParentId = DataStore.ROOT_PARENT_ID_DATAVALUE;
                dsRoot.ParentName = DataStore.ROOT_PARENT_NAME_DATAVALUE;
                //
                dsRoot.Id = DataStore.ROOT_ID_DATAVALUE;
                dsRoot.Name = DataStore.ROOT_NAME_DATAVALUE;
                //
                dsRoot.IsFolder = true;
                dsRoot.Description = DataStore.ROOT_DESCRIPTION_DATAVALUE;
            }
            return dsRoot;
        }

        //
        public static void CreateBuiltinDataValues()
        {
            DataStore ds0 = new DataStore();
            {
                ds0.Id = 11;
                ds0.ParentId = -1;
                ds0.IsFolder = true;
                ds0.Name = "ROOT";
                ds0.Save();
            }
            DataStore ds1 = new DataStore();
            {
                ds1.Id = 1;
                ds1.ParentId = ds0.Id;
                ds1.IsFolder = false;
                ds1.Name = "alex";
                //                ds1.SyntaxProvider = "Oracle 12";
                ds1.MetadataProvider = "#$%^";
                ds1.Save();
            }
            DataStore ds2 = new DataStore();
            {
                ds2.Id = 2;
                ds2.ParentId = ds0.Id;
                ds2.IsFolder = true;
                ds2.Name = "simone";
                ds2.Save();
            }
            DataStore ds3 = new DataStore();
            {
                ds3.Id = 3;
                ds3.ParentId = ds2.Id;
                ds3.IsFolder = false;
                ds3.Name = "simone occulate";
                //               ds3.SyntaxProvider = "Oracle adfa12";
                ds3.MetadataProvider = "12345";
                ds3.Save();
            }
            DataStore ds4 = new DataStore();
            {
                ds4.Id = 4;
                ds4.ParentId = ds2.Id;
                ds4.IsFolder = false;
                ds4.Name = "Alex occulate";
                //                ds4.SyntaxProvider = "SQL Server";
                ds4.MetadataProvider = "12345";
                ds4.Save();
            }
            DataStore ds5 = new DataStore();
            {
                ds5.Id = 5;
                ds5.ParentId = ds2.Id;
                ds5.IsFolder = true;
                ds5.Name = "folder";
                ds5.Save();
            }

        }

        public static int GetMaxId()
        {
            //Session session = new Session();
            //session.ConnectionString = XpoDefault.ConnectionString;

            // Obtain the persistent object class info required by the GetObjects method 
            XPClassInfo dstnClass = XpoDefault.Session.GetClassInfo(typeof(DataStore));

            // Create criteria to get objects 
            CriteriaOperator criteria = null; // new BinaryOperator("Discontinued", true);

            // Create a sort list if objects must be processed in a specific order 
            SortingCollection sortProps = null; // new SortingCollection(null);
                                                // sortProps.Add(new SortProperty("Price", DevExpress.Xpo.DB.SortingDirection.Ascending));

            // Create criteria patcher to filter out the objects marked as "deleted"  
            // and to support loading of inherited objects of a given base persistent class 
            CollectionCriteriaPatcher patcher = new DevExpress.Xpo.Generators.CollectionCriteriaPatcher(false, XpoDefault.Session.TypesManager);
            // Call GetObjects 
            ICollection collection = XpoDefault.Session.GetObjects(dstnClass, criteria, sortProps, 0, patcher, true);

            int max = int.MinValue;
            // Do processing 
            foreach (DataStore dstn in collection)
            {
                max = Math.Max(max, dstn.Id);
            }
            return max;
        }

        public static DataStore GetObjectByOID(int OID)
        {
            XPCollection dsColl = new XPCollection(new Session(), typeof(Q0001.DataStore), true);
            DataStore o = dsColl.Lookup(OID) as DataStore;
            return o;
        }
    }
}
