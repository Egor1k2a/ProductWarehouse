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
using ProductWarehouse.Models;
using ProductWarehouse.ViewModels;

namespace ProductWarehouse.Views
{
    /// <summary>
    /// Логика взаимодействия для ReserveFruitWindow.xaml
    /// </summary>
    public partial class ReserveFruitWindow : Window
    {
        public ReserveFruitWindow(Fruit fruitToReserve)
        {
            InitializeComponent();
            DataContext = new DataManage();
            DataManage.SelectedFruit = fruitToReserve;
        }
    }
}
