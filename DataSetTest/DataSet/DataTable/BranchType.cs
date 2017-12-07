using System;
using System.Linq;

namespace DataSetTest
{
    public class BranchType : BaseTable
    {
        public const string TABLE_NAME = "BranchType";
        //
        public BranchType(string filePathName, string xmlNamespace = null, string xmlPrefix = null, string tableName = TABLE_NAME)
            : base(filePathName, xmlNamespace, xmlPrefix, tableName)
        {
        }
        public new void CreateBuiltInDataValues()
        {
            const bool fldr = false;
            const int tp = 0;
            const object URI = null;
            const object PVW = null;
            const object DSC = null;
            DateTime now = DateTime.Now;
            this.Rows.Add(now, 1000, -1, fldr, tp, "ROOT", URI, PVW, DSC);
            this.Rows.Add(now, 2000, -1, fldr, tp, "FOLDER", URI, PVW, DSC);
            this.Rows.Add(now, 3000, -1, fldr, tp, "DATASTORE", URI, PVW, DSC);
        }
        //
        public void GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e, int branchType)
        {
            switch (branchType)
            {
                default:
                    e.NodeImageIndex = 0;
                    break;
                case 1000:
                    e.NodeImageIndex = 1;
                    break;
                case 2000:
                    e.NodeImageIndex = (e.Node.Expanded ? 4 : 3);
                    break;
                case 3000:
                    e.NodeImageIndex = 2;
                    break;
            }
        }

        //
        public void InitializeStateImageCollection(DevExpress.Utils.ImageCollection o)
        {
            ((System.ComponentModel.ISupportInitialize)(o)).BeginInit();
            {
                o.InsertGalleryImage("question_16x16.png", "images/support/question_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/question_16x16.png"), 0);
                o.Images.SetKeyName(0, "question_16x16.png");
                o.InsertGalleryImage("bolocalization_16x16.png", "images/business%20objects/bolocalization_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bolocalization_16x16.png"), 1);
                o.Images.SetKeyName(1, "bolocalization_16x16.png");
                o.InsertGalleryImage("servermode_16x16.png", "images/data/servermode_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/data/servermode_16x16.png"), 2);
                o.Images.SetKeyName(2, "servermode_16x16.png");
                o.InsertGalleryImage("bofolder_16x16.png", "images/business%20objects/bofolder_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bofolder_16x16.png"), 3);
                o.Images.SetKeyName(3, "bofolder_16x16.png");
                o.InsertGalleryImage("open_16x16.png", "images/actions/open_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/open_16x16.png"), 4);
                o.Images.SetKeyName(4, "open_16x16.png");
                o.InsertGalleryImage("database_16x16.png", "images/data/database_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/data/database_16x16.png"), 5);
                o.Images.SetKeyName(5, "database_16x16.png");
            }
            ((System.ComponentModel.ISupportInitialize)(o)).EndInit();

            //((System.ComponentModel.ISupportInitialize)(o)).BeginInit();
            //{
            //    o.InsertGalleryImage("bofolder_16x16.png", "images/business%20objects/bofolder_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bofolder_16x16.png"), 0);
            //    o.Images.SetKeyName(0, "bofolder_16x16.png");
            //    o.InsertGalleryImage("open_16x16.png", "images/actions/open_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/open_16x16.png"), 1);
            //    o.Images.SetKeyName(1, "open_16x16.png");
            //    o.InsertGalleryImage("database_16x16.png", "images/data/database_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/data/database_16x16.png"), 2);
            //    o.Images.SetKeyName(2, "database_16x16.png");
            //    //o.InsertGalleryImage("bolocalization_16x16.png", "images/business%20objects/bolocalization_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bolocalization_16x16.png"), 3);
            //    //o.Images.SetKeyName(3, "bolocalization_16x16.png");
            //    //o.InsertGalleryImage("question_16x16.png", "images/support/question_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/question_16x16.png"), 4);
            //    //o.Images.SetKeyName(4, "question_16x16.png");
            //}
            //((System.ComponentModel.ISupportInitialize)(o)).EndInit();

            //int idx; string name, path;
            //((System.ComponentModel.ISupportInitialize)(o)).BeginInit();
            //{
            //    {
            //        idx = 0; name = "bolocalization_16x16.png"; path = "images/business%20objects/bolocalization_16x16.png";
            //        o.InsertGalleryImage(name, path, DevExpress.Images.ImageResourceCache.Default.GetImage(path), idx);
            //        o.Images.SetKeyName(idx, name);
            //    }
            //    {
            //        idx = 1; name = "bofolder_16x16.png"; path = "images/business%20objects/bofolder_16x16.png";
            //        o.InsertGalleryImage(name, path, DevExpress.Images.ImageResourceCache.Default.GetImage(path), idx);
            //        o.Images.SetKeyName(idx, name);
            //    }
            //    {
            //        idx = 2; name = "open_16x16.png"; path = "images/actions/open_16x16.png";
            //        o.InsertGalleryImage(name, path, DevExpress.Images.ImageResourceCache.Default.GetImage(path), idx);
            //        o.Images.SetKeyName(idx, name);
            //    }
            //    {
            //        idx = 3; name = "database_16x16.png"; path = "images/data/database_16x16.png";
            //        o.InsertGalleryImage(name, path, DevExpress.Images.ImageResourceCache.Default.GetImage(path), idx);
            //        o.Images.SetKeyName(idx, name);
            //    }
            //}
            //((System.ComponentModel.ISupportInitialize)(o)).EndInit();
        }
    }
}

/*
"bolocalization_16x16.png", "images/business%20objects/bolocalization_16x16.png")));

 */
