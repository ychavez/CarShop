using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.DependencyServices
{
    public interface ISQLite
    {

        SQLiteConnection GetConnection();
    }
}
