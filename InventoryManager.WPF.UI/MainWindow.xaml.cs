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
            rootContainer.Weight = 3;
            rootContainer.MaximumCarryWeight = 30;
            rootContainer.id = Guid.NewGuid();
            rootContainer.Name = "Main Container";
            rootContainer.Inventory = PopulateInventory();

            Container childContainer = new Container();
            childContainer.Weight = 1;
            childContainer.MaximumCarryWeight = 5;
            childContainer.id = Guid.NewGuid();
            childContainer.Name = "Child Container";
            childContainer.Inventory = PopulateInventory();

            rootContainer.Inventory.Add(childContainer);
            return rootContainer;
        }

        private static List<IStorable> PopulateInventory()
        {
            Item item1 = new Item() { id = Guid.NewGuid(), Weight = 1, Name = "testItem1" };
            Item item2 = new Item() { id = Guid.NewGuid(), Weight = 1, Name = "testItem2" };
            Item item3 = new Item() { id = Guid.NewGuid(), Weight = 1, Name = "testItem3" };

            ContainerItem containerItems1 = new ContainerItem() { id = Guid.NewGuid(), Item = item1, Quantity = 4 };
            ContainerItem containerItems2 = new ContainerItem() { id = Guid.NewGuid(), Item = item2, Quantity = 4 };
            ContainerItem containerItems3 = new ContainerItem() { id = Guid.NewGuid(), Item = item3, Quantity = 4 };

            List<IStorable> list = new List<IStorable>();

            list.Add(containerItems1);
            list.Add(containerItems2);
            list.Add(containerItems3);
            return list;
        }
    }
}
