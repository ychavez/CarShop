using CarShop.iOS;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;


[assembly: Dependency(typeof(SQLiteiOS))]
namespace CarShop.iOS
{
    public class SQLiteiOS : DependencyServices.ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string sqliteFilename = "Cars.db3";
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libPath = Path.Combine(docPath, "..", "Library");
            string path = Path.Combine(libPath, sqliteFilename);


            SQLiteConnection conn = new SQLiteConnection(path);
            return conn;
        }
    }


}