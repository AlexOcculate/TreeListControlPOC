using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Xml.Serialization;

namespace Z900.Model
{
   public class ConfigPathCollection
   {
      public static string BASEDIR = @"Z900";
      public static string XMLFILEPATH = Environment.GetFolderPath(
         Environment.SpecialFolder.MyDocuments,
         Environment.SpecialFolderOption.Create
         )
         + @"\"
         + ConfigPathCollection.BASEDIR
         + @"\"
   ;
      public static string XMLFILENAME = @"ConfigPath.xml";
      public static string XMLFULLNAME = XMLFILEPATH + XMLFILENAME;

      [XmlArray( "ConfigPathList" )]
      [XmlArrayItem( typeof( ConfigPath ), ElementName = "ConfigPath" )]
      public BindingList<ConfigPath> List { get; set; }

      public ConfigPathCollection()
      {
         this.List = new BindingList<ConfigPath>( );
      }

      public void Save()
      {
         if( !Directory.Exists( ConfigPathCollection.XMLFILEPATH ) )
         {
            Directory.CreateDirectory( ConfigPathCollection.XMLFILEPATH );
         }
         this.XmlSerialize( ConfigPathCollection.XMLFULLNAME );
      }

      public static ConfigPathCollection Load()
      {
         if( File.Exists( ConfigPathCollection.XMLFULLNAME ) )
         {
            ConfigPathCollection coll = ConfigPathCollection.XmlDeserialize( ConfigPathCollection.XMLFULLNAME );
            ConfigPathCollection.RemoveInvalidTypes( coll );
            return coll;
         }
         ConfigPathCollection o = new ConfigPathCollection( );
         o.Save( );
         return o;
      }

      private static void RemoveInvalidTypes( ConfigPathCollection coll )
      {
         if( coll == null ) return;
         BindingList<ConfigPath> list = coll.List;
         if( list == null ) return;
         //
         for( int i = 0; i < list.Count; i++ )
         {
            ConfigPath cp = list[ i ];
            if( cp != null )
            {
               cp.Normalize( );
               continue;
            }
            list.Remove( cp );
            i = -1;
         }
      }

      #region --- XML Serialization ---
      public void XmlSerialize( string path )
      {
         XmlSerializer xs = new XmlSerializer( typeof( ConfigPathCollection ) );
         using( TextWriter tw = new StreamWriter( path ) )
         {
            xs.Serialize( tw, this );
         }
      }
      public static ConfigPathCollection XmlDeserialize( string path )
      {
         XmlSerializer xs = new XmlSerializer( typeof( ConfigPathCollection ) );
         using( TextReader tr = new StreamReader( path ) )
         {
            var o = xs.Deserialize( tr ) as ConfigPathCollection;
            return o;
         }
      }
      #endregion

      public static ConfigPath NewTemplate()
      {
         ConfigPath o = new ConfigPath( )
         {
            Type = (int) ConfigPath.ConfigPathTypeEnum.DataStores,
            IsActive = true,
            ShortCut = (int) ConfigPath.PathTypeShortCutEnum.MyDocuments,
            BaseDir = ConfigPathCollection.BASEDIR
         };
         o.Normalize( );
         return o;
      }
      public static ConfigPathCollection NewCollectionTemplate()
      {
         int type = (int) ConfigPath.ConfigPathTypeEnum.Temporary;
         ConfigPathCollection c = new ConfigPathCollection( );
         {
            ConfigPath o = new ConfigPath( )
            {
               Type = (int) ConfigPath.ConfigPathTypeEnum.Temporary,
               IsActive = true,
               ShortCut = (int) ConfigPath.PathTypeShortCutEnum.CommonPictures,
               PathDir = Environment.GetFolderPath( Environment.SpecialFolder.CommonPictures )
            };
            c.List.Add( o );
         }
         return c;
      }
   }
}
