using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Z900.Model
{
   public partial class DataStore
   {

      public DataStore()
      {
      }

      public static DataStore NewTemplate( DataStoreCollection dsColl )
      {
         // ATTENTION: THIS MUST BE NOT CHANGED "AtLeastOneDataSource" ...
         DataStore ds = new DataStore( );
         {
            ds.Creation = DateTime.Now;
            ds.FullPathName = Program.DATASTORE_1ST_XMLFULLNAME;
            ds.Name = Program.DATASTORE_1ST_XMLFILENAME;
            ds.IsActive = true;
            ds.wasTested = true;
            //string connectionString = MSSqlConnectionProvider.GetConnectionString( @"DBSRV\QWERTY", @"user02", @"8a0IucJ@Nx1Qy5HfFrX0Ob3m", @"Sales" );
            //string connectionString1 = SQLiteConnectionProvider.GetConnectionString( @"D:\TEMP\SQLite\SQLITEDB1.db3" );

            ds.ConnectionString = @"D:\TEMP\SQLite\SQLITEDB1.db3";
            ds.LoginID = null;
            ds.Password = null;
            ds.SyntaxProvider = 1;
            ds.MetadataProvider = 1;
            ds.Preview = "Default 1st DataStore";
            ds.Description = "Default 1st DataStore";
            ds.XmlSerialize( ds.FullPathName );
         }
         //ds.Normalize( );
         return ds;
      }

      #region --- XML Serialization ---
      public void XmlSerialize( string path )
      {
         XmlSerializer xs = new XmlSerializer( typeof( DataStore ) );
         using( TextWriter tw = new StreamWriter( path ) )
         {
            xs.Serialize( tw, this );
         }
      }
      public static DataStore XmlDeserialize( string path )
      {
         XmlSerializer xs = new XmlSerializer( typeof( DataStore ) );
         using( TextReader tr = new StreamReader( path ) )
         {
            var o = xs.Deserialize( tr ) as DataStore;
            return o;
         }
      }
      #endregion
   }
}
