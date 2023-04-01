using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для CurrentOrderWindow.xaml
    /// </summary>
    public partial class CurrentOrderWindow : Window
    {
        DemoEntities db;
        List<Продукты> list;
        Пользователи u;
        double coast;
        double discount;
        double current;
        public CurrentOrderWindow(List<Продукты> plist, Пользователи user)
        {
            InitializeComponent();
            db = new DemoEntities();
            this.u= user;
            this.list = plist;
            ProductsList.ItemsSource = list;
            getPrices(list);
            PointComboBox.ItemsSource = db.Пункты_Выдачи.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var data =(Продукты)((Button)sender).DataContext;
            list.Remove(data);
            ProductsList.ItemsSource = null;
            ProductsList.Items.Clear();
            ProductsList.ItemsSource = list;
            getPrices(list);
        }
        private void getPrices(List<Продукты> list)
        {
            coast = 0;
            current = 0;
            discount = 0;
            foreach (Продукты продукты in list)
            {
                coast += Convert.ToInt32(продукты.Стоимость);
                current+= Convert.ToInt32(продукты.Стоимость) - Convert.ToInt32(продукты.Стоимость) * Convert.ToInt32(продукты.Действующая_скидка)/100;
            }
            discount =100-(current / coast * 100);
            PriceTextBlock.Text = coast.ToString();
            DiscountTextBlock.Text = discount.ToString().Substring(0,3)+"%";
            CurrentTextBlock.Text = current.ToString();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (PointComboBox.SelectedItem != null)
            {
                Заказы заказы = new Заказы { };
                if (u != null)
                {
                    заказы = new Заказы
                    {
                        Дата_заказа = DateTime.Now,
                        FK_id_Пункт_Выдачи = (PointComboBox.SelectedItem as Пункты_Выдачи).PK_id_Пункт_Выдачи,
                        ФИО_клиента= u.Фамилия+u.Имя_отчество,
                        Статус_заказа = 1
                    };
                }
                else
                {
                    заказы = new Заказы
                    {
                        Дата_заказа = DateTime.Now,
                        FK_id_Пункт_Выдачи = (PointComboBox.SelectedItem as Пункты_Выдачи).PK_id_Пункт_Выдачи,
                        Статус_заказа = 1
                    };
                }
                
                db.Заказы.Add(заказы);
                db.SaveChanges();
                var zak = db.Заказы.Where(p => p.PK_id_Заказ == db.Заказы.Count()).First();
                foreach (Продукты продукты in list)
                {
                    Продукты_Заказов orders = new Продукты_Заказов
                    {
                        FK_id_Продукт = продукты.PK_id_Продукт,
                        FK_id_Заказ = zak.PK_id_Заказ,
                        Количество = 1
                    };
                    db.Продукты_Заказов.Add(orders);
                    db.SaveChanges();
                }
                MessageBox.Show("Заказ оформлен успешно");
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите пункт выдачи");
            }
        }
    }
}
