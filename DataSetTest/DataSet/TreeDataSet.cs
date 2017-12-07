using System;
using System.Linq;

namespace DataSetTest
{
    public class TreeDataSet 
    {
        #region --- PROPERTIES ---
        private string _sptFileFullPathName;
        public string SyntaxProviderTypeFileFullPathName
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this._sptFileFullPathName; }
            [System.Diagnostics.DebuggerStepThrough]
            set { this._sptFileFullPathName = value; }
        }
        //
        private string _btFileFullPathName;
        public string BranchTypeFileFullPathName
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this._btFileFullPathName; }
            [System.Diagnostics.DebuggerStepThrough]
            set { this._btFileFullPathName = value; }
        }
        //
        private string _cfgFileFullPathName;
        public string ConfigFileFullPathName
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this._cfgFileFullPathName; }
            [System.Diagnostics.DebuggerStepThrough]
            set { this._cfgFileFullPathName = value; }
        }
        // ---------- ---------- ---------- ---------- ----------
        bool _wasLoadedFromFile;
        public bool WasLoadedFromFile
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return _wasLoadedFromFile; }
            [System.Diagnostics.DebuggerStepThrough]
            set { _wasLoadedFromFile = value; }
        }
        // ---------- ---------- ---------- ---------- ----------
        private SyntaxProviderType _sptTbl;
        public SyntaxProviderType SyntaxProviderTypeTbl
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this._sptTbl; }
        }
        //
        private BranchType _bt;
        public BranchType BranchTypeTbl
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this._bt; }
        }
        //
        private Config _cfgTbl;
        public Config ConfigTbl
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this._cfgTbl; }
        }
        #endregion
        //
        public TreeDataSet(string syntaxProviderTypeFileFullPathName, string branchTypeFileFullPathName, string configFileFullPathName )
        {
            this.SyntaxProviderTypeFileFullPathName = syntaxProviderTypeFileFullPathName;
            this.BranchTypeFileFullPathName = branchTypeFileFullPathName;
            this.ConfigFileFullPathName = configFileFullPathName;
            try
            {
                this._sptTbl = new SyntaxProviderType(this.SyntaxProviderTypeFileFullPathName);
                if (this._sptTbl.Rows.Count == 0)
                {
                    this._sptTbl.CreateBuiltInDataValues();
                    this._sptTbl.WriteXml();
                }
            }
            catch (System.Data.ConstraintException ex)
            {

            }
            try
            {
                this._bt = new BranchType(this.BranchTypeFileFullPathName);
                if (this._bt.Rows.Count == 0)
                {
                    this._bt.CreateBuiltInDataValues();
                    this._bt.WriteXml();
                }
            }
            catch (System.Data.ConstraintException ex)
            {

            }
            try
            {
                this._cfgTbl = new Config(this.ConfigFileFullPathName);
                if (this._cfgTbl.Rows.Count == 0)
                {
                    this._cfgTbl.CreateBuiltInDataValues();
                    this._cfgTbl.WriteXml();
                }
            }
            catch (System.Data.ConstraintException ex)
            {

            }
            //try
            //{
            //    DataStore o = new DataStore(@"D:\TEMP\SQLite\DataStoreXYZ.xml");
            //    if (o.Rows.Count == 0)
            //    {
            //        o.CreateBuiltInDataValues();
            //        //o.WriteXml();
            //    }
            //    this.Tables.Add(o);
            //}
            //catch (System.Data.ConstraintException ex)
            //{

            //}
        }

    }
}
