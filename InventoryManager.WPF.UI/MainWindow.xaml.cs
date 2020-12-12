using System;
using System.Collections.Generic;
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
            TreeviewViewModel viewModel = new TreeviewViewModel();
            viewModel.RootContainer = MakeTestContainer();
            DataContext = viewModel;
        }

        private Container MakeTestContainer()
        {
            Container rootContainer = new Container();
            rootContainer.Weight = 3;
            rootContainer.MaximumCarryCapacity = 30;

            Item item1 = new Item() { id = Guid.NewGuid(), Weight = 1, Name = "testItem1" };
            Item item2 = new Item() { id = Guid.NewGuid(), Weight = 1, Name = "testItem2" };
            Item item3 = new Item() { id = Guid.NewGuid(), Weight = 1, Name = "testItem3" };

            ContainerItems containerItems1 = new ContainerItems() { id = Guid.NewGuid(), Item = item1, Quantity = 4 };
            ContainerItems containerItems2 = new ContainerItems() { id = Guid.NewGuid(), Item = item2, Quantity = 4 };
            ContainerItems containerItems3 = new ContainerItems() { id = Guid.NewGuid(), Item = item3, Quantity = 4 };

            List<ContainerItems> list = new List<ContainerItems>();

            list.Add(containerItems1);
            list.Add(containerItems2);
            list.Add(containerItems3);

            rootContainer.Inventory = list;

            return rootContainer;
        }
    }
}
