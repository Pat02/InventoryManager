using InventoryManager.Domain.Models;
using InventoryManager.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.WPF.UI.Services
{
    class PersistantDataService
    {
        private GenericDataService<Container> ContainerDataService;
        private GenericDataService<Item> ItemDataService;

        public PersistantDataService(GenericDataService<Container> containerDataService, GenericDataService<Item> itemDataService)
        {
            ContainerDataService = containerDataService;
            ItemDataService = itemDataService;
        }


    }
}
