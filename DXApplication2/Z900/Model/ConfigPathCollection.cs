using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Xml.Serialization;
using static Z900.Model.ConfigPath;

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
         ConfigPathCollection coll;
         if( File.Exists( ConfigPathCollection.XMLFULLNAME ) )
         {
            coll = ConfigPathCollection.XmlDeserialize( ConfigPathCollection.XMLFULLNAME );
            ConfigPathCollection.ValidateCollection( coll );
            return coll;
         }
         coll = ConfigPathCollection.NewCollectionTemplate( );
         ConfigPathCollection.ValidateCollection( coll );
         coll.Save( );
         return coll;
      }

      private static void ValidateCollection( ConfigPathCollection coll )
      {
         ConfigPathCollection.RemoveInvalidTypes( coll );
         ConfigPathCollection.RemoveDuplicates( coll );
         ConfigPathCollection.AtLeastOneDataSourceDir( coll );
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
      private static void RemoveDuplicates( ConfigPathCollection coll )
      {
         if( coll == null ) return;
         BindingList<ConfigPath> list = coll.List;
         if( list == null ) return;
         if( list.Count == 1 ) return;
         //
         HashSet<String> u = new HashSet<string>( );
         for( int i = 0; i < list.Count; i++ )
         {
            ConfigPath cp = list[ i ];
            //string k = cp.Type + "-" + cp.ShortCut + "-" + cp.PathDir + (cp.BaseDir != null ? @"\" + cp.BaseDir : "");
            string k = cp.Type + "-" + cp.ShortCut + "-" + cp.PathDir;
            if( !u.Contains( k ) )
            {
               u.Add( k );
               continue;
            }
            list.Remove( cp );
            i--;
         }
      }
      private static void AtLeastOneDataSourceDir( ConfigPathCollection coll )
      {
         if( coll == null ) return;
         BindingList<ConfigPath> list = coll.List;
         if( list == null ) return;
         //
         for( int i = 0; i < list.Count; i++ )
         {
            ConfigPath cp = list[ i ];
            if( cp.Type == (int) ConfigPathTypeEnum.DataStores )
               return;
         }
         list.Add( ConfigPathCollection.NewTemplate( ) );
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
         // ATTENTION: THIS MUST BE NOT CHANGED "AtLeastOneDataSourceDir" ...
         ConfigPath o = new ConfigPath( )
         {
            Type = (int) ConfigPath.ConfigPathTypeEnum.DataStores,
            IsActive = true,
            ShortCut = (int) ConfigPath.PathTypeShortCutEnum.MyDocuments,
            //BaseDir = ConfigPathCollection.BASEDIR
         };
         o.Normalize( );
         return o;
      }
      public static ConfigPathCollection NewCollectionTemplate()
      {
         ConfigPathCollection c = new ConfigPathCollection( );

         #region --- DATASTORE FOLDERS... ---
         {
            var o = ConfigPathCollection.NewTemplate( );
            c.List.Add( o );
         }
         {
            DriveInfo[ ] drives = DriveInfo.GetDrives( );
            foreach( DriveInfo drive in drives )
            {
               ConfigPath o = new ConfigPath( )
               {
                  Type = (int) ConfigPath.ConfigPathTypeEnum.DataStores,
                  IsActive = true,
                  ShortCut = (int) ConfigPath.PathTypeShortCutEnum.Custom,
                  PathDir = drive.Name + "temp"
               };
               o.Normalize( );
               c.List.Add( o );
            }
         }
         {
            ConfigPath o = new ConfigPath( )
            {
               Type = (int) ConfigPath.ConfigPathTypeEnum.DataStores,
               IsActive = true,
               ShortCut = (int) ConfigPath.PathTypeShortCutEnum.ApplicationData,
               PathDir = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData )
            };
            o.Normalize( );
            c.List.Add( o );
         }
         {
            ConfigPath o = new ConfigPath( )
            {
               Type = (int) ConfigPath.ConfigPathTypeEnum.DataStores,
               IsActive = true,
               ShortCut = (int) ConfigPath.PathTypeShortCutEnum.CommonApplicationData,
               PathDir = Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData )
            };
            o.Normalize( );
            c.List.Add( o );
         }
         {
            ConfigPath o = new ConfigPath( )
            {
               Type = (int) ConfigPath.ConfigPathTypeEnum.DataStores,
               IsActive = true,
               ShortCut = (int) ConfigPath.PathTypeShortCutEnum.CommonDesktopDirectory,
               PathDir = Environment.GetFolderPath( Environment.SpecialFolder.CommonDesktopDirectory )
            };
            o.Normalize( );
            c.List.Add( o );
         }
         {
            ConfigPath o = new ConfigPath( )
            {
               Type = (int) ConfigPath.ConfigPathTypeEnum.DataStores,
               IsActive = true,
               ShortCut = (int) ConfigPath.PathTypeShortCutEnum.CommonDocuments,
               PathDir = Environment.GetFolderPath( Environment.SpecialFolder.CommonDocuments )
            };
            o.Normalize( );
            c.List.Add( o );
         }
         {
            ConfigPath o = new ConfigPath( )
            {
               Type = (int) ConfigPath.ConfigPathTypeEnum.DataStores,
               IsActive = true,
               ShortCut = (int) ConfigPath.PathTypeShortCutEnum.Desktop,
               PathDir = Environment.GetFolderPath( Environment.SpecialFolder.Desktop )
            };
            o.Normalize( );
            c.List.Add( o );
         }
         {
            ConfigPath o = new ConfigPath( )
            {
               Type = (int) ConfigPath.ConfigPathTypeEnum.DataStores,
               IsActive = true,
               ShortCut = (int) ConfigPath.PathTypeShortCutEnum.DesktopDirectory,
               PathDir = Environment.GetFolderPath( Environment.SpecialFolder.DesktopDirectory )
            };
            o.Normalize( );
            c.List.Add( o );
         }
         {
            ConfigPath o = new ConfigPath( )
            {
               Type = (int) ConfigPath.ConfigPathTypeEnum.DataStores,
               IsActive = true,
               ShortCut = (int) ConfigPath.PathTypeShortCutEnum.LocalApplicationData,
               PathDir = Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData )
            };
            o.Normalize( );
            c.List.Add( o );
         }
         {
            ConfigPath o = new ConfigPath( )
            {
               Type = (int) ConfigPath.ConfigPathTypeEnum.DataStores,
               IsActive = true,
               ShortCut = (int) ConfigPath.PathTypeShortCutEnum.MyDocuments,
               PathDir = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments )
            };
            o.Normalize( );
            c.List.Add( o );
         }
         {
            ConfigPath o = new ConfigPath( )
            {
               Type = (int) ConfigPath.ConfigPathTypeEnum.DataStores,
               IsActive = true,
               ShortCut = (int) ConfigPath.PathTypeShortCutEnum.UserProfile,
               PathDir = Environment.GetFolderPath( Environment.SpecialFolder.UserProfile )
            };
            o.Normalize( );
            c.List.Add( o );
         }
         #endregion

         #region --- TEMPORARY FOLDERS... ---
         {
            DriveInfo[ ] drives = DriveInfo.GetDrives( );
            foreach( DriveInfo drive in drives )
            {
               ConfigPath o = new ConfigPath( )
               {
                  Type = (int) ConfigPath.ConfigPathTypeEnum.Temporary,
                  IsActive = true,
                  ShortCut = (int) ConfigPath.PathTypeShortCutEnum.Custom,
                  PathDir = drive.Name + "temp"
               };
               c.List.Add( o );
            }
         }
         #endregion

         return c;
      }
   }
}
