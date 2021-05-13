using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bar_Hotel_Management_Binni.Models
{
    public class Bill
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TableNo { get; set; }
        public string OrderNo { get; set; }
        public DateTime? BillDate { get; set; }
        public decimal BillAmount { get; set; }
    }
}
