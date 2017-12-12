using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
namespace Z900
{
    public partial class ConfigPathsCollection : DevExpress.XtraEditors.XtraUserControl
    {
        public ConfigPathsCollection()
        {
            InitializeComponent();

            BindingList<ConfigPath> dataSource = GetDataSource();
            gridControl.DataSource = dataSource;
            bsiRecordsCount.Caption = "RECORDS : " + dataSource.Count;
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        public BindingList<ConfigPath> GetDataSource()
        {
            BindingList<ConfigPath> result = new BindingList<ConfigPath>();
            result.Add(new ConfigPath()
            {
                ID = 1,
            });
            result.Add(new ConfigPath()
            {
                ID = 2,
            });
            return result;
        }
    }
    public class ConfigPath
    {
        [Key, Display(AutoGenerateField = false)]
        public int ID { get; set; }
        [Display(Name = "Type:")]
        [EnumDataType(typeof(ConfigPathTypeEnum))]
        [Required]
        public int Type { get; set; }
        public enum ConfigPathTypeEnum
        {
            Configurations = 0,
            DataStores,
            Temp
        }
        public string Path { get; set; }
    }
}
