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
    /// Логика взаимодействия для OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        public static ListView AllReservationProductsIDView;

        public OrdersWindow()
        {
            InitializeComponent();
            DataContext = new DataManage();
            AllReservationProductsIDView = ViewAllReservationProductsID;
        }
    }
}
