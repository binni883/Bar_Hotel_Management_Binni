using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bar_Hotel_Management_Binni.Models
{
    public class TableOrder
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string OrderNo { get; set; }
        public string KOT { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
