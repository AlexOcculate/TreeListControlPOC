namespace AQBTest
{
   public partial class MetadataItemFQNCollection
   {
      [System.Xml.Serialization.XmlAttribute]
      public System.DateTime Creation { get; set; }

      [System.Xml.Serialization.XmlArray( "MetadataItemFQNList" )]
      [System.Xml.Serialization.XmlArrayItem( typeof( MetadataItemFQN ), ElementName = "MetadataItemFQN" )]
      public System.ComponentModel.BindingList<MetadataItemFQN> List { get; set; }

      private static readonly System.ComponentModel.BindingList<MetadataItemFQN> emptyList = new System.ComponentModel.BindingList<MetadataItemFQN>( );

      public MetadataItemFQNCollection()
      {
         this.Creation = System.DateTime.Now;
         this.List = new System.ComponentModel.BindingList<MetadataItemFQN>( );
      }

      public void Save( string filepathname )
      {
         //if( !System.IO.Directory.Exists( filepathname ) )
         //{
         //   System.IO.Directory.CreateDirectory( filepathname );
         //}
         this.XmlSerialize( filepathname );
      }
      public static MetadataItemFQNCollection Load( string filepathname )
      {
         MetadataItemFQNCollection coll;
         if( System.IO.File.Exists( filepathname ) )
         {
            coll = MetadataItemFQNCollection.XmlDeserialize( filepathname );
         }
         else
         {
            coll = new MetadataItemFQNCollection( );
         }
         return coll;
      }

      #region --- XML Serialization ---
      public void XmlSerialize( string path )
      {
         System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer( typeof( MetadataItemFQNCollection ) );
         using( System.IO.TextWriter tw = new System.IO.StreamWriter( path ) )
         {
            xs.Serialize( tw, this );
         }
      }
      public static MetadataItemFQNCollection XmlDeserialize( string path )
      {
         System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer( typeof( MetadataItemFQNCollection ) );
         using( System.IO.TextReader tr = new System.IO.StreamReader( path ) )
         {
            var o = xs.Deserialize( tr ) as MetadataItemFQNCollection;
            return o;
         }
      }
      #endregion
   }
}
