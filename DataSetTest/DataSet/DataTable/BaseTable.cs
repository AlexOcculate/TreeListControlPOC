using System;
using System.Linq;

namespace DataSetTest
{
    public abstract class BaseTable : System.Data.DataTable
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
        private string _xmlNamespace;
        public string XmlNamespace
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return _xmlNamespace; }
            [System.Diagnostics.DebuggerStepThrough]
            set { _xmlNamespace = value; }
        }
        private string _xmlPrefix;
        public string XmlPrefix
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return _xmlPrefix; }
            [System.Diagnostics.DebuggerStepThrough]
            set { _xmlPrefix = value; }
        }
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
        public BaseTable(string filePathName, string xmlNamespace = null, string xmlPrefix = null, string tableName="BASETABLE")
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
        }
        public void WriteXml()
        {
            this.WriteXml(this.FileFullPathName, System.Data.XmlWriteMode.WriteSchema);
        }
        public abstract void CreateBuiltInDataValues();
    }
}
