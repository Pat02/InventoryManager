using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InventoryManager.Domain.Models;
using InventoryManager.WPF.UI.ViewModels;

namespace InventoryManager.WPF.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ContainerViewModel = new ContainerViewModel(MakeTestContainer());
            Inventory = ContainerViewModel.Inventory;
        }

        public ContainerViewModel ContainerViewModel { get; set; }
        public ObservableCollection<IStorableViewModel> Inventory { get; set; }

        private Container MakeTestContainer()
        {
            Container rootContainer = new Container();
            rootContainer.ItemDefinition.Weight = 3;
            rootContainer.MaximumCarryWeight = 30;
            rootContainer.id = Guid.NewGuid();
            rootContainer.ItemDefinition.Name = "Main Container";
            rootContainer.Inventory = PopulateInventory();

            Container childContainer = new Container();
            childContainer.ItemDefinition.Weight = 1;
            childContainer.MaximumCarryWeight = 5;
            childContainer.id = Guid.NewGuid();
            childContainer.ItemDefinition.Name = "Child Container";
            childContainer.Inventory = PopulateInventory();

            rootContainer.Inventory.Add(childContainer);
            return rootContainer;
        }

        private static List<StorableItem> PopulateInventory()
        {
            ItemDefinition item1 = new ItemDefinition() { id = Guid.NewGuid(), Weight = 1, Name = "testItem1" };
            ItemDefinition item2 = new ItemDefinition() { id = Guid.NewGuid(), Weight = 1, Name = "testItem2" };
            ItemDefinition item3 = new ItemDefinition() { id = Guid.NewGuid(), Weight = 1, Name = "testItem3" };

            ContainerItem containerItems1 = new ContainerItem() { id = Guid.NewGuid(), ItemDefinition = item1, Quantity = 4 };
            ContainerItem containerItems2 = new ContainerItem() { id = Guid.NewGuid(), ItemDefinition = item2, Quantity = 4 };
            ContainerItem containerItems3 = new ContainerItem() { id = Guid.NewGuid(), ItemDefinition = item3, Quantity = 4 };

            List<StorableItem> list = new List<StorableItem>();

            list.Add(containerItems1);
            list.Add(containerItems2);
            list.Add(containerItems3);
            return list;
        }
    }
}
