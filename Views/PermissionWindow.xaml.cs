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
    /// Логика взаимодействия для PermissionWindow.xaml
    /// </summary>
    public partial class PermissionWindow : Window
    {
        public PermissionWindow(Employee employeeToEditPermission)
        {
            InitializeComponent();
            DataContext = new DataManage();
            DataManage.SelectedEmployee = employeeToEditPermission;
        }
    }
}
