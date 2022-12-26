using ProductWarehouse.Models;
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
    /// Логика взаимодействия для EditFruitWindow.xaml
    /// </summary>
    public partial class EditFruitWindow : Window
    {
        public EditFruitWindow(Fruit fruitToEdit)
        {
            InitializeComponent();
            DataContext = new DataManage();
            DataManage.SelectedFruit = fruitToEdit;
        }
    }
}
