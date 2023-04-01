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
    /// Логика взаимодействия для ProductsInOrderWindow.xaml
    /// </summary>
    public partial class ProductsInOrderWindow : Window
    {
        public ProductsInOrderWindow(List<Продукты_Заказов> p)
        {
            InitializeComponent();
            List<Продукты> prod = new List<Продукты> { };
            foreach(Продукты_Заказов продукты in p)
            {
                prod.Add(продукты.Продукты);
            }
            ProductsList.ItemsSource= prod;
        }
    }
}
