using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AQBTest
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
         //Application.Run( new Form1( ) );
         Application.Run( new Form1( ConnectionString, filename, false, false, true ) );
      }

      // //public const string ConnectionString = @"XpoProvider=MSSqlServer;data source=DBSRV\QWERTY;user id=user02;password=8a0IucJ@Nx1Qy5HfFrX0Ob3m;";
      public const string ConnectionString = @"Data Source=DBSRV\QWERTY;Database=Sales;User Id=user02;Password=8a0IucJ@Nx1Qy5HfFrX0Ob3m;";
      public const string filename = @"D:\TEMP\SQLite\MetadataMSSQLTestWithFields.xml";
      //
      //public const string ConnectionString = @"Data Source=D:\TEMP\SQLite\SQLITEDB1.db3;";
      //public const string ConnectionString = @"Data Source=D:\TEMP\SQLite\chinook\chinook.db;";
      //public const string filename = @"D:\TEMP\SQLite\MetadataSQLiteTestWithFields.xml";
   }
}
