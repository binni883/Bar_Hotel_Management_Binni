using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bar_Hotel_Management_Binni.Models
{
    public class FoodRateList
    {
        public int ID { get; set; }
        public int FoodItemID { get; set; }
        public decimal Rate { get; set; }
        public string PlatType { get; set; }

        public FoodItem FoodItems { get; set; }
    }
}
