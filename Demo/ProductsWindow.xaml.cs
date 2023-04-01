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

namespace Demo
{
    /// <summary>
    /// Логика взаимодействия для ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        Пользователи user;
        public ProductsWindow(Пользователи u)
        {
            InitializeComponent();
            user = u;
            if (user != null)
            {
                NameTextBlock.Text =user.Фамилия+user.Имя_отчество;
                if (user.FK_id_Роль != 1)
                {
                    OrdersButton.Visibility = Visibility.Visible;
                }
            }
            MainFrame.Navigate(new ProductsPage(user,this));
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductsPage(user,this));
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OrdersPage());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

    }
}
