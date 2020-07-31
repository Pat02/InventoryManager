using InventoryManager.DnD5eAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManager.DnD5eAPI.Results
{
    public class EquipmentListResult
    {
        public string count;
        public List<EquipmentListLineItem> results;

        public EquipmentListResult()
        {

        }
    }
}
