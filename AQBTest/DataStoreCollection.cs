namespace AQBTest
{
   [System.Xml.Serialization.XmlRootAttribute( "DSColl" )]
   public partial class DataStoreCollection
   {
      #region --- PROPERTIES ---
      [System.Xml.Serialization.XmlAttribute( "cts" )]
      public System.DateTime Creation { get; set; }

      [System.Xml.Serialization.XmlArray( "DSList" )]
      [System.Xml.Serialization.XmlArrayItem( typeof( DataStore ), ElementName = "DS" )]
      public System.ComponentModel.BindingList<DataStore> List { get; set; }
      #endregion

      #region --- CTOR() ---
      public DataStoreCollection()
      {
         this.Creation = System.DateTime.Now;
         this.List = new System.ComponentModel.BindingList<DataStore>( );
      }
      #endregion

      #region --- SAVE and LOAD --
      public void Save( string filepathname )
      {
         //if( !System.IO.Directory.Exists( filepathname ) )
         //{
         //   System.IO.Directory.CreateDirectory( filepathname );
         //}
         this.XmlSerialize( filepathname );
      }
      public static DataStoreCollection Load( string filepathname )
      {
         DataStoreCollection coll;
         if( System.IO.File.Exists( filepathname ) )
         {
            coll = DataStoreCollection.XmlDeserialize( filepathname );
         }
         else
         {
            coll = new DataStoreCollection( );
         }
         return coll;
      }
      #endregion

      #region --- XML Serialization ---
      public void XmlSerialize( string path )
      {
         System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer( typeof( DataStoreCollection ) );
         using( System.IO.TextWriter tw = new System.IO.StreamWriter( path ) )
         {
            xs.Serialize( tw, this );
         }
      }
      public static DataStoreCollection XmlDeserialize( string path )
      {
         System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer( typeof( DataStoreCollection ) );
         using( System.IO.TextReader tr = new System.IO.StreamReader( path ) )
         {
            var o = xs.Deserialize( tr ) as DataStoreCollection;
            return o;
         }
      }
      #endregion

      public DataStore NewTemplate()
      {
         DataStore o = new DataStore( )
         {
            CreationTS = System.DateTime.Now,
            ID = this.List.Count,
            ParentID = -1,
            Name = "<Name-PlaceHolder>",
            Description = "<Description-PlaceHolder>",
            Preview = "<Preview-PlaceHolder>",
            IsActive = false,
            IsToPullRemotely = false,
            SyntaxProvider = (int) DataStore.SyntaxProviderEnum.AUTO,
            MetadataProvider = (int) DataStore.MetadataProviderEnum.AUTO,
            LoadDefaultDatabaseOnly = false,
            LoadSystemObjects = false,
            WithFields = false,
            ConnectionString = "<ConnectionString-PlaceHolder>",
            //AqbQbFilename = "AQFN",
            //MiFqnFilename = "MIFQNFN"
         };
         return o;
      }
   }
}
