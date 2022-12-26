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

namespace ProductWarehouse.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /*private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_second = passBoxSecond.Password.Trim();

            if(login.Length < 5)
            {
                textBoxLogin.ToolTip = "Необходимо ввести более 5 символов!";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if(pass.Length < 5)
            {
                passBox.ToolTip = "Необходимо ввести более 5 символов!";
                passBox.Background = Brushes.DarkRed;
            }
            else if (pass != pass_second)
            {
                passBoxSecond.ToolTip = "Пароли не совпадают!";
                passBoxSecond.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBoxSecond.ToolTip = "";
                passBoxSecond.Background = Brushes.Transparent;

                MessageBox.Show("Всё хорошо!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductsWindow productsWindow = new ProductsWindow();
            productsWindow.Show();
        }*/
    }
}
