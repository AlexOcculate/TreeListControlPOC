using System;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using Z900.Model;

namespace Z900
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles( );
         Application.SetCompatibleTextRenderingDefault( false );
         BonusSkins.Register( );
         SkinManager.EnableFormSkins( );
         Application.Run( new NavigationControllerForm( ) );

         //Properties.Settings.Default[ "SomeProperty" ] = "Some Value";
         //Properties.Settings.Default.Save( ); // Saves settings in application configuration file
      }

      public static string BASEDIR = @"Z900";
      public static string XMLFILEPATH = Environment.GetFolderPath(
         Environment.SpecialFolder.MyDocuments,
         Environment.SpecialFolderOption.Create
         )
         + @"\"
         + Program.BASEDIR
         + @"\"
      ;
      //
      public static string CONFIGPATH_XMLFILENAME = @"ConfigPath.xml";
      public static string CONFIGPATH_XMLFULLNAME = XMLFILEPATH + CONFIGPATH_XMLFILENAME;
      //
      public static string DATASTORE_1ST_XMLFILENAME = @"DATASTORE.ds.xml";
      public static string DATASTORE_1ST_XMLFULLNAME = XMLFILEPATH + DATASTORE_1ST_XMLFILENAME;
   }
}
