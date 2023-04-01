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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        DemoEntities db;
        public OrdersPage()
        {
            InitializeComponent();
            db = new DemoEntities();
            OrdersDataGrid.ItemsSource = db.Заказы.ToList();
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            var data = (Заказы)((Button)sender).DataContext;
            ProductsInOrderWindow productsInOrderWindow = new ProductsInOrderWindow(db.Продукты_Заказов.Where(p=>p.FK_id_Заказ==data.PK_id_Заказ).ToList());
            productsInOrderWindow.Show();
        }
    }
}
