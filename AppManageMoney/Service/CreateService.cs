using System;
using System.Collections.Generic;
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
        
        public bool Insert_Data(string name,string description, string money , string date, string category)
        {
           
            try
            {
                using (var personstmt = conn.Prepare("INSERT INTO PersonalTransaction (Name,Description,Money,CreatedDate,Category) " +
                    "VALUES (?,?,?,?,?)"))
                {
                    personstmt.Bind(1, name);
                    personstmt.Bind(2, description);
                    personstmt.Bind(3, money);
                    personstmt.Bind(4, date);
                    personstmt.Bind(5, category);
                    personstmt.Step();
                }
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        public async Task<List<PersonalTransaction>> Select_Data()
        {
            List<PersonalTransaction> personals ;
            using (var stt = conn.Prepare("select * from PersonalTransaction"))
                {
                    while (stt.Step() != SQLiteResult.ROW)
                    {

                    personals = new List<PersonalTransaction>();
                    personals.Add(PersonalTransaction()
                    {
                        ID = (int)stt["Id"],
                            Name = (String)stt["Name"],
                        Description = (String)stt["Description"],
                        Money = (double)stt["Money"],
                        CreatedDate = (DateTime)stt["CreatedDate"],
                        Category = (int)stt["Category"],


                    });


                }

                }
            return personals;




        }
    }
}
