using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace Contact_Information.Data
{
   public class DataBase
    {
        public static bool CreateTables()
        {
            var conn = new SQLiteConnection("Data.db");
            string sql = @"CREATE TABLE IF NOT EXISTS    
                           Contact (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                            Name VARCHAR( 140 ),                            
                                Phone VARCHAR);";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
            return true;

        }
    }
}
