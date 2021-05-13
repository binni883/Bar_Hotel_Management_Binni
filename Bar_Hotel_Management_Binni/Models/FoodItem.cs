using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bar_Hotel_Management_Binni.Models
{
    public class FoodItem
    {
        public int ID { get; set; }
        public int FoodCategoryID { get; set; }
        public string Name { get; set; }

        public FoodCategory FoodCategories { get; set; }
        public List<FoodRateList> FoodRateList { get; set; }
    }
}
