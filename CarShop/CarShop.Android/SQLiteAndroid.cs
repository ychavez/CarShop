using CarShop.Droid;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteAndroid))]
namespace CarShop.Droid
{
    public class SQLiteAndroid : DependencyServices.ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string sqlFilename = "Cars.db3";
            string docPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(docPath, sqlFilename);

            SQLiteConnection conn = new SQLiteConnection(path);
            return conn;
        }

    }
}