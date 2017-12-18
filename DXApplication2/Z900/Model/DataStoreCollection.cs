using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Z900.Model
{
   public class DataStoreCollection
   {
      [XmlArray( "DataStoreList" )]
      [XmlArrayItem( typeof( ConfigPath ), ElementName = "DataStore" )]
      public BindingList<DataStore> List { get; set; }

      private static readonly BindingList<DataStore> emptyList = new BindingList<DataStore>( );

      public DataStoreCollection()
      {
         this.List = new BindingList<DataStore>( );
      }

      public void Save()
      {
         foreach( DataStore ds in this.List)
         {
            ds.XmlSerialize( ds.FullPathName );
         }
      }

      public static DataStoreCollection Load( BindingList<ConfigPath> dirList )
      {
         DataStoreCollection coll = new DataStoreCollection( );
         if( dirList == null )
            return coll;
         foreach( ConfigPath cp in dirList )
         {
            try
            {
               string[ ] files = Directory.GetFiles( cp.PathDir, "*.ds.xml", SearchOption.TopDirectoryOnly );
               foreach( string s in files )
               {
                  DataStore ds = DataStore.XmlDeserialize( s );
                  ds.FullPathName = s;
                  coll.List.Add( ds );
               }
            }
            catch( Exception ex )
            {

            }
         }
         return coll;
      }
   }
}
