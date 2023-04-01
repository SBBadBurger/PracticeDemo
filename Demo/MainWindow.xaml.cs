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

namespace Demo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DemoEntities db;
        public MainWindow()
        {
            InitializeComponent();
            db = new DemoEntities();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text!=""&&PasswordBox.Password!="")
            {
                
                if (db.Пользователи.Where(p=>p.Логин==LoginTextBox.Text&&p.Пароль==PasswordBox.Password).FirstOrDefault()!=null)
                {
                    Пользователи user = db.Пользователи.Where(p => p.Логин == LoginTextBox.Text && p.Пароль == PasswordBox.Password).FirstOrDefault();
                    ProductsWindow productsWindow = new ProductsWindow(user);
                    productsWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля");
            }
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            ProductsWindow productsWindow = new ProductsWindow(null);
            productsWindow.Show();
            this.Close();
        }
    }
}
