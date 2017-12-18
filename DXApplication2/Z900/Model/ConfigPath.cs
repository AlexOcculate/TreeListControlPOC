using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Xml.Serialization;

namespace Z900.Model
{
   [Serializable( )]
   public partial class ConfigPath
   {
      #region --- Enums... ---
      public enum ConfigPathTypeEnum
      {
         DataStores = 0,
         Temporary = 1,
      }

      // Based on "System.Environment.SpecialFolder" enum!
      public enum PathTypeShortCutEnum
      {
         Custom = -1,
         Desktop = Environment.SpecialFolder.Desktop, // 0,
         MyDocuments = Environment.SpecialFolder.MyDocuments, // 5,
         Favorites = Environment.SpecialFolder.Favorites, // 6,
         MyMusic = Environment.SpecialFolder.MyMusic, // 13,
         MyVideos = Environment.SpecialFolder.MyVideos, // 14,
         DesktopDirectory = Environment.SpecialFolder.DesktopDirectory, // 16,
         CommonDesktopDirectory = Environment.SpecialFolder.CommonDesktopDirectory, //25,
         ApplicationData = Environment.SpecialFolder.ApplicationData, // 26,
         LocalApplicationData = Environment.SpecialFolder.LocalApplicationData, // 28,
         CommonApplicationData = Environment.SpecialFolder.CommonApplicationData, // 35,
         MyPictures = Environment.SpecialFolder.MyPictures, // 39,
         UserProfile = Environment.SpecialFolder.UserProfile, // 40,
         CommonDocuments = Environment.SpecialFolder.CommonDocuments, //46,
         CommonMusic = Environment.SpecialFolder.CommonMusic, // 53,
         CommonPictures = Environment.SpecialFolder.CommonPictures, // 54,
         CommonVideos = Environment.SpecialFolder.CommonVideos, // 55,
      }
      #endregion

      //[Key]
      //[Display(AutoGenerateField = false)]
      //public int ID { get; set; }

      public const string ISACTIVE_DISPLAYNAME = "Active?";
      public const string ISACTIVE_FIELDNAME = "IsActive";
      [XmlAttribute]
      [Display( Name = ISACTIVE_DISPLAYNAME )]
      [Required]
      public bool IsActive { get; set; }

      public const string ISVALID_DISPLAYNAME = "Valid?";
      public const string ISVALID_FIELDNAME = "IsValid";
      [XmlIgnore]
      [Display( Name = ISVALID_DISPLAYNAME )]
      [Required]
      public bool IsValid { get; set; }

      public const string EXISTS_DIRFLAG_DISPLAYNAME = "Exists?";
      public const string EXISTS_DIRFLAG_FIELDNAME = "DirExists";
      [XmlIgnore]
      [Display( Name = EXISTS_DIRFLAG_DISPLAYNAME )]
      [ReadOnly( true )]
      public bool DirExists { get; set; }

      public const string READABLE_DIRFLAG_DISPLAYNAME = "Readable?";
      public const string READABLE_DIRFLAG_FIELDNAME = "DirReadable";
      [XmlIgnore]
      [Display( Name = READABLE_DIRFLAG_DISPLAYNAME )]
      [ReadOnly( true )]
      public bool DirReadable { get; set; }

      public const string WRITABLE_DIRFLAG_DISPLAYNAME = "Writable?";
      public const string WRITABLE_DIRFLAG_FIELDNAME = "DirWritable";
      [XmlIgnore]
      [Display( Name = WRITABLE_DIRFLAG_DISPLAYNAME )]
      [ReadOnly( true )]
      public bool DirWritable { get; set; }

      public const string TYPE_DISPLAYNAME = "Type";
      public const string TYPE_FIELDNAME = "Type";
      [XmlAttribute]
      [Display( Name = TYPE_DISPLAYNAME )]
      [EnumDataType( typeof( ConfigPathTypeEnum ) )]
      [Required]
      public int Type { get; set; }

      public const string SHORTCUT_DISPLAYNAME = "ShortCut";
      public const string SHORTCUT_FIELDNAME = "ShortCut";
      [XmlAttribute]
      [Display( Name = SHORTCUT_DISPLAYNAME )]
      [EnumDataType( typeof( PathTypeShortCutEnum ) )]
      [Required]
      public int ShortCut { get; set; }

      public const string PATHDIR_DISPLAYNAME = "PathDir";
      public const string PATHDIR_FIELDNAME = "PathDir";
      [Display( Name = PATHDIR_DISPLAYNAME )]
      public string PathDir { get; set; }

      //public const string BASEDIR_DISPLAYNAME = "BaseDir";
      //public const string BASEDIR_FIELDNAME = "BaseDir";
      //[Display( Name = BASEDIR_DISPLAYNAME )]
      //public string BaseDir { get; set; }
   }
}
