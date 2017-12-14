using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Xml.Serialization;

namespace Z900.Model
{
   public partial class ConfigPath
   {
      public ConfigPath()
      {
      }
      public ConfigPath( ConfigPath cp )
      {
         this.IsActive = cp.IsActive;
         this.IsValid = cp.IsValid;
         this.DirExists = cp.DirExists;
         this.DirReadable = cp.DirReadable;
         this.DirWritable = cp.DirWritable;
         this.Type = cp.Type;
         this.ShortCut = cp.ShortCut;
         this.PathDir = cp.PathDir;
         //this.BaseDir = cp.BaseDir;
      }

      public void Normalize()
      {
         bool isDefined = Enum.IsDefined( typeof( ConfigPath.PathTypeShortCutEnum ), this.ShortCut );
         if( isDefined )
         {
            if( this.ShortCut != (int) ConfigPath.PathTypeShortCutEnum.Custom )
            {
               this.PathDir = Environment.GetFolderPath( (Environment.SpecialFolder) this.ShortCut );
            }
            else
            {
               this.PathDir = this.PathDir?.Trim( );
            }
            //this.BaseDir = this.BaseDir?.Trim( );
            string fullpath = (this.PathDir != null ? this.PathDir : "");
            //fullpath += (this.BaseDir != null ? @"\" + this.BaseDir : "");
            this.DirExists = Directory.Exists( fullpath );
            this.DirReadable = this.DirExists ? CanRead( fullpath ) : false;
            this.DirWritable = this.DirExists ? CanWrite( fullpath ) : false;
            if( this.Type == (int) ConfigPathTypeEnum.DataStores )
            {
               this.IsValid = (this.DirExists && this.DirReadable);
            }
            else
            {
               this.IsValid = (this.DirExists && this.DirReadable && this.DirWritable);
            }
            this.IsActive = this.IsValid && this.IsActive ? true : false;
         }
      }
      public static bool CanRead( string path )
      {
         return VerifyFileSystemAccessRule( path, FileSystemRights.Read );
      }
      public static bool CanWrite( string path )
      {
         return VerifyFileSystemAccessRule( path, FileSystemRights.Write );
      }
      public static bool VerifyFileSystemAccessRule( string path, FileSystemRights fsr )
      {
         var readAllow = false;
         var readDeny = false;
         try
         {
            // @"MyDomain\MyUserOrGroup"
            //string NtAccountName = System.Security.Principal.WindowsIdentity.GetCurrent( ).Name;
            var accessControlList = Directory.GetAccessControl( path );
            if( accessControlList == null )
               return false;
            var accessRules = accessControlList.GetAccessRules( true, true, typeof( System.Security.Principal.SecurityIdentifier ) );
            if( accessRules == null )
               return false;
            foreach( FileSystemAccessRule rule in accessRules )
            {
               if( (fsr & rule.FileSystemRights) != fsr )
                  continue;
               if( rule.AccessControlType == AccessControlType.Allow )
                  readAllow = true;
               else if( rule.AccessControlType == AccessControlType.Deny )
                  readDeny = true;
            }
            return readAllow && !readDeny;
         }
         catch( System.IO.DirectoryNotFoundException ex )
         {
            return false;
         }
      }
   }
}
