using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManager.DnD5eAPI.Results
{
    public class EquipmentListResult
    {
        public string _id;
        public string index;
        public string name;
        public string equipment_category;
        public string gear_category;
        public string[] cost;
        public string weight;
        public string url; 
    }
}
