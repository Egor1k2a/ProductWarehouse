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
    /// Логика взаимодействия для ReserveDairyWindow.xaml
    /// </summary>
    public partial class ReserveDairyWindow : Window
    {
        public ReserveDairyWindow(Dairy dairyToReserve)
        {
            InitializeComponent();
            DataContext = new DataManage();
            DataManage.SelectedDairy = dairyToReserve;
        }
    }
}
