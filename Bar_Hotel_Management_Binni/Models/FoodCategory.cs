using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bar_Hotel_Management_Binni.Models
{
    public class FoodCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<FoodItem> FoodItems { get; set; }
    }
}
