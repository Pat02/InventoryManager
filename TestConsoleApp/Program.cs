using System;
using InventoryManager.DnD5eAPI;
using System.Collections.Generic;
using InventoryManager.DnD5eAPI.Results;

namespace TestConsoleApp
{
    class Program
    {
        
        
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            DnD5eAPIClient client = new DnD5eAPIClient();
            var ItemList = await client.GetAsync<EquipmentListResult>(string.Empty);
            Console.WriteLine("Hello World!");
        }
    }
}
