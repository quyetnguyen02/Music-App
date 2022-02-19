using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact_Information.Entity;
using SQLitePCL;

namespace Contact_Information.Data
{
   public class CRUD
    {
        private SQLiteConnection conn = new SQLiteConnection("sqlitepcldemo.db");
        public List<Contact> conList;
        public bool Insert_Data(Contact contact)
        {
            try
            {

                using (var personstmt = conn.Prepare("INSERT INTO Contact (Name,Phone)" +
                    "VALUES (?,?)"))
                {
                    personstmt.Bind(1, contact.Name);
                    personstmt.Bind(2, contact.Phone);                  
                    personstmt.Step();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Contact> SelectedData()
        {
            conList = new List<Contact>();
            var query = "select * from Contact;";
            using (var stmt = conn.Prepare(query))
            {
                
                while (stmt.Step() == SQLiteResult.ROW)
                {

                    var contact = new Contact()
                    {
                        ID = Convert.ToInt32(stmt["Id"]),
                        Name = (string)stmt["Name"],
                        Phone = (string)stmt["Phone"],
                    };
                   conList.Add(contact);
                }

                return conList;

            }
        }

        public List<Contact> Search(string Name,string Phone)
        {
            conList = new List<Contact>();
            var query = "SELECT * FROM Contact " +
             "WHERE Name ?";
            using (var stmt = conn.Prepare(query))
            {
                stmt.Bind(1, Name.ToString());
               
               
                while (stmt.Step() == SQLiteResult.ROW)
                {

                    var contact = new Contact()
                    {
                        ID = Convert.ToInt32(stmt["Id"]),
                        Name = (string)stmt["Name"],
                        Phone = (string)stmt["Phone"],
                    };
                    conList.Add(contact);
                }

                return conList;

            }
        }

    }
}
