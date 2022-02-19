using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppManageMoney.Entity;
using SQLitePCL;

namespace AppManageMoney.Service
{
   public class CreateService
    {
       
        private SQLiteConnection conn = new SQLiteConnection("sqlitepcldemo.db");
        public List<PersonalTransaction> perList;

        public bool Insert_Data(PersonalTransaction personal)
        {
           
            try
            {
                using (var personstmt = conn.Prepare("INSERT INTO PersonalTransaction (Name,Description,Money,CreatedDate,Category) " +
                    "VALUES (?,?,?,?,?)"))
                {
                    personstmt.Bind(1, personal.Name);
                    personstmt.Bind(2, personal.Description);
                    personstmt.Bind(3, personal.Money);
                    personstmt.Bind(4, personal.CreatedDate.ToString());
                    personstmt.Bind(5, personal.Category);
                    personstmt.Step();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<PersonalTransaction> SelectedData()
        {
            perList = new List<PersonalTransaction>();
            var query = "select * from PersonalTransaction;";
            using (var stmt = conn.Prepare(query))
            {
                Debug.WriteLine(stmt);
                while (stmt.Step() == SQLiteResult.ROW)
                {

                    var personal = new PersonalTransaction()
                    {
                        ID = Convert.ToInt32(stmt["Id"]),
                        Name = (string)stmt["Name"],
                        Description = (string)stmt["Description"],
                        Money = Convert.ToDouble(stmt["Money"]),
                        CreatedDate = Convert.ToDateTime((String)stmt["CreatedDate"]),
                        Category = Convert.ToInt32(stmt["Category"]),

                    };
                    perList.Add(personal);
                }

                return perList;

            }
        }

        public List<PersonalTransaction> Search(string searchFrom, string searchTo)
        {
            perList = new List<PersonalTransaction>();
            var query = "SELECT * FROM PersonalTransaction " +
             "WHERE CreatedDate BETWEEN ? AND ? ";
            using (var stmt = conn.Prepare(query))
            {
                stmt.Bind(1, searchFrom.ToString());
                stmt.Bind(2, searchTo.ToString());
                Debug.WriteLine(stmt);
                while (stmt.Step() == SQLiteResult.ROW)
                {

                    var personal = new PersonalTransaction()
                    {
                        ID = Convert.ToInt32(stmt["Id"]),
                        Name = (string)stmt["Name"],
                        Description = (string)stmt["Description"],
                        Money = Convert.ToDouble(stmt["Money"]),
                        CreatedDate = Convert.ToDateTime((String)stmt["CreatedDate"]),
                        Category = Convert.ToInt32(stmt["Category"]),

                    };
                    perList.Add(personal);
                }

                return perList;

            }
        }




    }

    

}
