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

      public BindingList<ConfigPath> DirList;

      private static readonly BindingList<DataStore> emptyList = new BindingList<DataStore>( );

      public DataStoreCollection()
      {
         this.List = new BindingList<DataStore>( );
      }

      public void Save()
      {
         foreach( DataStore ds in this.List )
         {
            ds.XmlSerialize( ds.FullPathName );
         }
      }

      public static DataStoreCollection Load( BindingList<ConfigPath> dirList )
      {
         DataStoreCollection coll = new DataStoreCollection( );
         if( dirList == null )
            return coll;
         coll.DirList = dirList;
         foreach( ConfigPath cp in dirList )
         {
            try
            {
               string[ ] files = Directory.GetFiles( cp.PathDir, "*.ds.xml", SearchOption.TopDirectoryOnly );
               foreach( string s in files )
               {
                  var pathSeparator = Path.PathSeparator;
                  var volumeSeparatorChar = Path.VolumeSeparatorChar;
                  var invalidFileNameChars = Path.GetInvalidFileNameChars( );
                  var invalidPathChars = Path.GetInvalidPathChars( );
                  //
                  var isPathRooted = Path.IsPathRooted( s );
                  var hasExtension = Path.HasExtension( s );
                  //
                  var fullPath = Path.GetFullPath( s );
                  var directoryName = Path.GetDirectoryName( s );
                  var pathRoot = Path.GetPathRoot( s );
                  var fileName = Path.GetFileName( s );
                  var fileNameWithoutExtension = Path.GetFileNameWithoutExtension( s );
                  var extension = Path.GetExtension( s );
                  //
                  var randomFileName = Path.GetRandomFileName( );
                  var tempFileName = Path.GetTempFileName( );
                  var tempPath = Path.GetTempPath( );
                  //
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

      public BindingList<DataStore> GetDataStores( bool isActive = true )
      {
         BindingList<DataStore> list = new BindingList<DataStore>( );
         foreach(DataStore ds in this.List)
         {
            if( ds.IsActive )
            {
               list.Add( ds );
            }
         }
         return list;
      }
   }
}
