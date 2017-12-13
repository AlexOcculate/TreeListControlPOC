using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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

      [XmlArray("PathList")]
      [XmlArrayItem(typeof(ConfigPath), ElementName = "Path")]
      public BindingList<ConfigPath> List { get; set; }

      public ConfigPathCollection()
      {
         this.List = new BindingList<ConfigPath>();
      }

      public void Save()
      {
         if (!Directory.Exists(ConfigPathCollection.XMLFILEPATH))
         {
            Directory.CreateDirectory(ConfigPathCollection.XMLFILEPATH);
         }
         this.XmlSerialize(ConfigPathCollection.XMLFULLNAME);
      }

      public static ConfigPathCollection Load()
      {
         if (File.Exists(ConfigPathCollection.XMLFULLNAME))
         {
            return ConfigPathCollection.XmlDeserialize(ConfigPathCollection.XMLFULLNAME);
         }
         ConfigPathCollection o = new ConfigPathCollection();
         o.Save();
         return o;
      }

      #region --- XML Serialization ---
      public void XmlSerialize(string path)
      {
         XmlSerializer xs = new XmlSerializer(typeof(ConfigPathCollection));
         using (TextWriter tw = new StreamWriter(path))
         {
            xs.Serialize(tw, this);
         }
      }
      public static ConfigPathCollection XmlDeserialize(string path)
      {
         XmlSerializer xs = new XmlSerializer(typeof(ConfigPathCollection));
         using (TextReader tr = new StreamReader(path))
         {
            var o = xs.Deserialize(tr) as ConfigPathCollection;
            return o;
         }
      }
      #endregion

      public static ConfigPath NewTemplate()
      {
         ConfigPath o = new ConfigPath()
         {
            Type = (int)ConfigPath.ConfigPathTypeEnum.Temporary,
            IsActive = false,
            ShortCut = (int)ConfigPath.PathTypeShortCutEnum.ApplicationData,
            Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            BaseDir = ConfigPathCollection.BASEDIR
         };
         return o;
      }
      public static ConfigPathCollection NewCollectionTemplate()
      {
         ConfigPathCollection c = new ConfigPathCollection();
         {
            ConfigPath o = new ConfigPath()
            {
               Type = (int)ConfigPath.ConfigPathTypeEnum.Temporary,
               IsActive = false,
               ShortCut = (int)ConfigPath.PathTypeShortCutEnum.CommonPictures,
               Path = Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures)
            };
            c.List.Add(o);
         }
         {
            ConfigPath o = new ConfigPath()
            {
               Type = (int)ConfigPath.ConfigPathTypeEnum.Temporary,
               IsActive = false,
               ShortCut = (int)ConfigPath.PathTypeShortCutEnum.LocalApplicationData,
               Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            };
            c.List.Add(o);
         }
         {
            ConfigPath o = new ConfigPath()
            {
               Type = (int)ConfigPath.ConfigPathTypeEnum.Temporary,
               IsActive = false,
               ShortCut = (int)ConfigPath.PathTypeShortCutEnum.MyDocuments,
               Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            c.List.Add(o);
         }
         {
            ConfigPath o = new ConfigPath()
            {
               Type = (int)ConfigPath.ConfigPathTypeEnum.Temporary,
               IsActive = false,
               ShortCut = (int)ConfigPath.PathTypeShortCutEnum.CommonDocuments,
               Path = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments)
            };
            c.List.Add(o);
         }
         {
            ConfigPath o = new ConfigPath()
            {
               Type = (int)ConfigPath.ConfigPathTypeEnum.Temporary,
               IsActive = false,
               ShortCut = (int)ConfigPath.PathTypeShortCutEnum.ApplicationData,
               Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            };
            c.List.Add(o);
         }
         {
            ConfigPath o = new ConfigPath()
            {
               Type = (int)ConfigPath.ConfigPathTypeEnum.Temporary,
               IsActive = false,
               ShortCut = (int)ConfigPath.PathTypeShortCutEnum.CommonApplicationData,
               Path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
            };
            c.List.Add(o);
         }
         {
            ConfigPath o = new ConfigPath()
            {
               Type = (int)ConfigPath.ConfigPathTypeEnum.Temporary,
               IsActive = false,
               ShortCut = (int)ConfigPath.PathTypeShortCutEnum.LocalApplicationData,
               Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            };
            c.List.Add(o);
         }
         {
            ConfigPath o = new ConfigPath()
            {
               Type = (int)ConfigPath.ConfigPathTypeEnum.DataStores,
               IsActive = false,
               ShortCut = (int)ConfigPath.PathTypeShortCutEnum.Desktop,
               Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };
            c.List.Add(o);
         }
         {
            ConfigPath o = new ConfigPath()
            {
               Type = (int)ConfigPath.ConfigPathTypeEnum.Temporary,
               IsActive = false,
               ShortCut = (int)ConfigPath.PathTypeShortCutEnum.MyDocuments,
               Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            c.List.Add(o);
         }
         {
            ConfigPath o = new ConfigPath()
            {
               Type = (int)ConfigPath.ConfigPathTypeEnum.Temporary,
               IsActive = false,
               ShortCut = (int)ConfigPath.PathTypeShortCutEnum.Desktop,
               Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };
            c.List.Add(o);
         }
         {
            ConfigPath o = new ConfigPath()
            {
               Type = (int)ConfigPath.ConfigPathTypeEnum.Temporary,
               IsActive = false,
               ShortCut = (int)ConfigPath.PathTypeShortCutEnum.DesktopDirectory,
               Path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            };
            c.List.Add(o);
         }
         {
            ConfigPath o = new ConfigPath()
            {
               Type = (int)ConfigPath.ConfigPathTypeEnum.Temporary,
               IsActive = false,
               ShortCut = (int)ConfigPath.PathTypeShortCutEnum.CommonDesktopDirectory,
               Path = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory)
            };
            c.List.Add(o);
         }
         return c;
      }
   }
}
