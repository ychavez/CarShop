using CarShop.DependencyServices;
using CarShop.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CarShop.Context
{
    class DatabaseManager
    {
        private SQLiteConnection db;

        public DatabaseManager()
        {
            db = DependencyService.Get<ISQLite>().GetConnection();

            if(!(TableExists("FavoriteCar")))
                 db.CreateTable<Car>();
        }

        public bool TableExists(string tableName)
        {
            TableMapping map = new TableMapping(typeof(SqlDbType)); 
            object[] ps = new object[0]; 

            int tableCount = db.Query(map, "SELECT * FROM sqlite_master WHERE type = 'table' AND name = '" + tableName + "'", ps).Count; 
            if (tableCount == 0)
                return false;
            else if (tableCount == 1)
                return true;
            else
                throw new Exception($"Hay mas de una tabla con el nombre {tableName} en la base de datos", null);
        }

        public List<Car> GetFavoriteCars() => db.Query<Car>("Select * from FavoriteCar");

        public Car GetFavoriteCars(int id) => db.Query<Car>($"Select * from FavoriteCar where id = {id}").First();

        public void AddFavoriteCar(int id) => db.Insert(GetFavoriteCars(id));

    }
}
