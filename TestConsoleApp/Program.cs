using System;
using InventoryManager.DnD5eAPI;
using System.Collections.Generic;
using InventoryManager.DnD5eAPI.Results;
using InventoryManager.DnD5eAPI.Services;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using InventoryManager.DnD5eAPI.Models;

namespace TestConsoleApp
{
    class Program
    {


        static async Task Main(string[] args)
        {
            ItemListService itemList = new ItemListService();
            ItemService itemService = new ItemService();
            var result = await itemList.ItemList("/api/equipment");
            var result2 = await itemService.GetItem(@"/api/equipment/backpack");
            foreach (EquipmentListLineItem thing in result.results)
            {
                Console.WriteLine($"{thing.name} : {thing.index}");
            }
        }
    }
}
