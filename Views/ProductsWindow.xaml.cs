using ProductWarehouse.ViewModels;
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
using System.Windows.Shapes;

namespace ProductWarehouse.Views
{
    /// <summary>
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        public static ListView AllDairiesView;
        public static ListView AllFishesView;
        public static ListView AllFruitView;
        public static ListView AllMeatView;
        public static ListView AllVegetablesView;

        public ProductsWindow()
        {
            InitializeComponent();
            DataContext = new DataManage();
            AllDairiesView = ViewAllDairies;
            AllFishesView = ViewAllFishes;
            AllFruitView = ViewAllFruit;
            AllMeatView = ViewAllMeat;
            AllVegetablesView = ViewAllVegetables;
        }
    }
}
