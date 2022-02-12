using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManageMoney.Entity
{
   public class PersonalTransaction
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Money { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Category { get; set; }
    }
}
